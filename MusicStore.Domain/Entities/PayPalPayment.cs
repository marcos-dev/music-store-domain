using MusicStore.Domain.ValueObjects;
using System;

namespace MusicStore.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public string TransactionCode { get; private set; }

        public PayPalPayment(string transacrionCode, string hash, DateTime paidDate, DateTime expireDate, Document document, Email email, string owner, Address address, decimal total, decimal totalPaid) 
            : base(hash, paidDate, expireDate, document, email, owner, address, total, totalPaid)
        {
            TransactionCode = transacrionCode;
        }
    }
}
