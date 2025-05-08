namespace OAuthSystem.Data.Entities.Shared
{
    public interface IAuditableEntity
    {
        long CreatedBy { get; set; }
        DateTime CreatedAt { get; set; }
        long UpdatedBy { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
