﻿using Microsoft.Build.Framework;

namespace MVC_Producr.Models.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
