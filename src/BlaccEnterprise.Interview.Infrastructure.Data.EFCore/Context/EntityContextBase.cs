using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

using BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Extensions;
using BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Helpers;
using BlaccEnterprise.Interview.Infrastructure.Entities.Interfaces;
using BlaccEnterprise.Interview.Infrastructure.Extensions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Context
{
    public class EntityContextBase<TContext> : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int> where TContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private static MethodInfo ConfigureGlobalFiltersMethodInfo = typeof(EntityContextBase<TContext>).GetMethod(nameof(ConfigureGlobalFilters), BindingFlags.Instance | BindingFlags.NonPublic);

        public EntityContextBase(DbContextOptions<TContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                ConfigureGlobalFiltersMethodInfo
                    .MakeGenericMethod(entityType.ClrType)
                    .Invoke(this, new object[] { modelBuilder, entityType });
            }
        }

        protected void ConfigureGlobalFilters<TEntity>(ModelBuilder modelBuilder, IMutableEntityType entityType)
           where TEntity : class
        {
            if (entityType.BaseType == null && typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                var filterExpression = CreateSoftDeleteFilterExpression<TEntity>();
                if (filterExpression != null)
                    modelBuilder.Entity<TEntity>().HasQueryFilter(filterExpression);
            }
        }

        protected virtual Expression<Func<TEntity, bool>> CreateSoftDeleteFilterExpression<TEntity>()
            where TEntity : class
        {
            Expression<Func<TEntity, bool>> expression = null;

            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                Expression<Func<TEntity, bool>> softDeleteFilter = e => !((ISoftDelete)e).IsDeleted;
                expression = expression == null ? softDeleteFilter : CombineExpressions(expression, softDeleteFilter);
            }

            return expression;
        }

        protected virtual Expression<Func<T, bool>> CombineExpressions<T>(Expression<Func<T, bool>> exp1, Expression<Func<T, bool>> exp2)
        {
            return ExpressionHelper.CombineExpression(exp1, exp2);
        }

        public override int SaveChanges()
        {
            ApplyAudit();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ApplyAudit();

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected virtual void ApplyAudit()
        {
            if (_httpContextAccessor.HttpContext == null)
                return;

            var user = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = 0;

            if (user != null)
                userId = int.Parse(user.Value);

            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            foreach (var entry in ChangeTracker.Entries().ToList())
            {
                if (entry.State != EntityState.Modified && entry.CheckOwnedEntityChange())
                    Entry(entry.Entity).State = EntityState.Modified;

                ApplyAudit(entry, userId, ipAddress);
            }
        }

        protected virtual void ApplyAudit(EntityEntry entry, int? userId, string ipAddress)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    ApplyAuditForAddedEntity(entry, userId, ipAddress);
                    break;
                case EntityState.Modified:
                    ApplyAuditForModifiedEntity(entry, userId, ipAddress);
                    break;
                case EntityState.Deleted:
                    ApplyAuditForDeletedEntity(entry, userId, ipAddress);
                    break;
            }
        }

        protected virtual void ApplyAuditForAddedEntity(EntityEntry entry, int? userId, string ipAddress)
        {
            AuditingPropertiesHelper.SetCreationAuditProperties(entry.Entity, userId, ipAddress);
        }

        protected virtual void ApplyAuditForModifiedEntity(EntityEntry entry, int? userId, string ipAddress)
        {
            AuditingPropertiesHelper.SetModificationAuditProperties(entry.Entity, userId, ipAddress);
            if (entry.Entity is ISoftDelete && entry.Entity.As<ISoftDelete>().IsDeleted)
                AuditingPropertiesHelper.SetDeletionAuditProperties(entry.Entity, userId, ipAddress);
        }

        protected virtual void ApplyAuditForDeletedEntity(EntityEntry entry, int? userId, string ipAddress)
        {
            CancelDeletionForSoftDelete(entry);
            AuditingPropertiesHelper.SetDeletionAuditProperties(entry.Entity, userId, ipAddress);
        }

        protected virtual void CancelDeletionForSoftDelete(EntityEntry entry)
        {
            if (!(entry.Entity is ISoftDelete))
                return;

            entry.Reload();
            entry.State = EntityState.Modified;
            entry.Entity.As<ISoftDelete>().IsDeleted = true;
        }
    }
}
