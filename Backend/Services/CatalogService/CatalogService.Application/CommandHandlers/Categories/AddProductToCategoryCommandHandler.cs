﻿using BuildingBlocks.Mongo;
using CatalogService.Application.Commands.Categories;
using CatalogService.Core.Entities.Aggregates;
using CatalogService.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.CommandHandlers.Categories
{
    public class AddProductToCategoryCommandHandler : IRequestHandler<AddProductToCategoryCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddProductToCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(AddProductToCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindAsync(x => x.Id == request.CategoryId);

            if (category == null)
            {
                throw new NotImplementedException();
            }

            category.AddProduct(request.ProductId);
            

            return await _categoryRepository.PatchAsync(request.CategoryId, category);
        }
    }
}