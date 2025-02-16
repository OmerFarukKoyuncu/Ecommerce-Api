﻿using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Promotion:BaseEntity
    {
        public string PromotionName { get; set; } // Name of the promotion (e.g., "Summer Sale")
        public PromotionStatus DiscountType { get; set; } // Type of discount: "Percentage" or "FixedAmount"
        public decimal DiscountValue { get; set; } // Discount value (e.g., 10% or $5)
        public DateTime StartDate { get; set; } // Promotion start date
        public DateTime EndDate { get; set; } // Promotion end date
        public bool IsActive
        {
            get
            {
                // Check if the promotion is currently active based on dates
                return DateTime.UtcNow >= StartDate && DateTime.UtcNow <= EndDate;
            }
        }

        public int ProductId { get; set; }

        virtual public List<ProductPromotion> ProductPromotions { get; set; }
    }
}
