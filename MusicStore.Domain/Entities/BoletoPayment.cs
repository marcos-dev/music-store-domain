using MusicStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        
        public string Barcode { get; private set; }

        public string Number { get; private set; }

        public BoletoPayment(string barcode, string number, string hash, DateTime paidDate, DateTime expireDate, Document document, Email email, string owner, Address address, decimal total, decimal totalPaid) :
            base(hash, paidDate, expireDate, document, email, owner, address, total, totalPaid)
        {
            Barcode = barcode;
            Number = number;
        }
    }
}
