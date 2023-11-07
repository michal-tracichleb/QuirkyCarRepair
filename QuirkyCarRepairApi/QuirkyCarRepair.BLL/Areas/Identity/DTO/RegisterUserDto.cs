﻿namespace QuirkyCarRepair.BLL.Areas.Identity.DTO
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public int RoleId { get; set; } = 1;
    }
}