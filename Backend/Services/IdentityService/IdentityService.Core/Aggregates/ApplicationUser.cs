using Ardalis.GuardClauses;
using BuildingBlocks.Domain;
using BuildingBlocks.Multitenancy.Interfaces;
using IdentityService.Core.Identities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Core.Aggregates
{
    public class ApplicationUser : AggregateBase, IMultitenantAggregate
    {
        private InternalIdentityUser _internalIdentityUser;

        public Guid InternalUserId { get; set; }

        private string? _firstname = null;
        private string? _lastname = null;
        private string? _avatarUrl = null;
        private string _tenantId;

        // ef required (never called)
        public ApplicationUser() 
        {
            _internalIdentityUser = default!;
            _tenantId = default!;
        }

        public ApplicationUser(string tenantId, Guid id, InternalIdentityUser identityUser, string? firstname = null, string? lastname = null)
        {
            Id = id;
            Guard.Against.Null(identityUser, nameof(identityUser));
            Guard.Against.NullOrWhiteSpace(tenantId, nameof(tenantId));
            _internalIdentityUser = identityUser;

            _tenantId = tenantId;
            _firstname = firstname;
            _lastname = lastname;
            _avatarUrl = null;

            CreatedAt = DateTimeOffset.UtcNow;
        }

        public string TenantId
        {
            get => _tenantId;
            set => _tenantId = Guard.Against.NullOrWhiteSpace(value, nameof(value));
        }

        public InternalIdentityUser InternalIdentityUser
        {
            get => _internalIdentityUser;
            private set => _internalIdentityUser = value;
        }

        public string? Firstname
        {
            get => _firstname;
            private set => _firstname = value;
        }

        public string? Lastname
        {
            get => _lastname;
            private set => _lastname = value;
        }

        public string? AvatarUrl
        {
            get => _avatarUrl;
            private set => _avatarUrl = value;
        }


        public void ChangeProfile(string? firstname = null, string? lastname = null)
        {
            _firstname = firstname;
            _lastname = lastname;

            ModifiedAt = DateTimeOffset.UtcNow;
        }

        public void SetAvatar(string? url = null)
        {
            _avatarUrl = url;

            ModifiedAt = DateTimeOffset.UtcNow;
        }
    }
}
