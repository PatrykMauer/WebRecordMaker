using System.Threading.Tasks;

namespace RecordMaker.Infrastructure.Services
{
    public interface IDataInitializer : IService
    {
        Task SeedAsync();
    }
}