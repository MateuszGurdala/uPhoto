using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Models.Entities;

namespace uPhoto.Database.Contracts;

public interface IPhotoDbContext: IDbContextBase
{
	public DbSet<Photo> Photo { get; set; }
	public DbSet<Tag> Tag { get; set; }
	public DbSet<MimeType> MimeType { get; set; }
	public DbSet<PhotoTag> PhotoTag { get; set; }
}
