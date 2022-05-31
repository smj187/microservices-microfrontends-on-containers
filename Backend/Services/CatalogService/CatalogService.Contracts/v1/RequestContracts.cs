﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Contracts.v1
{
    // create new category
    public record CreateCategoryRequest([Required] string Name, string? Description, List<Guid>? ProductIds);

    // patch category description
    public record PatchCategoryDescriptionRequest([Required] string Name, string? Description);




    // create new group
    public record CreateGroupRequest([Required] string Name, [Required] decimal Price, string? Description, string? PriceDescription, List<string>? Tags);

    // patch group description
    public record PatchGroupDescriptionRequest([Required] string Name, string? Description, string? PriceDescription, List<string>? Tags);

    // patch group price
    public record PatchGroupPriceRequest([Required] decimal Price);

    // patch group visibility
    public record PatchGroupVisibilityRequest([Required] bool IsVisible);




    // create new product
    public record CreateProductRequest([Required] string Name, [Required] decimal Price, List<IngredientsRequest>? Ingredients, List<AllergensRequest>? Allergens, List<NutritionsRequest>? Nutritions, string? Description, string? PriceDescription, List<string>? Tags);
    public record IngredientsRequest([Required] string Name);
    public record AllergensRequest([Required] string Abbr, [Required] string Name);
    public record NutritionsRequest([Required] string Name, [Required] int Weight);

    // manage product ingredients
    public record AddIngredientsRequest(List<IngredientsRequest> Ingredients, List<AllergensRequest> Allergens, List<NutritionsRequest> Nutritions);
    public record RemoveIngredientsRequest(List<IngredientsRequest> Ingredients, List<AllergensRequest> Allergens, List<NutritionsRequest> Nutritions);

    // patch product description
    public record PatchProductDescriptionRequest([Required] string Name, string? Description, string? PriceDescription, List<string>? Tags);

    // patch product price
    public record PatchProductPriceRequest([Required] decimal Price);

    // patch product visibility
    public record PatchProductVisibilityRequest([Required] bool IsVisible);
}
