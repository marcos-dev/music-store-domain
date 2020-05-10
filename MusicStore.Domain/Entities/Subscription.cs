using Flunt.Validations;
using MusicStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Domain.Entities
{
    public class Subscription : Entity
    {
        public bool Active { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime? ExpipireDate { get; private set; }

        public DateTime LastModifyDate { get; private set; }

        private ICollection<Payment> _payments;
        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToList(); } }

        public Subscription(DateTime? expipireDate)
        {
            Active = true;
            StartDate = DateTime.Now;
            ExpipireDate = expipireDate;
            LastModifyDate = DateTime.Now;
            _payments = new List<Payment>();
        }

        public void Activate(bool makeActive)
        {
            Active = makeActive;
            LastModifyDate = DateTime.Now;
        }

        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract()
               .Requires()
               .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "Date of payment must to be future")
               );

            //if (Valid)
                _payments.Add(payment);
        }
    }
}
