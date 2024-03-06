using Microsoft.EntityFrameworkCore;
using System.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using uPhoto.Business.UserAccount.CreateUserAccount;
using uPhoto.Database.Context;
using uPhoto.Database.Contracts;

namespace uPhoto.API.Extensions;

public static class ServiceCollectionExtensions
{
	private const string connectionStringSection = "ConnectionStrings:uPhotoMD";

	public static void ConfigureServices(this WebApplicationBuilder builder)
	{
		builder.Services
			.AddMediatR(config =>
			{
				config.RegisterServicesFromAssemblyContaining<CreateUserAccountCommandHandler>();
			})
			.AddDbContextOptions(builder.Configuration)
			.AddCommandValidators()
			.InjectServices();
	}

	private static IServiceCollection AddDbContextOptions(this IServiceCollection serviceCollection, IConfiguration configurationManager)
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

	private static IServiceCollection InjectServices(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

		serviceCollection.AddScoped<IUserAccountDbContext, UserAccountDbContext>();
		serviceCollection.AddScoped<IAlbumDbContext, AlbumDbContext>();
		serviceCollection.AddScoped<IGeographicalLocationDbContext, GeographicalLocationDbContext>();
		serviceCollection.AddScoped<IPhotoDbContext, PhotoDbContext>();

		return serviceCollection;
	}

	private static IServiceCollection AddCommandValidators(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddFluentValidationAutoValidation();
		serviceCollection.AddValidatorsFromAssemblyContaining<CreateUserAccountCommandValidator>();

		return serviceCollection;
	}
}
