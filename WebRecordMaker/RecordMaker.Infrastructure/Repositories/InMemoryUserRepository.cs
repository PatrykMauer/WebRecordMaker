using System;
using System.Collections.Generic;
using System.Linq;
using RecordMaker.Core.Domain;
using RecordMaker.Core.Repositories;

namespace RecordMaker.Infrastructure.Repositories
{
    public class InMemoryUserRepository: IUserRepository
    {
        private static ISet<User> _users =new HashSet<User>()
        {
            new User("referee1@wp.pl","referee1","secret","salt","Observer"),
            new User("referee2@wp.pl","referee2","secret","salt","Observer"),
            new User("referee3@wp.pl","referee3","secret","salt","Observer"),

        };

        public User Get(Guid id)
            => _users.Single(x => x.Id == id);

        public User Get(string email)
            => _users.Single(x => x.Email == email.ToLowerInvariant());

        public IEnumerable<User> GetAll()
            => _users;        

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }
    }
}