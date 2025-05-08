using System.ComponentModel.DataAnnotations.Schema;
using OAuthSystem.Data.Entities.Shared;

namespace OAuthSystem.Data.Entities;

[Table("ApplicationCodes")]
public class ApplicationCode : BaseEntity
{
    public required string Code { get; set; }
    public required string IssueReason { get; set; }
    public required DateTime ExpiredAt { get; set; }
}
