using BLL.DTO;
using BLL.DTO.CustomerProductDtos;
using DAL.Entities;

namespace BLL.Managers.Abstract
{
    public interface ICustomerProductListManager : IManager<ProductDTOModel, Product>
    {
        public List<CustomerProductDtoModel> GetCustomerProductList();
    }
}
