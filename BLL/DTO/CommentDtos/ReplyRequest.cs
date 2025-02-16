using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.CommentDtos
{
    public class ReplyRequest
    {
        [Required]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "Yorum 0-500 karakter arasında olmalıdır.")]
        public string? ReplyText { get; set; }
    }
}
