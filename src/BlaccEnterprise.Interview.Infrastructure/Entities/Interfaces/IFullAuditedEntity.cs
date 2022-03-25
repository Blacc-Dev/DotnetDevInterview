using System;

namespace BlaccEnterprise.Interview.Infrastructure.Entities.Interfaces
{
    public interface IFullAuditedEntity : IAuditedEntity, IDeletionAuditedEntity
    {
    }
}