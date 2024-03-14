using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using uPhoto.Common.Constants;

namespace uPhoto.API.Extensions;

public static class AuthExtensions
{
	private static readonly Func<RedirectContext<CookieAuthenticationOptions>, Task> _handleBadRequestFunc = context =>
	{
		context.HttpContext.Response.StatusCode = 400;
		return Task.CompletedTask;
	};

	public static IServiceCollection AddAuth(this IServiceCollection serviceCollection)
	{
		return serviceCollection
			.AddAuthentication()
			.AddAuthorization();
	}

	private static IServiceCollection AddAuthentication(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			.AddCookie(options =>
			{
				options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
				options.SlidingExpiration = true;
				options.Events.OnRedirectToAccessDenied = _handleBadRequestFunc;
				options.Events.OnRedirectToLogin = _handleBadRequestFunc;
			});

		return serviceCollection;
	}

	private static IServiceCollection AddAuthorization(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddAuthorizationBuilder()
			.AddPolicies()
			.SetFallbackPolicy(new AuthorizationPolicyBuilder()
				.RequireAuthenticatedUser()
				.RequireClaim(CustomClaims.AccountType, AccountTypes.User)
				.Build());

		return serviceCollection;
	}
}
