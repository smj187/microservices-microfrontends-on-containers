﻿using BuildingBlocks.Exceptions;
using CatalogService.Application.Commands.Sets;
using CatalogService.Core.Domain.Sets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.CommandHandlers.Sets
{
    public class RemoveProductFromSetCommandHandler : IRequestHandler<RemoveProductFromSetCommand, Set>
    {
        private readonly ISetRepository _setRepository;

        public RemoveProductFromSetCommandHandler(ISetRepository setRepository)
        {
            _setRepository = setRepository;
        }

        public async Task<Set> Handle(RemoveProductFromSetCommand request, CancellationToken cancellationToken)
        {
            var set = await _setRepository.FindAsync(request.SetId);

            if (set == null)
            {
                throw new AggregateNotFoundException(nameof(Set), request.SetId);
            }

            set.RemoveProduct(request.ProductId);

            return await _setRepository.PatchAsync(request.SetId, set);
        }
    }
}