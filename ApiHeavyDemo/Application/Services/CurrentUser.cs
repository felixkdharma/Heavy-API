using System.Security.Claims;

namespace ApiHeavyDemo.Application.Services;

public class CurrentUser : ICurrentUser
{
    public Guid UserId { get; }
    public Guid CompanyId { get; }
    public string Role { get; }

    public CurrentUser(IHttpContextAccessor accessor)
    {
        var user = accessor.HttpContext?.User;

        UserId = Guid.Parse(user?.FindFirst("UserId")?.Value!);
        CompanyId = Guid.Parse(user?.FindFirst("CompanyId")?.Value!);
        Role = user?.FindFirst(ClaimTypes.Role)?.Value!;
    }
}
