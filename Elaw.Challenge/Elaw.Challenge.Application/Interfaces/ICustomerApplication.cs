namespace Elaw.Challenge.Application
{
    public interface ICustomerApplication
    {
         List<CustomerViewModel> Get();
         CustomerViewModel GetById(Guid Id);
         void Delete(Guid Id);
         CustomerViewModel Update(Guid id, CustomerViewModel model);
         CustomerViewModel Add(CustomerViewModel model);
    }
}
