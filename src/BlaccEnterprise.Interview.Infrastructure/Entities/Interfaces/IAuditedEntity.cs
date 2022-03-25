namespace BlaccEnterprise.Interview.Infrastructure.Entities.Interfaces
{
    public interface IAuditedEntity : ICreationAuditedEntity, IModifiedAuditedEntity
    {
    }
}