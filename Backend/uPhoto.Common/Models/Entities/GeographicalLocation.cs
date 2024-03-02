using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Contracts;

namespace uPhoto.Common.Models.Entities;

[PrimaryKey(nameof(this.Id))]
public class GeographicalLocation : IEntity<long>, ICreatableEntity
{
	public long Id { get; set; }
	public DateTime CreatedOn { get; set; }
	public Guid CreatedBy { get; set; }

	public byte LocationTypeId { get; set; }
	public long ParentId { get; set; }

	public string Name { get; set; }
	public bool IsPublic { get; set; }

	public int? Latitude { get; set; }
	public int? Longitude { get; set; }
	public string? Description { get; set; }

	public virtual GeographicalLocationType LocationType { get; set; }
	public virtual GeographicalLocation HigherTierLocation { get; set; }
	public virtual IEnumerable<GeographicalLocation> LowerTierLocations { get; set; }
	public virtual IEnumerable<Photo> Photos { get; set; }
}