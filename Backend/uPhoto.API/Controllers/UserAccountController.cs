using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uPhoto.API.Extensions;
using uPhoto.Business.UserAccount.CreateUserAccount;
using uPhoto.Business.UserAccount.SignIn;
using uPhoto.Business.UserAccount.SignOut;
using uPhoto.Common.Models;
using uPhoto.Database.Contracts;

namespace uPhoto.API.Controllers;

[ApiController]
public class UserAccountController(IUserAccountDbContext userAccountDbContext, IMediator mediator)
{
	[HttpPut("create-account")]
	[AllowAnonymous]
	[ProducesResponseType<ApiResponse<CreateUserAccountCommandResponse>>(StatusCodes.Status200OK)]
	public async Task<IResult> CreateAccount(CreateUserAccountCommand command, CancellationToken cancellationToken)
	{
		return Results.Ok(await mediator.Send(command, cancellationToken));
	}

	[HttpPost("sign-in")]
	[Authorize(Policy = nameof(Policies.Unauthenticated))]
	[ProducesResponseType<ApiResponse<SignInCommandResponse>>(StatusCodes.Status200OK)]
	public async Task<IResult> SignIn(SignInCommand command, CancellationToken cancellationToken)
	{
		return Results.Ok(await mediator.Send(command, cancellationToken));
	}

	[HttpPost("sign-out")]
	[ProducesResponseType<ApiResponse<SignOutCommandResponse>>(StatusCodes.Status200OK)]
	public async Task<IResult> SignOut(SignOutCommand command, CancellationToken cancellationToken)
	{
		return Results.Ok(await mediator.Send(command, cancellationToken));
	}
}
