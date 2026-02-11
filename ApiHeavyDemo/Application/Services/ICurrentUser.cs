namespace ApiHeavyDemo.Application.Services
{
    public interface ICurrentUser
    {
        Guid UserId { get; }
        Guid CompanyId { get; }
        string Role { get; }
    }
}
