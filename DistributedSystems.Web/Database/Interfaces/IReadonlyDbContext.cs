using System;
using System.Diagnostics.CodeAnalysis;
using DistributedSystems.Web.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DistributedSystems.Web.Database.Interfaces
{
    public interface IReadonlyDbContext : IAsyncDisposable, IDisposable
    {
        DbSet<Link> Links { get; }

        #region DbContext Properties & Methods

        /// <inheritdoc cref="DbContext.Set{T}()"/>
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        /// <inheritdoc cref="DbContext.Set{T}(string)"/>
        DbSet<TEntity> Set<TEntity>([NotNull] string name)
            where TEntity : class;

        /// <inheritdoc cref="DbContext.Entry"/>
        EntityEntry<TEntity> Entry<TEntity>([NotNull] TEntity entity)
            where TEntity : class;

        /// <inheritdoc cref="DbContext.Model"/>
        IModel Model { get; }

        /// <inheritdoc cref="DbContext.ContextId"/>
        DbContextId ContextId { get; }

        /// <inheritdoc cref="DbContext.Database"/>
        DatabaseFacade Database { get; }

        #endregion
    }
}