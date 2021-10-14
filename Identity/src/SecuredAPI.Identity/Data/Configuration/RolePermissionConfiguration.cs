﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecuredAPI.Identity.Data.Entities;
using SecuredAPI.SharedKernel.SharedObjects;

namespace SecuredAPI.Identity.Data.Configuration
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable(nameof(RolePermission));

            builder.OwnsOne(x => x.Permission, rp =>
            {
                rp.Property(p => p.Value).HasColumnName("PermissionValue");
                rp.Property(p => p.Key)
                    .HasColumnName("PermissionKey")
                    .HasConversion(p => p.Value, p => PermissionKey.FromValue(p));
            });

            builder.HasQueryFilter(x => x.Role.IsDeleted == false);

            builder.HasKey(x => x.Id);
        }
    }
}
