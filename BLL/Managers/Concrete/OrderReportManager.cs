using AutoMapper;
using BLL.DTO.OrderDtos;
using BLL.DTO.OrderProductDtos;
using BLL.DTO.OrderReportDtos;
using BLL.Managers.Abstract;
using DAL.Entities;
using DAL.Repositories.Abstract;
using DAL.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Concrete
{
    //deniz
    public class OrderReportManager : Manager<OrderDto, Order>, IOrderReportManager
    {
        private readonly IMapper _mapper;
        private readonly Repository<Order> _repository;

        public OrderReportManager(IMapper mapper, Repository<Order> repository) : base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public   List<OrderReportDto> GetOrderReport()
        {
            var list = (from order in _repository.GetAll() // Verileri repository'den al
                        select new OrderReportDto // Her bir öğeyi OrderReportDto'ya dönüştür
                        {

                            OrderId = order.Id,
                            UserId = order.UserId,
                            Status = order.Status,
                            UserFirstName = order.User.Firstname,
                            UserLastName = order.User.Lastname,
                            SellerName = order.OrderProducts.First().Product.Seller.Name,
                            UserName = order.User.UserName,
                            TotalPrice = order.OrderProducts.Sum(x => (decimal)x.Quantity * x.Product.Price ?? 0),
                            TotalQuantity = order.OrderProducts.Sum(x => (decimal)x.Quantity),
                            OrderDate = order.CreatedDate
                        }).ToList(); // Listeye dönüştür

            return list;
        }

        public List<OrderProductReportDTO> GetOrderProductReport()
        {
            var productList = (from order in _repository.GetAll() // Tüm siparişleri al
                               from orderProduct in order.OrderProducts // Her siparişin ürünlerini düzleştir
                               select new OrderProductReportDTO // DTO'ya dönüştür
                               {
                                   OrderId = order.Id,
                                   UserId = order.UserId,
                                   Status = order.Status,
                                   UserFirstName = order.User.Firstname,
                                   UserLastName = order.User.Lastname,
                                   SellerName = orderProduct.Product.Seller.Name,
                                   UserName = order.User.UserName,
                                   ProductName = orderProduct.Product.Name,
                                   Description = orderProduct.Product.Description,
                                   Price = (decimal)orderProduct.Quantity * (orderProduct.Product.Price ?? 0),
                                   Quantity = (decimal)orderProduct.Quantity,
                                   OrderDate = order.CreatedDate
                               }).ToList(); // Listeye dönüştür

            return productList;
        }



        public List<OrderCustomerReportDTO> GetOrderCustomerReport()
        {
            var productList = (from order in _repository.GetAll() // Get all orders
                               from orderProduct in order.OrderProducts // Flatten each order's products
                               group orderProduct by new
                               {
                                   order.User.Firstname,
                                   order.User.Lastname,
                                   order.User.UserName
                               } into groupedData // Group by user attributes
                               select new OrderCustomerReportDTO // Map to DTO
                               {
                                   UserFirstName = groupedData.Key.Firstname,
                                   UserLastName = groupedData.Key.Lastname,
                                   UserName = groupedData.Key.UserName,
                                   TotalQuantity = groupedData.Sum(op => (decimal?)op.Quantity ?? 0), // Sum quantities
                                   TotalPrice = groupedData.Sum(op => ((decimal?)op.Quantity ?? 0) * (op.Product.Price ?? 0)), // Calculate total price
 
                               }).ToList(); // Convert to a list

            return productList;
        }


        public List<OrderSellerReportDTO> GetOrderSellerReport()
        {
            var sellerList = (from order in _repository.GetAll() // Get all orders
                               from orderProduct in order.OrderProducts // Flatten each order's products
                               group orderProduct by new
                               {
                                   orderProduct.Product.Seller.Name,
                                   orderProduct.Product.Seller.Id

                               } into groupedData // Group by user attributes
                               select new OrderSellerReportDTO // Map to DTO
                               {
                                    SellerName = groupedData.Key.Name,
                                   SellerId = groupedData.Key.Id,
                              
                                   TotalQuantity = groupedData.Sum(op => (decimal?)op.Quantity ?? 0), // Sum quantities
                                   TotalPrice = groupedData.Sum(op => ((decimal?)op.Quantity ?? 0) * (op.Product.Price ?? 0)), // Calculate total price

                               }).ToList(); // Convert to a list

            return sellerList;
        }

		public List<OrderProductReportDTO> GetOrderProductReportBySeller(int sellerId)
		{
			var productList = (from order in _repository.GetAll().Where(x=>x.SellerId == sellerId) // Tüm siparişleri al
							   from orderProduct in order.OrderProducts // Her siparişin ürünlerini düzleştir
							   select new OrderProductReportDTO // DTO'ya dönüştür
							   {
								   OrderId = order.Id,
								   UserId = order.UserId,
								   Status = order.Status,
								   UserFirstName = order.User.Firstname,
								   UserLastName = order.User.Lastname,
								   SellerName = orderProduct.Product.Seller.Name,
								   UserName = order.User.UserName,
								   ProductName = orderProduct.Product.Name,
								   Description = orderProduct.Product.Description,
								   Price = (decimal)orderProduct.Quantity * (orderProduct.Product.Price ?? 0),
								   Quantity = (decimal)orderProduct.Quantity,
								   OrderDate = order.CreatedDate
							   }).ToList(); // Listeye dönüştür

			return productList;
		}

        public List<MonthlyOrderReportDto> MonthlyOrderReports(int sellerId, int year)
        {
            var monthlyReport = _repository.GetWhere(o => o.CreatedDate.Year == year && o.SellerId == sellerId)
         .GroupBy(o => new { o.CreatedDate.Year, o.CreatedDate.Month })
         .Select(g => new MonthlyOrderReportDto
         {
             Year = g.Key.Year,
             Month = g.Key.Month,
             TotalOrders = g.Count(),
         })
         .ToList();

            return monthlyReport;
        }
    }
}

