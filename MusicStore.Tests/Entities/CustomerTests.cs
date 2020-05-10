using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Enums;
using MusicStore.Domain.ValueObjects;
using System;

namespace MusicStoreTests.Entities
{
    /// <summary>
    /// Test Class for customer
    /// </summary>
    [TestClass]
    public class CustomerTests
    {
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _doc;
        private readonly Address _address;
        private readonly Customer _customer;
        private readonly Subscription _subscription;

        public CustomerTests()
        {
            _name = new Name("First", "Name");
            _doc = new Document("57428963476", EDocumentType.CPF);
            _email = new Email("myemailk@email.com");
            _customer = new Customer(_name, _doc, _email);
            _address = new Address("00000-000", "Rua 1", "22", "", "Any", "City", "SP", "Brazil");
            _subscription = new Subscription(null);
        }

        /// <summary>
        /// Test active subscription
        /// </summary>
        [TestMethod]
        public void ReturnErrorWhenHadActiveSubscription()
        {
            var payment = new CreditCardPayment($"{_name.FirstName} {_name.LastName}", "5466584611234", "123", "", DateTime.Now, DateTime.Now.AddDays(5), _doc, _email, "", _address, 100, 100);
            _subscription.AddPayment(payment);
            _customer.AddSubscription(_subscription);
            _customer.AddSubscription(_subscription);

            Assert.IsTrue(_customer.Invalid);
        }

        /// <summary>
        /// Test subscription without payment
        /// </summary>
        [TestMethod]
        public void ReturnErrorWhenHadSubscriptionWithoutPayments()
        {
            _customer.AddSubscription(_subscription);

            Assert.IsTrue(_customer.Invalid);
        }

        /// <summary>
        /// Test no active subscription
        /// </summary>
        [TestMethod]
        public void ReturnSuccessWhenHadNoActiveSubscription()
        {
            var payment = new CreditCardPayment($"{_name.FirstName} {_name.LastName}", "5466584611234", "123", "", DateTime.Now, DateTime.Now.AddDays(5), _doc, _email, "", _address, 100, 100);
            _subscription.AddPayment(payment);
            _customer.AddSubscription(_subscription);
            Assert.IsTrue(_customer.Valid);
        }
    }
}
