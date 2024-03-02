using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Contracts;

namespace uPhoto.Common.Models.Entities;

[PrimaryKey(nameof(this.UserAccountId), nameof(this.AlbumId))]
public class UserAlbumAccess : IEntity, ICreatableEntity
{
    public Guid UserAccountId { get; set; }
    public long AlbumId { get; set; }

    public DateTime CreatedOn { get; set; }
    public Guid CreatedBy { get; set; }

    public virtual UserAccount UserAccount { get; set; }
    public virtual Album Album { get; set; }
    public virtual IEnumerable<AlbumAccessPrivilege> AlbumAccessPrivileges { get; set; }
}