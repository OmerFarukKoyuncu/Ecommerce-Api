using AutoMapper;
using BLL.DTO;
using BLL.DTO.Category;
using BLL.DTO.CommentDtos;
using BLL.DTO.ProductDtos;
using BLL.DTO.Seller;
using BLL.Managers.Abstract;
using DAL.Entities;
using DAL.Repositories.Abstract;
using DAL.Repositories.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Concrete
{
    public class ProductManager : Manager<ProductDTOModel, Product>, IProductManager
    {
        private readonly Repository<Product> _productRepository;
        private readonly Repository<ProductCategory> _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductManager(Repository<Product> productRepository, Repository<ProductCategory> productCategoryRepository, IMapper mapper) : base(productRepository, mapper)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;


        }
        public void AddProduct(AddProductDtoModel addProductDtoModel)
        {


            string? PhotoUrl = null;
            var product = _mapper.Map<Product>(addProductDtoModel);

            

            var addedProduct = _productRepository.Add(product);

            foreach (var item in addProductDtoModel.CategoryIds)
            {
                var productCategory = new ProductCategory
                {
                    CategoryId = item,
                    ProductId = addedProduct
                };
                _productCategoryRepository.Add(productCategory);
            }


        }

        public void UpdateProduct( UpdateProductDtoModel updateProductDtoModel)
        {

            var product = _productRepository.GetById(updateProductDtoModel.Id);
            product.Name = updateProductDtoModel.Name;
            product.Description = updateProductDtoModel.Description;
            product.Price = updateProductDtoModel.Price;
            product.Stock = updateProductDtoModel.Stock;

            product.PhotoUrl = updateProductDtoModel.PhotoUrl;

            _productRepository.Update(product);
        }
        public List<GetAllProductWithCategoriesDtoModel> GetAllProductsWithCategories()
        {
            var products = _productRepository.GetAll().ToList();

            var result = products.Select(product => new GetAllProductWithCategoriesDtoModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                PhotoUrl = product.PhotoUrl,
                ProductCategories = product.ProductCategories.Select(pc => new ProductCategoryDtoModel
                {
                    ProductId = pc.ProductId,
                    CategoryId = pc.Category.Id,
                    Category = new CategoryDTOModel
                    {
                        
                        Name = pc.Category.Name,
                        Description = pc.Category.Description
                    }
                }).ToList()
            }).ToList();

            return result;
        }

        public GetProductsDetailsDtoModel GetProductDetails(int id)
        {

            var product = _productRepository.GetWhere(p => p.Id == id).FirstOrDefault();

            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            var seller = product.Seller; 
            var productCategories = product.ProductCategories;
            var comments = product.Comments;

            return new GetProductsDetailsDtoModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                PhotoUrl = product.PhotoUrl,
                Seller = new SellerDTOModel
                {
                    Id = seller.Id,
                    Name = seller.Name,
                    CompanyName = seller.CompanyName,
                    ContactInfo = seller.ContactInfo,
                    IsApproved = seller.IsApproved,
                    ProfilePictureUrl = seller.ProfilePictureUrl
                },
                Categories = productCategories.Select(pc => new ProductCategoryDtoModel
                {
                    ProductId = pc.ProductId,
                    CategoryId = pc.CategoryId,
                    Category = new CategoryDTOModel
                    {
                        Id = pc.Category.Id,
                        Name = pc.Category.Name,
                        Description = pc.Category.Description
                    }
                }).ToList(),
                Comments = comments.Select(x => _mapper.Map<CommentManagerDto>(x)).ToList()
            };
        }

        public List<GetAllProductsDtoModel> GetProductsBySeller(int sellerId)
        {

            var products=_productRepository.GetWhere(p => p.SellerId== sellerId).ToList();
            return(_mapper.Map<List<GetAllProductsDtoModel>>(products));

        }

        public void UpdateStockAfterOrder(ShopCartDto shopCartDto)
        {
            foreach (var item in shopCartDto.Items)
            {
                var product = _productRepository.GetById(item.ProductId);
                product.Stock = product.Stock - item.Quantity;
                _productRepository.Update(product);
            }
        }
    }
}

