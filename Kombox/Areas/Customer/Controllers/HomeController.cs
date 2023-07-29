using Kombox.DataAccess.Repository.IRepository;
using Kombox.Models;
using Kombox.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kombox.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.ProductRepository.GetAll(includeProperties: "Category");
            return View(productList);
        }

        public IActionResult Details(int ProductId)
        {
            //ShoppingCart cart = new()
            //{
            //    Product = _unitOfWork.ProductRepository.Get(u => u.Id == ProductId, includeProperties: "Category"),
            //    Count = 1,
            //    Product_Id = ProductId,
            //};

            //return View(cart);
            return View();
        }















        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}