﻿using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Core.Domain
{
    public class AssetType : Enumeration
    {
        // catalog
        public static readonly AssetType CatalogProductImage = new(0, "Catalog Product Image");
        public static readonly AssetType CatalogProductVideo = new(1, "Catalog Product Video");
        public static readonly AssetType CatalogGroupImage = new(2, "Catalog Group Image");
        public static readonly AssetType CatalogGroupVideo = new(3, "Catalog Group Video");
        public static readonly AssetType CatalogCategoryImage = new(4, "Catalog Category Image");
        public static readonly AssetType CatalogCategoryVideo = new(5, "Catalog Category Video");

        // idenity
        public static readonly AssetType IdentityAvatarImage = new(6, "Identity Avatar Image");

        // tenant
        public static readonly AssetType TenantBrandImage = new(7, "Tenant Brand Image");
        public static readonly AssetType TenantLogo = new(8, "Tenant Logo");
        public static readonly AssetType TenantVideo = new(9, "Tenant Video");
        public static readonly AssetType TenantBanner = new(10, "Tenant Banner");

        public AssetType(int value, string description)
            : base(value, description)
        {

        }

        public static AssetType Create(int value)
        {
            if (value == 0) return new AssetType(CatalogProductImage.Value, CatalogProductImage.Description);
            if (value == 1) return new AssetType(CatalogProductVideo.Value, CatalogProductVideo.Description);
            if (value == 2) return new AssetType(CatalogGroupImage.Value, CatalogGroupImage.Description);
            if (value == 3) return new AssetType(CatalogGroupVideo.Value, CatalogGroupVideo.Description);
            if (value == 4) return new AssetType(CatalogCategoryImage.Value, CatalogCategoryImage.Description);
            if (value == 5) return new AssetType(CatalogCategoryVideo.Value, CatalogCategoryVideo.Description);

            if (value == 6) return new AssetType(IdentityAvatarImage.Value, IdentityAvatarImage.Description);

            if (value == 7) return new AssetType(TenantBrandImage.Value, TenantBrandImage.Description);
            if (value == 8) return new AssetType(TenantLogo.Value, TenantLogo.Description);
            if (value == 9) return new AssetType(TenantVideo.Value, TenantVideo.Description);
            if (value == 10) return new AssetType(TenantBanner.Value, TenantBanner.Description);


            throw new NotImplementedException();
        }

    }
}
