using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Models.Entities;
using uPhoto.Database.Contracts;

namespace uPhoto.API.Controllers;

public class PhotoController(IPhotoDbContext photoDbContext)
{
	[HttpGet("photos")]
	public async Task<IEnumerable<Photo>> GetPhotos(CancellationToken cancellationToken)
	{
		return await photoDbContext.Photo.ToListAsync(cancellationToken);
	}

	[HttpGet("tags")]
	public async Task<IEnumerable<Tag>> GetTags(CancellationToken cancellationToken)
	{
		return await photoDbContext.Tag.ToListAsync(cancellationToken);
	}

	[HttpGet("mime-types")]
	public async Task<IEnumerable<MimeType>> GetMimeTypes(CancellationToken cancellationToken)
	{
		return await photoDbContext.MimeType.ToListAsync(cancellationToken);
	}

	[HttpGet("photo-tags")]
	public async Task<IEnumerable<PhotoTag>> GetPhotoTags(CancellationToken cancellationToken)
	{
		return await photoDbContext.PhotoTag.ToListAsync(cancellationToken);
	}
}