using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Models.Entities;
using uPhoto.Database.Contracts;

namespace uPhoto.Database.Context;

public class AlbumDbContext : DbContextBase, IAlbumDbContext
{
	public DbSet<Album> Album { get; set; }
	public DbSet<Privilege> Privilege { get; set; }
	public DbSet<UserAlbumAccess> UserAlbumAccess { get; set; }
	public DbSet<AlbumAccessPrivilege> AlbumAccessPrivilege { get; set; }

	public AlbumDbContext(DbContextOptions<DbContextBase> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		OnAlbumModelCreating(modelBuilder);
		OnPrivilegeModelCreating(modelBuilder);
		OnUserAlbumAccessModelCreating(modelBuilder);
		OnAlbumAccessPrivilegeModelCreating(modelBuilder);

		base.OnModelCreating(modelBuilder);
	}

	private void OnAlbumModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Album>()
			.HasMany(e => e.Photos)
			.WithOne(e => e.Album);

		modelBuilder.Entity<Album>()
			.HasMany(e => e.UserAlbumAccesses)
			.WithOne(e => e.Album);
	}

	private void OnPrivilegeModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Privilege>()
			.HasMany(e => e.AlbumAccessPrivileges)
			.WithOne(e => e.Privilege);
	}

	private void OnUserAlbumAccessModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<UserAlbumAccess>()
			.HasOne(e => e.Album)
			.WithMany(e => e.UserAlbumAccesses)
			.HasForeignKey(e => e.AlbumId)
			.IsRequired();

		modelBuilder.Entity<UserAlbumAccess>()
			.HasOne(e => e.UserAccount)
			.WithMany(e => e.UserAlbumAccesses)
			.HasForeignKey(e => e.UserAccountId)
			.IsRequired();

		modelBuilder.Entity<UserAlbumAccess>()
			.HasMany(e => e.AlbumAccessPrivileges)
			.WithOne(e => e.UserAlbumAccess);
	}

	private void OnAlbumAccessPrivilegeModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<AlbumAccessPrivilege>()
			.HasOne(e => e.Privilege)
			.WithMany(e => e.AlbumAccessPrivileges)
			.HasForeignKey(e => e.PrivilegeId)
			.IsRequired();

		modelBuilder.Entity<AlbumAccessPrivilege>()
			.HasOne(e => e.UserAlbumAccess)
			.WithMany(e => e.AlbumAccessPrivileges)
			.HasForeignKey(e => new { e.UserAccountId, e.AlbumId })
			.IsRequired();
	}
}