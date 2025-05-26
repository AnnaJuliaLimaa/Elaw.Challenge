namespace Elaw.Challenge.Domain
{
    public interface ICustomerService : IBaseService<Customer>
    {
        Customer GetByEmail(string email);
    }
}
