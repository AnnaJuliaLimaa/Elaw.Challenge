using System.Net;

namespace Elaw.Challenge.Domain
{
    public class Customer : BaseEntity
    {
        public Guid AddressId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}
