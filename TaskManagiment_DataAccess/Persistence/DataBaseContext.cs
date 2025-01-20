using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskManagiment_Application.Model;
using TaskManagiment_Application.Service;
using TaskManagiment_Core.Common;

namespace TaskManagiment_DataAccess.Persistence
{
    public class DataBaseContext : IdentityDbContext<ApplicationUser>
    {
        private IClaimService? _claimService;

        public DataBaseContext(DbContextOptions options, IClaimService claimService) : base(options)
        {
            _claimService = claimService;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<User> AirwaysUser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            if (_claimService != null)
            {
                foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedBy = _claimService.GetUserId();
                            entry.Entity.CreatedOn = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            entry.Entity.UpdatedBy = _claimService.GetUserId();
                            entry.Entity.UpdatedOn = DateTime.Now;
                            break;
                    }
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
