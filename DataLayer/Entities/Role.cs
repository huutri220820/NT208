using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Role : IdentityRole<Guid>
    {
        private readonly ILazyLoader lazyLoader;

        public Role()
        {

        }
        public Role(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }
        public string Description { get; set; }

        private List<UserRole> userRoles;
        public virtual List<UserRole> UserRoles
        {
            get => this.lazyLoader.Load(this, ref this.userRoles);
            set => this.userRoles = value;
        }
    }

    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(x => x.UserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Description).IsRequired(false);
        }
    }
}
