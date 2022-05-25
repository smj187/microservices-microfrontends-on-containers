﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Contracts.v1.Requests
{
    public class CreateOrderRequest
    {
        public Guid UserId { get; set; }
        public Guid TenantId { get; set; }
        public List<Guid> Products { get; set; } = new();
    }
}