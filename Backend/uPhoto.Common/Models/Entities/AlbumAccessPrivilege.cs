using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Contracts;

namespace uPhoto.Common.Models.Entities;

[PrimaryKey(nameof(this.PrivilegeId), nameof(this.AlbumId), nameof(this.UserAccountId))]
public class AlbumAccessPrivilege : IEntity
{
    public byte PrivilegeId { get; set; }
    public long AlbumId { get; set; }
    public Guid UserAccountId { get; set; }

    public virtual Privilege Privilege { get; set; } = null!;
    public virtual UserAlbumAccess UserAlbumAccess { get; set; } = null!;
}