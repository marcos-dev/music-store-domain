using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.Domain.Enums;
using MusicStore.Domain.ValueObjects;

namespace MusicStoreTests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        /// <summary>
        /// Test CPF Invalid
        /// </summary>
        [TestMethod]
        public void ReturnErrorWhenCpfInvalid()
        {
            var doc = new Document("", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        /// <summary>
        /// Test CPF alid
        /// </summary>
        /// <param name="cpf"></param>
        [TestMethod]
        [DataTestMethod]
        [DataRow("58639874523")]
        [DataRow("75782869874")]
        public void ReturnSuccessWhenCpfIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}
