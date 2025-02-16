using AutoMapper;
using BLL.DTO.CustomerRefundDtos;
using BLL.DTO.Seller;
using BLL.Managers.Abstract;
using DAL.Entities;
using DAL.Enums;
using DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Concrete
{
    public class RefundManager : IRefundManager
    {
        private readonly IRepository<RefundChange> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<OrderProduct> _orderProductRepository;
        private readonly IRepository<Order> _orderRepository;

        public RefundManager(IRepository<RefundChange> repository, IMapper mapper, IRepository<OrderProduct> orderProductRepository, IRepository<Order> orderRepository)

        {
            _repository = repository;
            _mapper = mapper;
            _orderProductRepository = orderProductRepository;
            _orderRepository = orderRepository;
        }

        public bool AddRefundChange(string userId, int productId, RequestType request)
        {
            var existingRefundChange = _repository.GetWhere(x => x.ProductId == productId && x.UserId == userId).FirstOrDefault();
            if (existingRefundChange == null)
            {
                var refundChangeDto = new AddRefundChangeDto
                {
                    UserId = userId,
                    ProductId = productId,
                    Request = request,
                };

                var refundChange = _mapper.Map<RefundChange>(refundChangeDto);
                _repository.Add(refundChange);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ApproveRequest(ApproveRefundChangeForSellerDto refundChangeDto)
        {
            //if (refundChangeDto.Request == RequestType.Refund)
            //{
            //    var orderProducts = _orderProductRepository.GetAll().Where(x => x.ProductId == refundChangeDto.productId && x.Order.UserId == refundChangeDto.userId).ToList();
            //    foreach (var item in orderProducts)
            //    {
            //        var ordertoUpdate = _orderRepository.GetById(item.OrderId);
            //        ordertoUpdate.Status = OrderStatus.Canceled;
            //        _orderRepository.Update(ordertoUpdate);

            //    }
            //}
            //else
            //{
            //    var orderProducts = _orderProductRepository.GetAll().Where(x => x.ProductId == refundChangeDto.productId && x.Order.UserId == refundChangeDto.userId).ToList();
            //    foreach (var item in orderProducts)
            //    {
            //        var ordertoUpdate = _orderRepository.GetById(item.OrderId);
            //        ordertoUpdate.Status = OrderStatus.Returned;
            //        _orderRepository.Update(ordertoUpdate);


            //    }
            //}
        }

        public void DeleteRequest(int requestId)
        {

            _repository.Remove(requestId);
        }

        public List<GetRefundChangesDto> GetSellerRefundsChanges(int sellerId)
        {
            var refundChanges = _repository.GetAll().Where(x => x.Product.SellerId == sellerId && x.IsDeleted == false).ToList();
            var refundChangesDtos = _mapper.Map<List<GetRefundChangesDto>>(refundChanges);
            return refundChangesDtos;
        }

        public List<GetRefundChangesDto> GetUserRefundsChanges(string userId)
        {
            var refundChanges = _repository.GetAll().Where(x => x.UserId == userId && x.IsDeleted == false).ToList();
            var refundChangesDtos = _mapper.Map<List<GetRefundChangesDto>>(refundChanges);
            return refundChangesDtos;
        }
    }
}
