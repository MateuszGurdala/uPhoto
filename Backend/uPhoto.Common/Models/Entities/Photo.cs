using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Contracts;

namespace uPhoto.Common.Models.Entities;

[PrimaryKey(nameof(this.Id))]
public class Photo : IEntity<long>, ICreatableEntity
{
    public long Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid CreatedBy { get; set; }

    public long AlbumId { get; set; }
    public byte MimeTypeId { get; set; }

    public long? LocationId { get; set; }

    public string Title { get; set; }
    [MaxLength(255)] public string SourceFileName { get; set; }
    public byte Source { get; set; }
    public byte PreviewSource { get; set; }
    public int Size { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public DateTime DateTaken { get; set; }
    public bool IsFavorite { get; set; }

    public virtual Album Album { get; set; }
    public virtual MimeType MimeType { get; set; }
    public virtual GeographicalLocation? GeographicalLocation { get; set; }
    public virtual IEnumerable<PhotoTag> PhotoTags { get; set; }
}