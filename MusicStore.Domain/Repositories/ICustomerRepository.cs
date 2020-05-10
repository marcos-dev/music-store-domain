using MusicStore.Domain.Entities;
using System;

namespace MusicStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        bool DocumentExists(string document);

        bool EmailExists(string email);

        void CreateSubscription(Customer customer);

        void UpdateSubscription(Customer customer);

        void DeleteSubscription(Guid id);
    }
}
