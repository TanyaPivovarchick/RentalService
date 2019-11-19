using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentalService.DAL.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User() { Id = 1, Email = "admin@gmail.com", Password = "123456", RoleId = 1 },
                new User() { Id = 2, Email = "user@gmail.com", Password = "123456", RoleId = 2 }
            );
        }
    }
}
