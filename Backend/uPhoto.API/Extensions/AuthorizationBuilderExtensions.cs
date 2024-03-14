using System.Reflection;
using Microsoft.AspNetCore.Authorization;

namespace uPhoto.API.Extensions;

public static class Policies
{
	public static AuthorizationBuilder AddPolicies(this AuthorizationBuilder authorizationBuilder)
	{
		foreach (FieldInfo actionField in typeof(Policies).GetFields())
		{
			authorizationBuilder.AddPolicy(actionField.Name, (Action<AuthorizationPolicyBuilder>)actionField.GetValue(null)!);
		}

		return authorizationBuilder;
	}

	public static Action<AuthorizationPolicyBuilder> Unauthenticated = builder =>
		builder.RequireAssertion(context => context.User.Identity is not { IsAuthenticated: true });
}
