using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Models.Entities;
using uPhoto.Database.Contracts;

namespace uPhoto.Database.Context;

public class GeographicalLocationDbContext : DbContextBase, IGeographicalLocationDbContext
{
	public virtual DbSet<GeographicalLocation> GeographicalLocation { get; set; }
	public virtual DbSet<GeographicalLocationType> GeographicalLocationType { get; set; }

	public GeographicalLocationDbContext(DbContextOptions<DbContextBase> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		OnGeographicalLocationModelCreating(modelBuilder);
		OnGeographicalLocationTypeModelCreating(modelBuilder);

		base.OnModelCreating(modelBuilder);
	}

	private void OnGeographicalLocationModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<GeographicalLocation>()
			.HasOne(e => e.LocationType)
			.WithMany(e => e.GeographicalLocations)
			.HasForeignKey(e => e.LocationTypeId)
			.IsRequired();

		modelBuilder.Entity<GeographicalLocation>()
			.HasOne(e => e.HigherTierLocation)
			.WithMany(e => e.LowerTierLocations)
			.HasForeignKey(e => e.ParentId);

		modelBuilder.Entity<GeographicalLocation>()
			.HasMany(e => e.Photos)
			.WithOne(e => e.GeographicalLocation);
	}

	private void OnGeographicalLocationTypeModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<GeographicalLocationType>()
			.HasMany(e => e.GeographicalLocations)
			.WithOne(e => e.LocationType);
	}
}