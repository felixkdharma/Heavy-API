using ApiHeavyDemo.Domain.Entities;

namespace ApiHeavyDemo.Application.Services
{
    public class SubscriptionService
    {
        private static readonly List<Subscription> _subscriptions = new();

        public Subscription Create(string plan, ICurrentUser user)
        {
            var existing = _subscriptions
                .Any(x => x.CompanyId == user.CompanyId && x.EndDate == null);

            if (existing)
                throw new InvalidOperationException("Active subscription already exists");

            var subscription = new Subscription(user.CompanyId, plan);
            _subscriptions.Add(subscription);

            return subscription;
        }
    }
}
