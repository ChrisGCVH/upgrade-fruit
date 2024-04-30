using FluentResults;
using FluentValidation.Results;
using HicomInterview.Application.Interfaces.Persistence;
using HicomInterview.Domain.Entities;
using HicomInterview.Validation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HicomInterview.Infrastructure.Persistence
{
    /// <summary>
    /// Implementation of IApplicationDbContext, targeting Sql Server
    /// </summary>
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(
            DbContextOptions options
        ) : base(options)
        {
        }

        public DbSet<Widget> Widget => Set<Widget>();
        public DbSet<Address> Address => Set<Address>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Pull in all 'IEntityTypeConfiguration<T>' configuration helper classes
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public new async Task<Result<int>> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                UpdateRowVersionOriginalValue();

                var result = await base.SaveChangesAsync(cancellationToken);
                return result;
            }
            catch (DbUpdateConcurrencyException)
            {
                var validationResult = new ValidationResult();
                validationResult.Errors.Add(new ValidationFailure(string.Empty, "Unable to save changes. The record was updated by another user."));

                return Result.Fail("").WithValidationResults(validationResult.Errors);
            }
        }

        /// <summary>
        /// Reset RowVersion properties to their original value
        /// </summary>
        private void UpdateRowVersionOriginalValue()
        {
            foreach (var trackedEntry in ChangeTracker.Entries().Where(tracking => tracking.State == EntityState.Unchanged || tracking.State == EntityState.Modified || tracking.State == EntityState.Deleted))
            {
                var isRowVersionAvailable = trackedEntry.OriginalValues.Properties.Where(x => x.Name.Equals("RowVersion")).FirstOrDefault();
                if (isRowVersionAvailable != null)
                    trackedEntry.OriginalValues.SetValues(new Dictionary<string, object>() { { "RowVersion", trackedEntry.CurrentValues["RowVersion"]! } });
            }
        }
    }
}
