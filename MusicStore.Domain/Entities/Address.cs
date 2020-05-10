using Flunt.Validations;
using MusicStore.Shared.Entities;

namespace MusicStore.Domain.Entities
{
    public class Address : Entity
    {
        public string ZipCode { get; private set; }

        public string Street { get; private set; }

        public string Number { get; private set; }

        public string Complement { get; private set; }

        public string District { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Country { get; private set; }

        public Address(string zipCode, string street, string number, string complement, string district, string city, string state, string country)
        {
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Country = country;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Street, 4, "Address.Street", "Strret must to contains 4 or more characters.")
                .HasMinLen(Number, 1, "Address.Number", "Number is required")
             );
        }
    }
}
