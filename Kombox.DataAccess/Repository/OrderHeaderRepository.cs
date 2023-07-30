using Kombox.DataAccess.Data;
using Kombox.DataAccess.Repository.IRepository;
using Kombox.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombox.DataAccess.Repository
{
    public class OrderHeaderRepository: Repository<OrderHeader>,IOrderHeaderRepository
    {
        private ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(OrderHeader orderDetail)
        {
            _db.orderHeaders.Update(orderDetail);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDb = _db.orderHeaders.FirstOrDefault(u => u.OrderHeaderId == id);
            if (orderFromDb != null) { 
                orderFromDb.OrderStatus = orderStatus;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }
            }
        }

        public void UpdateStripePaymentId(int id, string sesionId, string paymentIntentId)
        {
            var orderFromDb = _db.orderHeaders.FirstOrDefault(u => u.OrderHeaderId == id);
            if (!string.IsNullOrEmpty(sesionId)){
                orderFromDb.SessionId = sesionId;
            }if (!string.IsNullOrEmpty(paymentIntentId)){
                orderFromDb.PaymentItentId = paymentIntentId;
                orderFromDb.PaymentDate = DateTime.Now;
            }
        }
    }

}
