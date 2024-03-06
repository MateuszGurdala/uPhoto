using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using uPhoto.Common.Constants;
using uPhoto.Common.Contracts;
using uPhoto.Common.Models;
using uPhoto.Common;
using uPhoto.Database.Contracts;
// ReSharper disable ClassNeverInstantiated.Global

namespace uPhoto.Business.UserAccount.CreateUserAccount;

public record CreateUserAccountCommand(string Email, string Password) : IResultRequest<CreateUserAccountCommandResponse>;

public record CreateUserAccountCommandResponse;

public class CreateUserAccountCommandHandler(IUserAccountDbContext context)
	: IResultRequestHandler<CreateUserAccountCommand, CreateUserAccountCommandResponse>
{
	public async Task<ApiResponse<CreateUserAccountCommandResponse>> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
	{
		var userAccount = new Common.Models.Entities.UserAccount
		{
			Email = request.Email,
			Password = Helpers.CalculateHash(request.Password),
			AccountTypeId = (await context.AccountType.SingleAsync(at => at.Type == AccountTypes.User, cancellationToken)).Id,
			RegisteredOn = DateTime.Now,
			LastSeenOn = DateTime.Now
		};

		await context.UserAccount.AddAsync(userAccount, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);

		return ApiResponse<CreateUserAccountCommandResponse>.Success(new CreateUserAccountCommandResponse());
	}
}
