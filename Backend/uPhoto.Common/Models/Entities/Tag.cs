using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Contracts;

namespace uPhoto.Common.Models.Entities;

[PrimaryKey(nameof(this.Id))]
public class Tag : IEntity<long>
{
    public long Id { get; set; }

    [MaxLength(30)] public string Value { get; set; }

    public virtual IEnumerable<PhotoTag> PhotoTags { get; set; }
}