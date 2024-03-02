using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Contracts;

namespace uPhoto.Common.Models.Entities;

[PrimaryKey(nameof(this.Id))]
public class MimeType : IEntity<byte>
{
    public byte Id { get; set; }

    [MaxLength(35)] public string Name { get; set; }

    public virtual IEnumerable<Photo> Photos { get; set; }
}