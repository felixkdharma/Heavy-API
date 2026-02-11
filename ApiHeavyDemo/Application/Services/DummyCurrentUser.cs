
namespace ApiHeavyDemo.Application.Services
{
    public class DummyCurrentUser : ICurrentUser
    {
        public Guid UserId => Guid.Parse("11111111-1111-1111-1111-111111111111");
        public Guid CompanyId => Guid.Parse("22222222-2222-2222-2222-222222222222");
        public string Role => "Admin";
    }
}
