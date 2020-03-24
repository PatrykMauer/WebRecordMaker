using System;
using System.Threading.Tasks;
using RecordMaker.Core.Domain;
using RecordMaker.Core.Repositories;

namespace RecordMaker.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Table> GetOrFailAsync(this ITableRepository repository, Guid tableId)
        {
            var table = await repository.GetAsync(tableId);
            if (table == null)
            {
                throw new Exception($"Table with id: {tableId} was not found.");
            }

            return table;
        }
        
        public static async Task<User> GetOrFailAsync(this IUserRepository repository, Guid userId)
        {
            var user = await repository.GetAsync(userId);
            if (user == null)
            {
                throw new Exception($"Table with id: {userId} wa not found.");
            }

            return user;
        }
        
    }
}