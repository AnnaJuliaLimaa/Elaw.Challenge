namespace Elaw.Challenge.Application
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
