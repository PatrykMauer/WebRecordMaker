using System.Threading.Tasks;

namespace RecordMaker.Infrastructure.Services
{
    public interface IEmailSender
    {
        public Task SendEmail(string body);
    }
}