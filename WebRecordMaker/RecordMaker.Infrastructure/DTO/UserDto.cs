﻿using System;

namespace RecordMaker.Infrastructure.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get;  set; }
        public string FullName { get; set; }
        public string Profession { get;  set; }
    }
}