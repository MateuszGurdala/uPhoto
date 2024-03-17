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
	private const string _connectionStringSection = "ConnectionStrings:uPhotoMD";

	public static void ConfigureServices(this WebApplicationBuilder builder)
	{
		builder.Services
			.AddSession()
			.AddAuth()
			.AddMediator()
			.AddDbContextOptions(builder.Configuration)
			.AddCommandValidators()
			.AddServices()
			.AddCors();
	}

	private static IServiceCollection AddDbContextOptions(this IServiceCollection serviceCollection, IConfiguration configurationManager)
	{
		if (configurationManager.GetValue<string?>(_connectionStringSection) is { } connectionString)
		{
			serviceCollection.AddDbContext<DbContextBase>(options => { options.UseSqlServer(connectionString); });
		}
		else
		{
			throw new NoNullAllowedException("Connection string was not provided in ConnectionStrings section.");
		}

		return serviceCollection;
	}

	private static IServiceCollection AddServices(this IServiceCollection serviceCollection)
	{
		serviceCollection
			.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

		serviceCollection
			.AddScoped<IUserAccountDbContext, UserAccountDbContext>()
			.AddScoped<IAlbumDbContext, AlbumDbContext>()
			.AddScoped<IGeographicalLocationDbContext, GeographicalLocationDbContext>()
			.AddScoped<IPhotoDbContext, PhotoDbContext>();

		return serviceCollection;
	}

	private static IServiceCollection AddCommandValidators(this IServiceCollection serviceCollection)
	{
		return serviceCollection
			.AddFluentValidationAutoValidation()
			.AddValidatorsFromAssemblyContaining<CreateUserAccountCommandValidator>();
	}

	private static IServiceCollection AddMediator(this IServiceCollection serviceCollection)
	{
		return serviceCollection.AddMediatR(config => { config.RegisterServicesFromAssemblyContaining<CreateUserAccountCommandHandler>(); });
	}

	private static IServiceCollection AddSession(this IServiceCollection serviceCollection)
	{
		return serviceCollection
			.AddDistributedMemoryCache()
			.AddSession(config =>
			{
				config.IdleTimeout = TimeSpan.FromSeconds(30); //Server Cache Timeout
				config.Cookie.MaxAge = TimeSpan.FromMinutes(10);
				config.Cookie.HttpOnly = true;
				config.Cookie.IsEssential = true;
				config.Cookie.Name = ".uPhoto.Session";
			});
	}

	private static IServiceCollection AddCors(this IServiceCollection serviceCollection)
	{
		return serviceCollection
			.AddCors(config =>
			{
				config.AddDefaultPolicy(
					builder => builder
						.WithOrigins("http://localhost:4200")
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials()
						.Build()
				);
			});
	}
}
