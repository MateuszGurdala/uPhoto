using System.ComponentModel.DataAnnotations;
using uPhoto.Common.Contracts;

namespace uPhoto.Common.Models.Entities;

public class Album : IEntity<long>, ICreatableEntity
{
    public long Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid CreatedBy { get; set; }

    public string Name { get; set; }
    public bool IsShared { get; set; }

    public string? Description { get; set; }

    public virtual IEnumerable<Photo> Photos { get; set; }
    public virtual IEnumerable<UserAlbumAccess> UserAlbumAccesses { get; set; }
}