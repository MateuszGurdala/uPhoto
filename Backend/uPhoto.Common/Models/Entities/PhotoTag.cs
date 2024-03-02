using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Contracts;

namespace uPhoto.Common.Models.Entities;

[PrimaryKey(nameof(this.PhotoId), nameof(this.TagId))]
public class PhotoTag : IEntity, ICreatableEntity
{
    public long PhotoId { get; set; }
    public long TagId { get; set; }

    public DateTime CreatedOn { get; set; }
    public Guid CreatedBy { get; set; }

    public virtual Tag Tag { get; set; }
    public virtual Photo Photo { get; set; }
}