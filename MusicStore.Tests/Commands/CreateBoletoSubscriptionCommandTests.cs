using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.Domain.Commands;

namespace UnitTestProject1.Commands
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests
    {
        [TestMethod]
        public void ReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand
            {
                FirstName = ""
            };

            command.Validate();

            Assert.AreEqual(false, command.Valid);
        }

        
    }
}
