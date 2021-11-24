using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DistributedSystems.Web.Database.Interfaces
{
    public interface IDbContext : IReadonlyDbContext
    {
        #region DbContext Properties & Methods

        /// <inheritdoc cref="DbContext.ChangeTracker"/>
        ChangeTracker ChangeTracker { get; }

        /// <inheritdoc cref="DbContext.Attach"/>
        EntityEntry<TEntity> Attach<TEntity>([NotNull] TEntity entity)
            where TEntity : class;

        /// <inheritdoc cref="DbContext.AttachRange(object[])"/>
        void AttachRange([NotNull] params object[] entities);

        /// <inheritdoc cref="DbContext.AttachRange(IEnumerable{object})"/>
        void AttachRange([NotNull] IEnumerable<object> entities);

        /// <inheritdoc cref="DbContext.Add"/>
        EntityEntry<TEntity> Add<TEntity>([NotNull] TEntity entity)
            where TEntity : class;

        /// <inheritdoc cref="DbContext.AddRange(object[])"/>
        void AddRange([NotNull] params object[] entities);

        /// <inheritdoc cref="DbContext.AddRange(IEnumerable{object})"/>
        void AddRange([NotNull] IEnumerable<object> entities);

        /// <inheritdoc cref="DbContext.Update"/>
        EntityEntry<TEntity> Update<TEntity>([NotNull] TEntity entity)
            where TEntity : class;

        /// <inheritdoc cref="DbContext.UpdateRange(object[])"/>
        void UpdateRange([NotNull] params object[] entities);

        /// <inheritdoc cref="DbContext.UpdateRange(IEnumerable{object})"/>
        void UpdateRange([NotNull] IEnumerable<object> entities);

        /// <inheritdoc cref="DbContext.Remove"/>
        EntityEntry<TEntity> Remove<TEntity>([NotNull] TEntity entity)
            where TEntity : class;

        /// <inheritdoc cref="DbContext.RemoveRange(object[])"/>
        void RemoveRange([NotNull] params object[] entities);

        /// <inheritdoc cref="DbContext.RemoveRange(IEnumerable{object})"/>
        void RemoveRange([NotNull] IEnumerable<object> entities);

        /// <inheritdoc cref="DbContext.SaveChangesAsync(CancellationToken)"/>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        #endregion
    }
}
