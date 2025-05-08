using System.ComponentModel.DataAnnotations;

namespace OAuthSystem.Data.Entities.Shared
{
    public class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }

    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }

    public class BaseAuditableEntity<TKey> : BaseEntity<TKey>, IAuditableEntity
    {
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class BaseAuditableEntity : BaseEntity, IAuditableEntity
    {
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
