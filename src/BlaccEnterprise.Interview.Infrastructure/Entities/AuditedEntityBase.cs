using System;

using BlaccEnterprise.Interview.Infrastructure.Entities.Interfaces;

namespace BlaccEnterprise.Interview.Infrastructure.Entities
{
    public abstract class AuditedEntityBase : CreationAuditedEntityBase, IAuditedEntity
    {
        public virtual int? ModifiedBy { get; set; }
        public virtual DateTime? ModificationDateTime { get; set; }
        public virtual string ModifiedUserIpAddress { get; set; }
    }
}