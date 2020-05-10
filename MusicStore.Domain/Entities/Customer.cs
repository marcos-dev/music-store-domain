using Flunt.Validations;
using MusicStore.Domain.ValueObjects;
using MusicStore.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Domain.Entities
{
    public class Customer : Entity
    {
        public Name Name { get; private set; }

        public Document Document { get; private set; }

        public Email Email { get; private set; }

        public Address Address { get; private set; }

        private ICollection<Subscription> _subscriptions;
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToList(); } }

        public Customer(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, email, document);
        }

        public void AddSubscription(Subscription subscription)
        {
     
            var hasActiveSubscription = false;
            foreach (var subs in _subscriptions)
            {
                hasActiveSubscription = subs.Active ? true : false;
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasActiveSubscription, "Customer.Subscription", "You already  have an active subscription.")
                .IsTrue(subscription.Payments.Any(), "Customer.Subscription.Payments", "Payments not founds")
                );

            //Can be added before closing the context 
            _subscriptions.Add(subscription);
        }
    }
}
