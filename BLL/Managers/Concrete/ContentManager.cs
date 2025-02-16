using AutoMapper;
using BLL.DTO.ContentDtos;
using BLL.Managers.Abstract;
using DAL.Entities;
using DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Concrete
{
    public class ContentManager : Manager<ContentDto, Content>, IContentManager
    {
        private readonly IMapper _mapper;
        private readonly Repository<Content> _repository;

        public ContentManager(Repository<Content> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
       


        public override List<ContentDto> GetAll()
        {
            var content = _repository.GetAll();

            return _mapper.ProjectTo<ContentDto>(content).ToList();
        }

        public override ContentDto GetById(int id)
        {
            var content = _repository.GetAll().Where(x => x.Id == id);

            return _mapper.ProjectTo<ContentDto>(content).FirstOrDefault();
        }

        public ContentDto GetByName(string pageName)
        {
            var content = _repository.GetAll().Where(x => x.PageName == pageName);

            return _mapper.ProjectTo<ContentDto>(content).FirstOrDefault();
        }

        public override void Update(ContentDto entity)
        {
            var content = _repository.GetAll().Where(x => x.Id == entity.Id).FirstOrDefault();

            if (content == null)
            {
                return;
            }
            else
            {
                content.ContentText = entity.ContentText;
            }
            _repository.Update(content);
        }



    }
}