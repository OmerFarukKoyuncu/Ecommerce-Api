using DAL.Data;
using DAL.Entities;
using DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concrete
{
    public class CommentRepository : Repository<Comment>, ICommmentRepository
    {
        public CommentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }



    }
}
