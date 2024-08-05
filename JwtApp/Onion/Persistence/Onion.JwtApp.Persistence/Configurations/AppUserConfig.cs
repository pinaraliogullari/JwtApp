using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.JwtApp.Domain.Entities;

namespace Onion.JwtApp.Persistence.Configurations
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne(x => x.AppRole).WithMany(y => y.AppUsers).HasForeignKey(x => x.AppRoleId);
        }
    }
}
