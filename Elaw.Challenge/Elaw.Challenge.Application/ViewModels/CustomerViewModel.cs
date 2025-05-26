namespace Elaw.Challenge.Application
{
    public class CustomerViewModel
    {
        public Guid Id { get;  set; } = Guid.NewGuid();
        public Guid AddressId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public AddressViewModel Address { get; set; }
        public void SetEmail(string email)
        {
            this.Email = email;
        }
        public void SetId(Guid id)
        {
            this.Id = id;
        }
        public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetPhone(string phone)
        {
            this.Phone = phone;
        }
        public void AddAddress(AddressViewModel address)
        {
            this.Address = address;
        }
    }
}
