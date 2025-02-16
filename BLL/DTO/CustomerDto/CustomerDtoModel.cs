﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.CustomerDto
{
    public class CustomerDtoModel
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string? ProfilePictureUrl { get; set; } 
    }
}
