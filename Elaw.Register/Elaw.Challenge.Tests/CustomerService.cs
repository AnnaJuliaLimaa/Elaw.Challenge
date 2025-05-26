using Moq;
using Elaw.Challenge.Domain;
using Elaw.Challenge.Extensions.Repository;

namespace Elaw.Challenge.Tests
{
    public class ClienteServiceTests
    {
        private readonly CustomerService _service;
        private readonly Mock<IRepository<Customer>> _repoMock;

        public ClienteServiceTests()
        {
            _repoMock = new Mock<IRepository<Customer>>();
            _service = new CustomerService(_repoMock.Object);
        }

     
    }

}