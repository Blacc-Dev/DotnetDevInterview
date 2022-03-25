using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Extensions
{
    public static class EntityEntryExtensions
    {
        public static bool CheckOwnedEntityChange(this EntityEntry entry)
        {
            return entry.State == EntityState.Modified ||
                   entry.References.Any(r =>
                       r.TargetEntry != null && r.TargetEntry.Metadata.IsOwned() && CheckOwnedEntityChange(r.TargetEntry));
        }
    }
}
