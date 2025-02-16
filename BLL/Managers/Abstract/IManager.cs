using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Abstract
{
    public interface IManager<Tmodel, Tentity>
       where Tmodel : BaseDTOModel
       where Tentity : BaseEntity
    {
        int Add(Tmodel entity);
        void Update(Tmodel entity);
        void Remove(int id);
        void Remove(Tmodel entity);
        List<Tmodel> GetAll();
        List<Tmodel> GetWhere(Expression<Func<Tentity, bool>> predicate);
        Tmodel GetSingle(Expression<Func<Tentity, bool>> predicate);
        Tmodel GetById(int id);
    }
}
