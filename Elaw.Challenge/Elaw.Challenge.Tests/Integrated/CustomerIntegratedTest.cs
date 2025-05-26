using Elaw.Challenge.Application;
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

            if (customer != null)
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

            duplicateCustomer.SetEmail("anna@gmail.com");
            duplicateCustomer.SetName("Anna Duplicada");
            duplicateCustomer.SetPhone("21999999999");
            duplicateCustomer.AddAddress(new AddressViewModel
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

            clienteTeste.SetId(Guid.NewGuid());
            clienteTeste.SetEmail("deletar@teste.com");
            clienteTeste.SetName("Cliente para Deleta");
            clienteTeste.SetPhone("21999999999");
            clienteTeste.AddAddress(new AddressViewModel
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
            var totalClientes = customers.Count() == 1;

            Assert.That(customers, Is.Not.Null, "A lista de clientes não deveria ser nula");
            Assert.That(totalClientes, "Deveria retornar exatamente 1 cliente");
        }
    }
}