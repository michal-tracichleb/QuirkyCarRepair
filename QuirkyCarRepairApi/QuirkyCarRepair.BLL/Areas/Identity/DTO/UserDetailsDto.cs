﻿namespace QuirkyCarRepair.BLL.Areas.Identity.DTO
{
    public class UserDetailsDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}