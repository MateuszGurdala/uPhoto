using uPhoto.Common.Contracts;

namespace uPhoto.Business.UserAccount.SignOut;

public record SignOutCommand : IApiResponseRequest<SignOutCommandResponse>;

public record SignOutCommandResponse;
