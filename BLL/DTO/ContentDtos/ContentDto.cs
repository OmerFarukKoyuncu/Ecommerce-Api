using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.ContentDtos
{
    public class ContentDto : BaseDTOModel
    {
        public string PageName { get; set; }
        public string ContentText { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
