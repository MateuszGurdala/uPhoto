using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Models.Entities;

namespace uPhoto.Database.Contracts;

public interface IAlbumDbContext: IDbContextBase
{
	public DbSet<Album> Album { get; set; }
	public DbSet<Privilege> Privilege { get; set; }
	public DbSet<UserAlbumAccess> UserAlbumAccess { get; set; }
	public DbSet<AlbumAccessPrivilege> AlbumAccessPrivilege { get; set; }
}
