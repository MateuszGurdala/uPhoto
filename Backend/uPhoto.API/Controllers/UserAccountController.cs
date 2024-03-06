using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using uPhoto.Business.UserAccount.CreateUserAccount;
using uPhoto.Common.Models;
using uPhoto.Common.Models.Entities;
using uPhoto.Database.Contracts;

namespace uPhoto.API.Controllers;

[ApiController]
public class UserAccountController(IUserAccountDbContext userAccountDbContext, IMediator mediator)
{
	[HttpGet("account-types")]
	public async Task<IEnumerable<AccountType>> GetAccountTypes(CancellationToken cancellationToken)
	{
		return await userAccountDbContext.AccountType.ToListAsync(cancellationToken);
	}

	[HttpGet("user-accounts")]
	public async Task<IEnumerable<UserAccount>> GetUserAccountsTypes(CancellationToken cancellationToken)
	{
		return await userAccountDbContext.UserAccount.ToListAsync(cancellationToken);
	}

	[HttpPut("create-account")]
	[AllowAnonymous]
	[ProducesResponseType<ApiResponse<CreateUserAccountCommandResponse>>(StatusCodes.Status200OK)]
	public async Task<ApiResponse<CreateUserAccountCommandResponse>> CreateAccount(CreateUserAccountCommand command, CancellationToken cancellationToken)
	{
		return await mediator.Send(command, cancellationToken);
	}
}
