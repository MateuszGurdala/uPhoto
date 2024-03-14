using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using uPhoto.Common.Contracts;
using uPhoto.Common.Models;

namespace uPhoto.Business.UserAccount.SignOut;

public class SignOutCommandHandler(IHttpContextAccessor httpContextAccessor) : IApiResponseRequestHandler<SignOutCommand, SignOutCommandResponse>
{
	public async Task<ApiResponse<SignOutCommandResponse>> Handle(SignOutCommand request, CancellationToken cancellationToken)
	{
		await httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		httpContextAccessor.HttpContext!.Response.Cookies.Delete(".uPhoto.Session");
		return ApiResponse<SignOutCommandResponse>.Success();
	}
}
