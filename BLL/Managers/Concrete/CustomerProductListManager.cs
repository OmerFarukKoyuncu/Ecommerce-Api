using AutoMapper;
using BLL.DTO;
using BLL.DTO.CustomerProductDtos;
using BLL.DTO.OrderReportDtos;
using BLL.Managers.Abstract;
using DAL.Entities;
using DAL.Repositories.Abstract;
using DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Concrete
{
    public class CustomerProductListManager : Manager<ProductDTOModel, Product>, ICustomerProductListManager
    {
        private readonly Repository<Product> _repository;
        private readonly IMapper _mapper;

        public CustomerProductListManager(Repository<Product> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<CustomerProductDtoModel> GetCustomerProductList()
        {
            var list = _repository.GetAll();
                         

            return _mapper.Map<List<CustomerProductDtoModel>>(list.ToList());
        }
    }
}
