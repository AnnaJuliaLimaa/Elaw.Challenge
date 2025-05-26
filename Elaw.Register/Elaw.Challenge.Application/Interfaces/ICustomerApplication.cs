namespace Elaw.Challenge.Application
{
    public interface ICustomerApplication
    {
        public List<CustomerViewModel> Get();
        public CustomerViewModel GetById(Guid Id);
        public void Delete(Guid Id);
        public CustomerViewModel Update(Guid id, CustomerViewModel model);
        public CustomerViewModel Add(CustomerViewModel model);
    }
}
