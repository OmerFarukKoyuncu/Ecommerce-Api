using AutoMapper;
using BLL.DTO;
using BLL.Managers.Abstract;
using BLL.MappingProfiles;
using DAL.Entities;
using DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Concrete
{
    public class Manager<Tmodel, Tentity> : IManager<Tmodel, Tentity>
         where Tmodel : BaseDTOModel
         where Tentity : BaseEntity
    {
        private readonly Repository<Tentity> _repository;
        private readonly IMapper _mapper;

        private readonly MapperConfiguration _mapperConfiguration;
        public Manager(Repository<Tentity> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            //ManagerMappingProfile managerMappingProfile = new ManagerMappingProfile();
            //_mapperConfiguration = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(managerMappingProfile);
            //}
            //);
            //_mapper = new Mapper(_mapperConfiguration);
        }



        public virtual int Add(Tmodel entity)
        {
            return _repository.Add(_mapper.Map<Tentity>(entity));
        }

        public virtual List<Tmodel> GetAll()
        {
            return _mapper.Map<List<Tmodel>>(_repository.GetAll().ToList());
        }

        public virtual Tmodel GetById(int id)
        {
            return _mapper.Map<Tmodel>(_repository.GetById(id));
        }

        public virtual Tmodel GetSingle(Expression<Func<Tentity, bool>> predicate)
        {
            return _mapper.Map<Tmodel>(_repository.GetSingle(predicate));
        }

        public virtual List<Tmodel> GetWhere(Expression<Func<Tentity, bool>> predicate)
        {
            return _mapper.Map<List<Tmodel>>(_repository.GetWhere(predicate).ToList());
        }

        public virtual void Remove(int id)
        {
            _repository.Remove(id);
        }

        public virtual void Remove(Tmodel entity)
        {
            _repository.Remove(_mapper.Map<Tentity>(entity));
        }

        public virtual void Update(Tmodel entity)
        {
            _repository.Update(_mapper.Map<Tentity>(entity));
        }
    }
}
