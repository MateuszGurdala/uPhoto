using Microsoft.EntityFrameworkCore;
using System.Data;
using uPhoto.Database.Context;
using uPhoto.Database.Contracts;

namespace uPhoto.API.Extensions;

public static class ServiceCollectionExtensions
{
	private const string connectionStringSection = "ConnectionStrings:uPhotoMD";

	public static IServiceCollection AddDbContextOptions(this IServiceCollection serviceCollection,
		ConfigurationManager configurationManager)
	{
		if (configurationManager.GetValue<string?>(connectionStringSection) is { } connectionString)
		{
			serviceCollection.AddDbContext<DbContextBase>(options => { options.UseSqlServer(connectionString); });
		}
		else
		{
			throw new NoNullAllowedException("Connection string was not provided in ConnectionStrings section.");
		}

		return serviceCollection;
	}

	public static IServiceCollection InjectServices(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddScoped<IUserAccountDbContext, UserAccountDbContext>();
		serviceCollection.AddScoped<IAlbumDbContext, AlbumDbContext>();
		serviceCollection.AddScoped<IGeographicalLocationDbContext, GeographicalLocationDbContext>();
		serviceCollection.AddScoped<IPhotoDbContext, PhotoDbContext>();

		return serviceCollection;
	}
}