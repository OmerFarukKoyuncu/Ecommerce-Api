using BLL.DTO.ContentDtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Abstract
{
    public interface IContentManager : IManager<ContentDto, Content>
    {
        ContentDto GetByName(string pageName);
    }
}
