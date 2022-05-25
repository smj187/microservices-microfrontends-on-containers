﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Contracts.v1.Requests
{
    public class UserRegisterRequest
    {
        public string Username { get; set; } = default!;

        public string Email { get; set; } = default!;
        //public string ConfirmEmail { get; set; } = default!;

        public string Password { get; set; } = default!;
        //public string ConfirmPassword { get; set; } = default!;
    }
}