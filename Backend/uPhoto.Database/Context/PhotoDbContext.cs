using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Models.Entities;
using uPhoto.Database.Contracts;

namespace uPhoto.Database.Context;

public class PhotoDbContext : DbContextBase, IPhotoDbContext
{
	public DbSet<Photo> Photo { get; set; }
	public DbSet<Tag> Tag { get; set; }
	public DbSet<MimeType> MimeType { get; set; }
	public DbSet<PhotoTag> PhotoTag { get; set; }

	public PhotoDbContext(DbContextOptions<DbContextBase> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		OnPhotoModelCreating(modelBuilder);
		OnTagModelCreating(modelBuilder);
		OnMimeTypeModelCreating(modelBuilder);
		OnPhotoTagModelCreating(modelBuilder);

		base.OnModelCreating(modelBuilder);
	}

	private void OnPhotoModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Photo>()
			.HasMany(e => e.PhotoTags)
			.WithOne(e => e.Photo);

		modelBuilder.Entity<Photo>()
			.HasOne(e => e.MimeType)
			.WithMany(e => e.Photos)
			.HasForeignKey(e => e.MimeTypeId)
			.IsRequired();

		modelBuilder.Entity<Photo>()
			.HasOne(e => e.Album)
			.WithMany(e => e.Photos)
			.HasForeignKey(e => e.AlbumId)
			.IsRequired();

		modelBuilder.Entity<Photo>()
			.HasOne(e => e.GeographicalLocation)
			.WithMany(e => e.Photos);
	}

	private void OnTagModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Tag>()
			.HasMany(e => e.PhotoTags)
			.WithOne(e => e.Tag);
	}

	private void OnMimeTypeModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<MimeType>()
			.HasMany(e => e.Photos)
			.WithOne(e => e.MimeType);
	}

	private void OnPhotoTagModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<PhotoTag>()
			.HasOne(e => e.Tag)
			.WithMany(e => e.PhotoTags)
			.HasForeignKey(e => e.TagId)
			.IsRequired();

		modelBuilder.Entity<PhotoTag>()
			.HasOne(e => e.Photo)
			.WithMany(e => e.PhotoTags)
			.HasForeignKey(e => e.PhotoId)
			.IsRequired();
	}
}