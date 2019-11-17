using Microsoft.EntityFrameworkCore;

namespace JB.Integration.Data.Configuration
{
    public static class IntegrationConfiguration
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
