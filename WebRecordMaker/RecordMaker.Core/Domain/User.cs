using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RecordMaker.Core.Domain
{
    public class User
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Username { get; protected set; }
        public string Role { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected User()
        {
        }

        public User(Guid userId, string email, string username,
            string password, string salt, string role)
        {
            Id = userId;
            SetEmail(email);
            SetUsername(username);
            SetPassword(password);
            SetSalt(salt);
            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }
        
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException(ErrorCodes.InvalidEmail, "Email can not be empty");
            }
            Email = email.ToLowerInvariant();
            UpdatedAt=DateTime.UtcNow;
        }
        
        public void SetUsername(string username)
        {
            if (!NameRegex.IsMatch(username))
            {
                {
                    throw new DomainException(ErrorCodes.InvalidUsername, 
                        "Username is invalid.");
                }
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new DomainException(ErrorCodes.InvalidUsername,
                    "Username can not be empty");
            }
            Username = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }


        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new DomainException(ErrorCodes.InvalidPassword, "Password can not be empty.");
            }

            if (password.Length < 4)
            {
                throw new DomainException(ErrorCodes.InvalidPassword, "Password can not have less than 4 characters.");
            }

            if (password.Length >100)
            {
                throw new DomainException(ErrorCodes.InvalidPassword, "Password can not have more than 100 characters.");
            }
            Password = password;
        }
        
        public void SetSalt(string salt)
        {
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new DomainException(ErrorCodes.InvalidSalt, "Salt can not be empty.");
            }
            Salt = salt;
        }
    }
    //TODO: Validate Email, Password, Role.
}