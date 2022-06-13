﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TenantService.Infrastructure.Data;

#nullable disable

namespace TenantService.Infrastructure.Migrations
{
    [DbContext(typeof(TenantContext))]
    partial class TenantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TenantService.Core.Domain.Aggregates.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<Guid?>("BannerAssetId")
                        .HasColumnType("char(36)")
                        .HasColumnName("asset_banner");

                    b.Property<Guid?>("BrandImageAssetId")
                        .HasColumnType("char(36)")
                        .HasColumnName("asset_brand_image");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<decimal?>("DeliveryCost")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("delivery_cost");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("Imprint")
                        .HasColumnType("longtext")
                        .HasColumnName("website_impres");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsFreeDelivery")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_free_delivery");

                    b.Property<Guid?>("LogoAssetId")
                        .HasColumnType("char(36)")
                        .HasColumnName("asset_logo");

                    b.Property<decimal>("MinimunOrderAmount")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("minimum_order_amount");

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Payments")
                        .HasColumnType("longtext")
                        .HasColumnName("payments");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("phone");

                    b.Property<Guid?>("VideoAssetId")
                        .HasColumnType("char(36)")
                        .HasColumnName("asset_video");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("longtext")
                        .HasColumnName("website_url");

                    b.HasKey("Id");

                    b.ToTable("tenant", (string)null);
                });

            modelBuilder.Entity("TenantService.Core.Domain.Aggregates.Tenant", b =>
                {
                    b.OwnsOne("TenantService.Core.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("TenantId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("address_city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("address_country");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("address_state");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("address_street");

                            b1.Property<string>("Zip")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("address_zip");

                            b1.HasKey("TenantId");

                            b1.ToTable("tenant");

                            b1.WithOwner()
                                .HasForeignKey("TenantId");
                        });

                    b.OwnsMany("TenantService.Core.Domain.ValueObjects.Workingday", "Workingdays", b1 =>
                        {
                            b1.Property<Guid>("TenantId")
                                .HasColumnType("char(36)")
                                .HasColumnName("tenant_id");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasColumnName("id");

                            b1.Property<string>("Closing")
                                .HasColumnType("longtext")
                                .HasColumnName("closing_time");

                            b1.Property<bool>("IsClosedToday")
                                .HasColumnType("tinyint(1)")
                                .HasColumnName("is_closed_today");

                            b1.Property<string>("Message")
                                .HasColumnType("longtext")
                                .HasColumnName("extra_message");

                            b1.Property<string>("Opening")
                                .HasColumnType("longtext")
                                .HasColumnName("opening_time");

                            b1.HasKey("TenantId", "Id");

                            b1.ToTable("tenant_working_days", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("TenantId");

                            b1.OwnsOne("TenantService.Core.Domain.Enumerations.Weekday", "Weekday", b2 =>
                                {
                                    b2.Property<Guid>("WorkingdayTenantId")
                                        .HasColumnType("char(36)");

                                    b2.Property<int>("WorkingdayId")
                                        .HasColumnType("int");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasColumnType("longtext")
                                        .HasColumnName("weekday_description");

                                    b2.Property<int>("Value")
                                        .HasColumnType("int")
                                        .HasColumnName("weekday_value");

                                    b2.HasKey("WorkingdayTenantId", "WorkingdayId");

                                    b2.ToTable("tenant_working_days");

                                    b2.WithOwner()
                                        .HasForeignKey("WorkingdayTenantId", "WorkingdayId");
                                });

                            b1.Navigation("Weekday")
                                .IsRequired();
                        });

                    b.Navigation("Address");

                    b.Navigation("Workingdays");
                });
#pragma warning restore 612, 618
        }
    }
}
