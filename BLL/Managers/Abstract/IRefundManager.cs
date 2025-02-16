using BLL.DTO.CustomerRefundDtos;
using BLL.DTO.Seller;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers.Abstract
{
    public interface IRefundManager
    {
        public bool AddRefundChange(string userId, int productId, RequestType request);
        public List<GetRefundChangesDto> GetUserRefundsChanges(string userId);
		public List<GetRefundChangesDto> GetSellerRefundsChanges(int sellerId);
        public void DeleteRequest(int requestId);
        public void ApproveRequest(ApproveRefundChangeForSellerDto refundChangeDto);

    }
}
