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

        public void AddCustomer(string name, string email, string phone, AddressViewModel address)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
        }
        public void SetEmail(string email)
        {
            this.Email = email;
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
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email))
            {
                throw new InvalidOperationException("Cliente deve ter nome e email cadastrados antes de adicionar endereço");
            }

            Address = address;
        }
    }
}
