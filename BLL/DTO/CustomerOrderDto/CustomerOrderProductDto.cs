using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.DTO.CustomerOrderDto
{
    public class CustomerOrderProductDto:BaseDTOModel
    {

        public int ProductId { get; set; }  // Ürünün ID'si
        public string ProductName { get; set; }  // Ürünün adı
        public double? Quantity { get; set; }  // Adet
        public decimal? Price { get; set; }  // Fiyat

        public int? CustomerRating { get; set; }
        public string? CustomerEvaluation { get; set; }

    }
}
