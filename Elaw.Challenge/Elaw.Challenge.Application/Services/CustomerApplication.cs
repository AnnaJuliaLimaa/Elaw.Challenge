using AutoMapper;
using Elaw.Challenge.Domain;

namespace Elaw.Challenge.Application
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly IMapper _mapper;

        private readonly ICustomerService _service;

        public CustomerApplication(ICustomerService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        public CustomerViewModel Add(CustomerViewModel model)
        {
            var customer = _service.Add(_mapper.Map<Customer>(model));

            return _mapper.Map<CustomerViewModel>(customer);
        }
        public CustomerViewModel Update(Guid id, CustomerViewModel model)
        {
            var customer = _service.GetById(id);

            var customers = _service.Update(_mapper.Map<Customer>(model));

            return _mapper.Map<CustomerViewModel>(customers);
        }

        public List<CustomerViewModel> Get()
        {
            var customers = _service.Get();

            return _mapper.Map<List<CustomerViewModel>>(customers);
        }

        public CustomerViewModel GetById(Guid Id)
        {
            var customer = _service.GetById(Id);

            return _mapper.Map<CustomerViewModel>(customer);
        }

        public void Delete(Guid Id)
        {
            _service.Delete(Id);
        }
    }
}
