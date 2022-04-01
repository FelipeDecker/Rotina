using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Rotina.Domain.Entities;
using Rotina.Repository.Models;

namespace Rotina.Repository.Contexts
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            //ChangeTracker.CascadeDeleteTiming = CascadeTiming.Never;
        }

        #region DbSets

        public virtual DbSet<UserEntity> User { get; set; }
        public virtual DbSet<LoginEntity> Login { get; set; }
        public virtual DbSet<ApplicationUserModel> ApplicationUser { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
