namespace ApiHeavyDemo.Domain.Entities
{
    public class Subscription
    {
        public Guid Id { get; private set; }
        public Guid CompanyId { get; private set; }
        public string Plan { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        private Subscription() { }

        public Subscription(Guid companyId, string plan)
        {
            Id = Guid.NewGuid();
            CompanyId = companyId;
            Plan = plan;
            StartDate = DateTime.UtcNow;
        }
    }
}
