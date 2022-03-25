using System;

using BlaccEnterprise.Interview.Infrastructure.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Extensions
{
    public static class ChangeTrackerExtensions
    {
        public static void ApplyAuditInformation(this ChangeTracker changeTracker)
        {
            foreach (var entry in changeTracker.Entries())
            {
                if (!(entry.Entity is AuditedEntityBase baseAudit)) continue;

                var now = DateTime.UtcNow;
                switch (entry.State)
                {
                    case EntityState.Modified:
                        baseAudit.ModificationDateTime = now;
                        break;

                    case EntityState.Added:
                        baseAudit.CreationDateTime = now;
                        break;
                }
            }
        }
    }
}
