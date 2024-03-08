using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uPhoto.Business.UserAccount.CreateUserAccount;
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
}
