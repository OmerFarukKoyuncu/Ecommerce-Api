﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; } 
        public DateTime UpdatedDate { get; set; }  
        public DateTime DeletedDate { get; set; }   

        public int Id { get; set; }

        public bool IsDeleted { get; set; }

    }
}
