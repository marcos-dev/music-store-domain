using Flunt.Notifications;
using Flunt.Validations;
using MusicStore.Domain.Enums;
using MusicStore.Shared.Commands;
using System;

namespace MusicStore.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Document { get; set; }

        public EDocumentType DocumentType { get; set; }

        public string Hash { get; set; }

        public string Barcode { get; set; }

        public string BoletoNumber { get; set; }

        public string PayerEmail { get; set; }

        public DateTime PaidDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public string OwnerDocument { get; set; }

        public EDocumentType OwnerDocumentType { get; set; }

        public string Owner { get; set; }

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

        public void Validate()
        {
            AddNotifications(new Contract()
                  .Requires()
                  .HasMinLen(FirstName, 3, "Name.FirstName", "Name must to contains 3 or more characters")
                  .HasMinLen(LastName, 3, "Name.LastNam", "Last Name must to contains 3 or more characters")
                  .HasMaxLen(FirstName, 200, "Name.FirstName", "Name must contain up to 200 characters")
                  .HasMaxLen(LastName, 200, "Name.LastNam", "Last Name must contain up to 200 characters"));
        }
    }
}
