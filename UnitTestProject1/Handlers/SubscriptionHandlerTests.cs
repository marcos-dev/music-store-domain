using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.Domain.Commands;
using MusicStore.Domain.Enums;
using MusicStore.Domain.Handler;
using System;
using UnitTestProject1.Fakes;

namespace UnitTestProject1.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeCustomerRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand
            {
                FirstName = "First",
                LastName = "Last",
                Email = "test@email.com",
                Document = "11111111111",
                DocumentType = EDocumentType.CPF,

                Hash = "",
                Barcode = "12345",
                BoletoNumber = "12345678",
                PayerEmail = "tests@email.com",
                PaidDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(1),
                OwnerDocument = "36875214823",
                OwnerDocumentType = EDocumentType.CPF,
                Owner = "Owner Name",
                ZipCode = "01512000",
                Street = "Test Street",
                Number = "123",
                Complement = "",
                District = "sasdsaa",
                City = "asdads asa",
                State = "SP",
                Country = "Brazil",
                Total = 100,
                TotalPaid = 100
            };

            handler.Handle(command);

            Assert.AreEqual(false, handler.Valid);
        }


    }
}
