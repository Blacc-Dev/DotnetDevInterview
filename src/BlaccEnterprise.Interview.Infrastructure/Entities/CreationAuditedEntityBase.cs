using System;

using BlaccEnterprise.Interview.Infrastructure.Entities.Interfaces;

namespace BlaccEnterprise.Interview.Infrastructure.Entities
{
    public abstract class CreationAuditedEntityBase : EntityBase, ICreationAuditedEntity
    {
        public virtual int? CreatedBy { get; set; }
        public virtual DateTime? CreationDateTime { get; set; }
        public virtual string CreatedUserIpAddress { get; set; }
    }
}