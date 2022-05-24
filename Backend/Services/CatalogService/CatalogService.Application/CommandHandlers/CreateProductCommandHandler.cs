﻿using BuildingBlocks.Mongo;
using CatalogService.Application.Commands;
using CatalogService.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IMongoRepository<Product> _mongoRepository;

        public CreateProductCommandHandler(IMongoRepository<Product> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return await _mongoRepository.AddAsync(request.NewProduct);
        }
    }
}
