using System;

using BlaccEnterprise.Interview.Infrastructure.Entities.Interfaces;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Helpers
{
    public static class AuditingPropertiesHelper
    {
        public static void SetCreationAuditProperties(object entityAsObj, int? userId, string ipAddress)
        {
            if (entityAsObj is not ICreationAuditedEntity entity)
                return;

            if (!userId.HasValue)
                return;

            if (entity.CreationDateTime == default)
                entity.CreationDateTime = DateTime.Now;

            if (entity.CreatedBy != null)
                return;

            entity.CreatedBy = userId;

            if (entity.CreatedUserIpAddress != null)
                return;

            entity.CreatedUserIpAddress = ipAddress;
        }

        public static void SetModificationAuditProperties(object entityAsObj, int? userId, string ipAddress)
        {
            if (entityAsObj is not IModifiedAuditedEntity entity)
                return;

            if (!userId.HasValue)
                return;

            if (entity.ModificationDateTime == default)
                entity.ModificationDateTime = DateTime.Now;

            if (entity.ModifiedBy != null)
                return;

            entity.ModifiedBy = userId;

            if (entity.ModifiedUserIpAddress != null)
                return;

            entity.ModifiedUserIpAddress = ipAddress;
        }

        public static void SetDeletionAuditProperties(object entityAsObj, int? userId, string ipAddress)
        {
            if (entityAsObj is not IDeletionAuditedEntity entity)
                return;

            if (!userId.HasValue)
                return;

            if (entity.DeletionDateTime == default)
                entity.DeletionDateTime = DateTime.Now;

            if (entity.DeletedBy != null)
                return;

            entity.DeletedBy = userId;

            if (entity.DeletedUserIpAddress != null)
                return;

            entity.DeletedUserIpAddress = ipAddress;
        }
    }
}
