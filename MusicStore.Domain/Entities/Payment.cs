using Flunt.Validations;
using MusicStore.Domain.ValueObjects;
using MusicStore.Shared.Entities;
using System;

namespace MusicStore.Domain.Entities
{
    public abstract class Payment : Entity
    {
        public string Hash { get; private set; }

        public DateTime PaidDate { get; private set; }

        public DateTime ExpireDate { get; private set; }

        public Document Document { get; private set; }

        public string Owner { get; private set; }

        public Address Address { get; private set; }

        public Email Email { get; private set; }

        public decimal Total { get; private set; }

        public decimal TotalPaid { get; private set; }

        protected Payment(string hash, DateTime paidDate, DateTime expireDate, Document document, Email email, string owner, Address address, decimal total, decimal totalPaid)
        {
            Hash = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 12).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Document = document;
            Email = email;
            Owner = owner;
            Address = address;
            Total = total;
            TotalPaid = totalPaid;

            AddNotifications(new Contract()
              .Requires()
              .IsLowerOrEqualsThan(0, Total, "Payment.Total", "The total can not be zero")
              .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "Amount paid is less than the payment amount."));
        }
    }
}
