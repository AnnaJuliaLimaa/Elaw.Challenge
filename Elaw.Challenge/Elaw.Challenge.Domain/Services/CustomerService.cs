using Microsoft.EntityFrameworkCore;
using Elaw.Challenge.Extensions;

namespace Elaw.Challenge.Domain
{
    public class CustomerService : ICustomerService
    {
        public readonly IRepository<Customer> _repository;

        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        public IQueryable<Customer> Get()
        {
            return _repository.Get().Include(e => e.Address);
        }
        public Customer GetById(Guid id)
        {
            return _repository.Get().Include(e => e.Address).FirstOrDefault(e => e.Id == id);
        }
        public Customer GetByEmail(string email)
        {
            var emailLower = email.ToLower();

            return _repository.Get().FirstOrDefault(e => e.Email.ToLower() == emailLower);
        }
        public Customer Add(Customer model)
        {
            model.Email.ToLower();   

            return _repository.Add(model);
        }
        public Customer Update(Customer model)
        {
            return _repository.Update(model);
        }
        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}
