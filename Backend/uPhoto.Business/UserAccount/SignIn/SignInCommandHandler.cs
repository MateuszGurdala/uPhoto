﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Constants;
using uPhoto.Common.Contracts;
using uPhoto.Common.Models;
using uPhoto.Database.Contracts;

namespace uPhoto.Business.UserAccount.SignIn;

public class SignInCommandHandler(IUserAccountDbContext context, IHttpContextAccessor httpContextAccessor) : IApiResponseRequestHandler<SignInCommand, SignInCommandResponse>
{
	private static readonly AuthenticationProperties _authenticationProperties = new()
	{
		AllowRefresh = true,
		ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
		IssuedUtc = DateTimeOffset.UtcNow,
	};

	public async Task<ApiResponse<SignInCommandResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
	{
		string userAccountType = await context.UserAccount
			.Include(ua => ua.AccountType)
			.Where(ua => ua.Email == request.Email)
			.Select(ua => ua.AccountType.Type)
			.FirstAsync(cancellationToken);

		httpContextAccessor.HttpContext!.Session.SetString(SessionKeys.Email, request.Email);

		await httpContextAccessor.HttpContext!.SignInAsync(
			CookieAuthenticationDefaults.AuthenticationScheme,
			CreateClaimsIdentity(request.Email, userAccountType),
			_authenticationProperties);

		return ApiResponse<SignInCommandResponse>.Success();
	}

	private static ClaimsPrincipal CreateClaimsIdentity(string email, string accountType)
	{
		var claims = new List<Claim>
		{
			new(CustomClaims.Email, email),
			new(CustomClaims.AccountType, accountType)
		};

		return new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
	}
}
