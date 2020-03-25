﻿using System;
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
        public string Role { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {
        }

        public User(Guid userId, string email, string username,
            string password, string salt, string role)
        {
            Id = userId;
            Email = email.ToLowerInvariant();
            Username = username;
            Password = password;
            Salt = salt;
            Role = role;
            CreatedAt = DateTime.UtcNow;
        }

        public void ChangeEmail(string newEmail)
        {
            Email = newEmail;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }
        public void ChangeSalt(string salt)
        {
            Salt = salt;
        }
    }
    //TODO: Validate Email, Password, Role.
}