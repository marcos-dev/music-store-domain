using MusicStore.Domain.Entities;
using MusicStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public void CreateSubscription(Customer customer)
        {
            
        }

        public void UpdateSubscription(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteSubscription(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool DocumentExists(string document)
        {
            return document == "11111111111";
                
        }

        public bool EmailExists(string email)
        {
            return email == "test@email.com";
        }

       
    }
}
