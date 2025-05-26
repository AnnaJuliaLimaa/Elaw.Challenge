using Elaw.Challenge.Extensions.Repository;

namespace Elaw.Challenge.Domain
{
    public class AddressService : IAddressService
    {
        public readonly IRepository<Address> _repository;

        public AddressService(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public IQueryable<Address> Get()
        {
            return _repository.Get();
        }

        public Address GetById(Guid id)
        {
            return _repository.Get().Where(e => e.Id == id).FirstOrDefault();
        }
        public Address Add(Address model)
        {
            return _repository.Add(model);
        }
        public Address Update(Address model)
        {
            return _repository.Update(model);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

    }
}
