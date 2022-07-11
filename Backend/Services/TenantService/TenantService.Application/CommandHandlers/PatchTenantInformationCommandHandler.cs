﻿using BuildingBlocks.EfCore.Repositories.Interfaces;
using BuildingBlocks.Exceptions;
using BuildingBlocks.Exceptions.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantService.Application.Commands;
using TenantService.Core.Domain.Aggregates;

namespace TenantService.Application.CommandHandlers
{
    public class PatchTenantInformationCommandHandler : IRequestHandler<PatchTenantInformationCommand, Tenant>
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PatchTenantInformationCommandHandler(ITenantRepository tenantRepository, IUnitOfWork unitOfWork)
        {
            _tenantRepository = tenantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Tenant> Handle(PatchTenantInformationCommand request, CancellationToken cancellationToken)
        {
            var tenant = await _tenantRepository.FindAsync(request.TenantId);
            if (tenant == null)
            {
                throw new AggregateNotFoundException(nameof(Tenant), request.TenantId);
            }

            tenant.PatchInformation(request.Name, request.Description, request.MinimunOrderAmount, request.IsFreeDelivery, request.DeliveryCost, request.WebsiteUrl, request.Imprint, request.Email, request.Phone, request.Payments);

            var patched = await _tenantRepository.PatchAsync(tenant);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return patched;
        }
    }
}
