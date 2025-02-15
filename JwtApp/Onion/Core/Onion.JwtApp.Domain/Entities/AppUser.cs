﻿namespace Onion.JwtApp.Domain.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int AppRoleId { get; set; }
        public AppRole? AppRole { get; set; }
    }
}
