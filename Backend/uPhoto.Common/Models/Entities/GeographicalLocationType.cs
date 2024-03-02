using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Contracts;

namespace uPhoto.Common.Models.Entities;

[PrimaryKey(nameof(this.Id))]
public class GeographicalLocationType : IEntity<byte>
{
    public byte Id { get; set; }

    [MaxLength(10)] public string Type { get; set; }

    public virtual IEnumerable<GeographicalLocation> GeographicalLocations { get; set; }
}