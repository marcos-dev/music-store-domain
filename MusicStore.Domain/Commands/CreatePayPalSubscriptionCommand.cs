using MusicStore.Domain.Enums;
using MusicStore.Domain.ValueObjects;
using System;

namespace MusicStore.Domain.Commands
{
    public class CreatePayPalSubscriptionCommand
    {
        public string FirstName { get;  set; }

        public string LastName { get;  set; }

        public Document Document { get; set; }

        public Email Email { get; set; }

        public string TransactionCode { get; set; }

        public string PaymentNumber { get; set; }

        public DateTime PaidDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public decimal Total { get; set; }

        public decimal TotalPaid { get; set; }

        public string Owner { get; set; }

        public string OwnerEmail { get; set; }

        public string OwnerDocument { get; set; }
         
        public EDocumentType OwnerDocumentType { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
    }
}
