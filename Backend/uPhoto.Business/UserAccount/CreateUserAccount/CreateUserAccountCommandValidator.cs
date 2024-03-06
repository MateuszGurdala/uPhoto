using FluentValidation;
using uPhoto.Database.Contracts;

namespace uPhoto.Business.UserAccount.CreateUserAccount;

public class CreateUserAccountCommandValidator : AbstractValidator<CreateUserAccountCommand>
{
	public CreateUserAccountCommandValidator(IUserAccountDbContext context)
	{
		RuleFor(cmd => cmd.Email)
			.NotNull()
			.EmailAddress();

		RuleFor(cmd => cmd.Email)
			.Must(email => context.UserAccount.Any(ua => ua.Email.ToLower() != email.ToLower()))
			.WithMessage("Account with given email address already exists.");

		RuleFor(cmd => cmd.Password)
			.Must(password => password.Any(char.IsUpper))
			.Must(password => password.Any(char.IsNumber))
			.WithMessage("Password must contain one capital letter and a number.");

		RuleFor(cmd => cmd.Password)
			.NotNull()
			.MinimumLength(8);
	}
}
