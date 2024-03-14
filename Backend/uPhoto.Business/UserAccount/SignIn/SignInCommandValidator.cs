using FluentValidation;
using Microsoft.AspNetCore.Http;
using uPhoto.Common;
using uPhoto.Database.Contracts;

namespace uPhoto.Business.UserAccount.SignIn;

public class SignInCommandValidator : AbstractValidator<SignInCommand>
{
	public SignInCommandValidator(IUserAccountDbContext context)
	{
		RuleFor(command => command)
			.Must(command => context.UserAccount.Any(account => account.Email == command.Email &&
			                                                    account.Password == Helpers.CalculateHash(command.Password)))
			.WithMessage("Authentication failed.");
	}
}
