using System;

using BlaccEnterprise.Interview.Infrastructure.Entities.Interfaces;

namespace BlaccEnterprise.Interview.Infrastructure.Entities
{
    public abstract class FullAuditedEntityBase : AuditedEntityBase, IFullAuditedEntity, ISoftDelete
    {
        public virtual bool IsDeleted { get; set; }
        public virtual int? DeletedBy { get; set; }
        public virtual DateTime? DeletionDateTime { get; set; }
        public virtual string DeletedUserIpAddress { get; set; }
    }
}
