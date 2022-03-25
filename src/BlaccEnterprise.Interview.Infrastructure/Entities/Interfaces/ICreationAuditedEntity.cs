using System;

namespace BlaccEnterprise.Interview.Infrastructure.Entities.Interfaces
{
    public interface ICreationAuditedEntity
    {
        int? CreatedBy { get; set; }
        DateTime? CreationDateTime { get; set; }
        string CreatedUserIpAddress { get; set; }
    }
}