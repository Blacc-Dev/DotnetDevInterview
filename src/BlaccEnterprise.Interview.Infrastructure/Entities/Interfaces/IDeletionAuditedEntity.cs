using System;

namespace BlaccEnterprise.Interview.Infrastructure.Entities.Interfaces
{
    public interface IDeletionAuditedEntity
    {
        int? DeletedBy { get; set; }
        DateTime? DeletionDateTime { get; set; }
        string DeletedUserIpAddress { get; set; }
    }
}