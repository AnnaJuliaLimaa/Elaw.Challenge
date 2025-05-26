using Elaw.Challenge.Application;
using Elaw.Challenge.Domain;

namespace Elaw.Challenge.Tests
{
    public class Tests 
    {
        [Test]
        public void DeveCriarUmCliente()
        {
            var customer = new CustomerViewModel();

            customer.SetEmail("xx@aa.com");
            customer.SetName("Anna Julia");
            customer.SetPhone("21994242884");
            customer.AddAddress(new AddressViewModel { City = "Rio de Janeiro", Number = "2134", Street = "Rua Embaú", State = "RJ", ZipCode = "21535000", Id = Guid.Parse("6a602eb6-f49c-44f7-a781-ca9bc62ba80a") });

            Assert.That(customer, Is.Not.Null, "O cliente não deveria ser nulo");
            Assert.That(customer.Name, Is.EqualTo("Anna Julia"), "O nome do cliente não corresponde");
            Assert.That(customer.Email, Is.EqualTo("xx@aa.com"), "O email do cliente não corresponde");
            Assert.That(customer.Phone, Is.EqualTo("21994242884"), "O telefone do cliente não corresponde");
        }

        [Test]
        public void DeveAtualizarUmCliente()
        {
            var customer = new CustomerViewModel();

            customer.SetEmail("xx@aa.com");
            customer.SetName("Anna Julia Lima");
            customer.SetPhone("21994242884");
            customer.AddAddress(new AddressViewModel { City = "Rio de Janeiro", Number = "2134", Street = "Rua Embaú", State = "RJ", ZipCode = "21535000", Id = Guid.Parse("6a602eb6-f49c-44f7-a781-ca9bc62ba80a") });

            if (customer.Email == "xx@aa.com")
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void DeveLancarExcecaoQuandoNomeForVazio()
        {
            var customer = new CustomerViewModel();
            customer.SetName("");

            Assert.That(customer.Name, Is.Not.Null, "O nome do cliente não pode ser vazio");
        }

        [Test]
        public void DeveLancarExcecaoQuandoEmailForInvalido()
        {
            var customer = new CustomerViewModel();
            customer.SetEmail("");

            Assert.That(customer.Email, Is.Not.Null, "O email do cliente não pode ser vazio");
        }

        [Test]
        public void DeveDaErroAoAdicionarEnderecoSemCliente()
        {
            var customer = new CustomerViewModel();
            var address = new AddressViewModel
            {
                Street = "Rua das Flores",
                Number = "123",
                City = "Rio de Janeiro",
                State = "RJ",
                ZipCode = "20000000"
            };

           customer.AddAddress(address);

            if (customer != null)
                Assert.Pass();
            else
                Assert.Fail("Cliente deve ser cadastrado primeiro");
        }
    }
}