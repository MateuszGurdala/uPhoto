using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Contracts;

namespace uPhoto.Common.Models.Entities;

[PrimaryKey(nameof(this.Id))]
public class UserAccount : IEntity<Guid>
{
    public Guid Id { get; set; }

    public byte AccountTypeId { get; set; }

    [MaxLength(255)] public string Email { get; init; }
    [MaxLength(64)] public string Password { get; init; }
    public DateTime RegisteredOn { get; init; }
    public DateTime LastSeenOn { get; init; }

    public string? Name { get; set; }
    public string? Surname { get; set; }

    public virtual AccountType AccountType { get; set; }
    public virtual IEnumerable<UserAlbumAccess> UserAlbumAccesses { get; set; }
}
