using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecordMaker.Core.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }
        [Required]
        [EmailAddress]
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get;protected set; }
        public string Profession { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {
        }

        public User(string email, string username,
            string password, string salt, string profession)
        {
            Id=Guid.NewGuid();
            Email = email.ToLowerInvariant();
            Username = username;
            Password = password;
            Salt = salt;
            Profession = profession;
            CreatedAt = DateTime.UtcNow;
        }

        public void ChangeEmail(string newEmail)
        {
            Email = newEmail;
        }
    }
}