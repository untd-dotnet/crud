﻿namespace WebApplication1.Models
{
    public class UpdateContactRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
