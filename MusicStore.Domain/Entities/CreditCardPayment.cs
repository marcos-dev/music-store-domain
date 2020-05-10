using MusicStore.Domain.ValueObjects;
using System;

namespace MusicStore.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public string HolderName { get; set; }

        public string CardNumber { get; set; }

        public string LastTransacrionNumber { get; set; }

        public CreditCardPayment(string holderName, string cardNumber, string lastTransactionNumber, string hash, DateTime paidDate, DateTime expireDate, Document document, Email email, string owner, Address address, decimal total, decimal totalPaid)
            : base(hash, paidDate, expireDate, document, email, owner, address, total, totalPaid)
        {
            HolderName = holderName;
            CardNumber = cardNumber;
            LastTransacrionNumber = lastTransactionNumber;
        }
    }
}
