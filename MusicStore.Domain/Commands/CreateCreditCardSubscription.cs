using MusicStore.Domain.Enums;
using System;

namespace MusicStore.Domain.Commands
{
    public class CreateCreditCardSubscriptionCommand
    {
        public string FirstName { get;  set; }

        public string LastName { get;  set; }

        public string Email { get;  set; }

        public string Document { get; set; }

        public EDocumentType DocumentType { get; set; }


        public string Hash { get;  set; }

        public string HolderName { get; set; }

        public string CardNumber { get; set; }

        public string LastTransacrionNumber { get; set; }

        public string PayerEmail { get; set; }

        public DateTime PaidDate { get;  set; }

        public DateTime ExpireDate { get;  set; }

        public string PayerDocument { get;  set; }

        public EDocumentType PayerDocumentType { get; set; }

        public string Owner { get;  set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public decimal Total { get; set; }

        public decimal TotalPaid { get; set; }
    }
}
