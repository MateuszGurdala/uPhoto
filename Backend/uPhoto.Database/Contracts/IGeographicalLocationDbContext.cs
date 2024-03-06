using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Models.Entities;

namespace uPhoto.Database.Contracts;

public interface IGeographicalLocationDbContext: IDbContextBase
{
	public DbSet<GeographicalLocation> GeographicalLocation { get; set; }
	public DbSet<GeographicalLocationType> GeographicalLocationType { get; set; }
}
