﻿using IdentityService.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Commands
{
    public class AuthenticateUserCommand : IRequest<AuthenticatedUser>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}