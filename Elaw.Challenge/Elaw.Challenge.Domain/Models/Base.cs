namespace Elaw.Challenge.Domain
{
    public class Base
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Deleted { get; set; } = false;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
