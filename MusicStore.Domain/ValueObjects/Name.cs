using Flunt.Validations;
using MusicStore.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Name must to contains 3 or more characters")
                .HasMinLen(LastName, 3, "Name.LastName", "Last Name must to contains 3 or more characters")
                .HasMaxLen(FirstName, 200, "Name.FirstName", "Name must contain up to 200 characters")
                .HasMaxLen(LastName, 200, "Name.LastName", "Last Name must contain up to 200 characters"));
                 
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
