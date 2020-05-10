using MusicStore.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace MusicStore.Domain.Queries
{
    public static class CustomerQueries
    {
        public static Expression<Func<Customer, bool>> GetByDocument(string document)
        {
            return x => x.Document.Number == document;
        }
    }
}
