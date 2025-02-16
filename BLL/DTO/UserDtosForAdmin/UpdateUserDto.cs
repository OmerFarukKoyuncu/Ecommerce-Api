﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.UserDtosForAdmin
{
    public class UpdateUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
		public bool IsActive { get; set; }
		public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? SecondName { get; set; }
        public string? SecondLastname { get; set; }
        public string Address { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Password { get; set; }


    }
}
