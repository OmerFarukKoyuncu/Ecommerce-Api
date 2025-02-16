using BLL.DTO;
 
using BLL.DTO.ProductDtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Abstract
{
    public interface IProductManager: IManager<ProductDTOModel, Product>
    {
        public void AddProduct(AddProductDtoModel addProductDtoModel);
        public void UpdateStockAfterOrder(ShopCartDto shopCartDto);
        public void UpdateProduct( UpdateProductDtoModel updateProductDtoModel);
        public List<GetAllProductWithCategoriesDtoModel> GetAllProductsWithCategories();
        public GetProductsDetailsDtoModel GetProductDetails(int id);

        public List<GetAllProductsDtoModel> GetProductsBySeller(int sellerId);
    }
}
