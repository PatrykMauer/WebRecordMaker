using System;
using System.Threading.Tasks;
using RecordMaker.Core.Domain;
using RecordMaker.Core.Repositories;
using RecordMaker.Infrastructure.Exceptions;
using ErrorCodes = RecordMaker.Infrastructure.Exceptions.ErrorCodes;

namespace RecordMaker.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Table> GetOrFailAsync(this ITableRepository repository, Guid tableId)
        {
            var table = await repository.GetAsync(tableId);
            if (table == null)
            {
                throw new ServiceException(ErrorCodes.TableNotFound,$"Table with id: {tableId} was not found.");
            }

            return table;
        }
        
        public static async Task<User> GetOrFailAsync(this IUserRepository repository, Guid userId)
        {
            var user = await repository.GetAsync(userId);
            if (user == null)
            {
                throw new ServiceException(ErrorCodes.UserNotFound,"User with id: {userId} was not found.");
            }

            return user;
        }
        
        public static async Task<User> GetOrFailAsync(this IUserRepository repository, string email)
        {
            var user = await repository.GetAsync(email);
            if (user == null)
            {
                throw new ServiceException(ErrorCodes.UserNotFound,$"User with email: {email} was not found.");
            }

            return user;
        }
        
    }
}