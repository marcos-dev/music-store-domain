using MusicStore.Domain.Services;

namespace UnitTestProject1.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string email, string subject, string body)
        {
            
        }
    }
}
