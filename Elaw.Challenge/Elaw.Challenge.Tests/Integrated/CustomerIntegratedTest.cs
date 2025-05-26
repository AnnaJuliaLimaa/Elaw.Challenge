using Elaw.Challenge.Application;
using Elaw.Challenge.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Elaw.Challenge.Tests
{
    public class CustomerIntegratedTest : SetupTest
    {

        [Test]
        public void DeveInserirUmCliente()
        {
            var customer = _application.Add(Customer);

            if (customer.Id != Guid.Empty)
                Assert.Pass();
            else
                Assert.Fail("Erro no teste integrado para geração ");
        }

        [Test]
        public void RetornarTodosClientes()
        {
            var customers = _application.Get();

            if (customers != null)
                Assert.Pass();
            else
                Assert.Fail("Erro no teste integrado para geração: nenhum cliente encontrado.");
        }

        [Test]
        public void CriarClienteComEmailJaExistente_DeveFalhar()
        {
            var duplicateCustomer = new CustomerViewModel();

            duplicateCustomer.AddCustomer(
                "Anna Duplicada",
                "anna@gmail.com", 
                "21999999999",
                new AddressViewModel
                {
                    City = "Rio de Janeiro",
                    Number = "456",
                    Street = "Rua Duplicada",
                    State = "RJ",
                    ZipCode = "21535000",
                    Id = Guid.NewGuid() 
                });

            var ex = Assert.Throws<DbUpdateException>(() => _application.Add(duplicateCustomer));

            Assert.That(ex.InnerException, Is.InstanceOf<SqlException>());
        }

        [Test]
        public void DeletarUmCliente()
        {
            var clienteTeste = new CustomerViewModel();

            clienteTeste.Id = Guid.NewGuid();
            clienteTeste.AddCustomer(
                "Cliente para Deletar",
                "deletar@teste.com",
                "21999999999",
                new AddressViewModel
                {
                    City = "Rio de Janeiro",
                    Number = "123",
                    Street = "Rua Deletar",
                    State = "RJ",
                    ZipCode = "20000000",
                    Id = Guid.NewGuid()
                });

            var clienteInserido = _application.Add(clienteTeste);

            _application.Delete(clienteInserido.Id);

            var customers = _application.Get();
            var clientesRestantes = _application.Get();

            Assert.That(clientesRestantes.Count, Is.EqualTo(1),"Deveria ter apenas um cliente restante");
        }

        [Test]
        public void TotalDeClientes_DeveRetornarQuantidadeCorreta()
        {
            var customers = _application.Get();
            var totalClientes = customers.Count;

            Assert.That(customers, Is.Not.Null, "A lista de clientes não deveria ser nula");
            Assert.That(totalClientes, Is.EqualTo(1), "Deveria retornar exatamente 1 cliente");
        }
    }
}