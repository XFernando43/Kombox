using Kombox.DataAccess.Repository.IRepository;
using Kombox.Models.Models;
using Kombox.Models.ViewModel;
using Kombox.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kombox.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<OrderHeader> objOrderList = _unitOfWork.OrderHeaderRepository.GetAll(includeProperties: "ApplicationUser").ToList();
            return View(objOrderList); 
        }
        public IActionResult Details(int OrderId)
        {
            OrderVM orderVM = new()
            {
                orderHeader = _unitOfWork.OrderHeaderRepository.Get(u => u.OrderHeaderId == OrderId, includeProperties: "ApplicationUser"),
                orderDetails = _unitOfWork.OrderDetailRepository.GetAll(u => u.OrderHeaderId == OrderId).ToList(),
            };
            return View(orderVM);
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll(string status)
        {
            List<OrderHeader> objOrderList = _unitOfWork.OrderHeaderRepository.GetAll(includeProperties: "ApplicationUser").ToList();

            switch (status)
            {
                case "pending":
                    objOrderList = objOrderList.Where(u => u.PaymentStatus == SD.Payment_StatusPending).ToList();
                    break;
                case "inprocess":
                    objOrderList = objOrderList.Where(u => u.PaymentStatus == SD.Status_InProcess).ToList();
                    break;
                case "completed":
                    objOrderList = objOrderList.Where(u => u.PaymentStatus == SD.Status_Shipped).ToList();
                    break;
                case "approved":
                    objOrderList = objOrderList.Where(u => u.PaymentStatus == SD.Status_Approved).ToList();
                    break;
                default:
                    break;
            }
    


            return Json(new { data = objOrderList });
        }
        #endregion
    }

}
