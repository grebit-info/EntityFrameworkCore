﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using EFCorePowerTool.ggggg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;


namespace EFCorePowerTool.ggggg.Configurations
{
    public partial class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> entity)
        {
            entity.HasKey(e => e.CategoryId);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Categories> entity);
    }
}