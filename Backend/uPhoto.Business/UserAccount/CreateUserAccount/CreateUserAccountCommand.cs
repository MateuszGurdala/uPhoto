using uPhoto.Common.Contracts;

namespace uPhoto.Business.UserAccount.CreateUserAccount;

public record CreateUserAccountCommand(string Email, string Password) : IApiResponseRequest<CreateUserAccountCommandResponse>;

public record CreateUserAccountCommandResponse;
