using JB.Integration.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JB.Integration.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(s => s.UserId).IsRequired(true);
            builder.Property(s => s.UserName).IsRequired(true);
            builder.Property(s => s.Password).IsRequired(true);
            builder.Property(s => s.Email).IsRequired(true);

            builder.HasData(
                new User { UserId = Guid.NewGuid(), UserName = "John Doe1", Password = "12345678", Email = "johnnblade@hotmail.com", Created = DateTime.Now, LastUpdated = DateTime.Now },
                new User { UserId = Guid.NewGuid(), UserName = "John Doe2", Password = "12345678", Email = "johnnblade2@hotmail.com", Created = DateTime.Now, LastUpdated = DateTime.Now },
                new User { UserId = Guid.NewGuid(), UserName = "John Doe3", Password = "12345678", Email = "johnnblade3@hotmail.com", Created = DateTime.Now, LastUpdated = DateTime.Now },
                new User { UserId = Guid.NewGuid(), UserName = "John Doe4", Password = "12345678", Email = "johnnblade4@hotmail.com", Created = DateTime.Now, LastUpdated = DateTime.Now }
                );
        }
    

    }
}
