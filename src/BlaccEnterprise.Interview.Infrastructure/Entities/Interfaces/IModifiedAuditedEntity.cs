using System;

namespace BlaccEnterprise.Interview.Infrastructure.Entities.Interfaces
{
    public interface IModifiedAuditedEntity
    {
        int? ModifiedBy { get; set; }
        DateTime? ModificationDateTime { get; set; }
        string ModifiedUserIpAddress { get; set; }
    }
}