using BLL.DTO.OrderDtos;
using BLL.DTO.OrderProductDtos;
using BLL.DTO.OrderReportDtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Abstract
{
    //deniz
    public interface IOrderReportManager : IManager<OrderDto, Order>
    {
        public List<OrderReportDto> GetOrderReport();

        public List<OrderProductReportDTO> GetOrderProductReport();
        public List<OrderProductReportDTO> GetOrderProductReportBySeller(int sellerId);
        public List<OrderCustomerReportDTO> GetOrderCustomerReport();
        public List<OrderSellerReportDTO> GetOrderSellerReport();

        public List<MonthlyOrderReportDto> MonthlyOrderReports(int sellerId, int year);


    }

 
}
