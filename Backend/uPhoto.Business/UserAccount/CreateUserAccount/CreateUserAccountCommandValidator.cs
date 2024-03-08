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
			.Must(email => context.UserAccount.All(ua => ua.Email.ToLower() != email.ToLower()))
			.WithMessage("Account with given email address already exists.");

		RuleFor(cmd => cmd.Password)
			.Must(password => password.Any(char.IsUpper))
			.WithMessage("Password must contain capital letter.");

		RuleFor(cmd => cmd.Password)
			.Must(password => password.Any(char.IsNumber))
			.WithMessage("Password must contain number.");

		RuleFor(cmd => cmd.Password)
			.NotNull()
			.MinimumLength(8);
	}
}
