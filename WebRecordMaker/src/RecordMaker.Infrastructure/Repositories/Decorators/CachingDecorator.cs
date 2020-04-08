using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using RecordMaker.Core.Domain;
using RecordMaker.Core.Repositories;

namespace RecordMaker.Infrastructure.Repositories.Decorators
{
    public class CachingDecorator : IUserRepository
    {
        private readonly IUserRepository _repository;
        private readonly IMemoryCache _cache;

        public CachingDecorator(IUserRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<User> GetAsync(Guid id)
        {
            var user = await _repository.GetAsync(id);
            _cache.Set("User",user,TimeSpan.FromMinutes(1));

            return user;
        }

        public async Task<User> GetAsync(string email)
        {
            var user = await _repository.GetAsync(email);
            _cache.Set("User",user,TimeSpan.FromMinutes(1));

            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var user = await _repository.GetAllAsync();
            var users = user.ToList();
            _cache.Set("Users",users,TimeSpan.FromMinutes(1));

            return users;
        }

        public Task AddAsync(User user)
        {
            return _repository.AddAsync(user);
        }

        public Task RemoveAsync(Guid id)
        {
            return _repository.RemoveAsync(id);
        }

        public Task UpdateAsync(User user)
        {
            return _repository.UpdateAsync(user);
        }
    }
}