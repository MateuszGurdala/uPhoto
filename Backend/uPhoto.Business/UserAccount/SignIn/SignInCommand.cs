using uPhoto.Common.Contracts;

namespace uPhoto.Business.UserAccount.SignIn;

public record SignInCommand(string Email, string Password) : IApiResponseRequest<SignInCommandResponse>;

public record SignInCommandResponse;
