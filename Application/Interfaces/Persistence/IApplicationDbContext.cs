using HicomInterview.Domain.Entities;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace HicomInterview.Application.Interfaces.Persistence
{
    /// <summary>
    /// DB context interface for the application
    /// </summary>
    /// <remarks>
    /// Add entity DbSets as required.
    /// 
    /// This is injected for use and its implementation registered in Program.cs. A default MSSQL implementation is provided in "Infrastructure"
    /// </remarks>
    public interface IApplicationDbContext
    {
        #region Entity DbSets
        DbSet<Widget> Widget { get; }
        DbSet<Address> Address { get; }
        #endregion


        Task<Result<int>> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
