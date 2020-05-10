using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Enums;
using MusicStore.Domain.Queries;
using MusicStore.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1.Queries
{
    [TestClass]
    public class CustomerQueriesTests
    {
        private IList<Customer> _customers = new List<Customer>();

        public CustomerQueriesTests()
        {
            for (int i = 0; i <= 5; i++)
            {
                _customers.Add(new Customer(
                    new Name("Customer ", i.ToString()),
                    new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                    new Email(i.ToString()+ "@test.com")
                ));
            }
        }

        [TestMethod]
        public void ReturnNullWhenDocumentNotExists()
        {
            var expression = CustomerQueries.GetByDocument("12345678956");
            var customs = _customers.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreEqual(null, customs);
        }
    }
}
