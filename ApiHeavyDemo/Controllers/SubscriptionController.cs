using ApiHeavyDemo.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiHeavyDemo.Controllers
{
    [ApiController]
    [Route("api/subscription")]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _service;
        private readonly ICurrentUser _currentUser;

        public SubscriptionController(
            SubscriptionService service,
            ICurrentUser currentUser)
        {
            _service = service;
            _currentUser = currentUser;
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create([FromBody] string plan)
        {
            var result = _service.Create(plan, _currentUser);
            return Ok(result);
        }
    }
}
