using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.CommentDtos
{
    public class CommentRequest
    {
        
        [StringLength(500, MinimumLength = 0, ErrorMessage = "Yorum 0-500 karakter arasında olmalıdır.")]
        public string? Content { get; set; }

        [Range(1, 5, ErrorMessage = "Puan 1 ile 5 arasında olmalıdır.")]
        public int? ProductRate { get; set; }
    }
}
