using System.Security.Claims;

namespace TestCleanCode.Helpers;

public static class ClaimsPrincipalExtension
{
	public static bool TryGetUserId(this ClaimsPrincipal user, out Guid userId)
	{
		var rawUserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
		return Guid.TryParse(rawUserId, out userId);
	}

}
