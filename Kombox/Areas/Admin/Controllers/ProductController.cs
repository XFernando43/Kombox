using Bulky.Models.ViewModel;
using Kombox.DataAccess.Repository.IRepository;
using Kombox.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;

namespace Kombox.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork uow, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = uow;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.ProductRepository.GetAll(includeProperties: "Category").ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                }),
                product = new Product(),
            };
            return View(productVM);

        }
        [HttpPost]
        public IActionResult Create(ProductVM obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRothPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRothPath, @"images\product");
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.product.ImageUrl = @"\images\product\" + fileName;
                }

                _unitOfWork.ProductRepository.Add(obj.product);
                _unitOfWork.Save();
                TempData["Success"] = "Category Created Succesfully";
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var Product_Db = _unitOfWork.ProductRepository.Get(u => u.ProductId == id);
            if (Product_Db == null)
            {
                return NotFound();
            }
            return View(Product_Db);
        }
        [HttpPost]
        public IActionResult Edit(Product product, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
             
                string wwwRothPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRothPath, @"images\product");
                    
                    if (!string.IsNullOrEmpty(product.ImageUrl))
                    {
                        // Delete old image
                        var oldImagePath = Path.Combine(wwwRothPath, product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    product.ImageUrl = @"\images\product\" + fileName;
                }
               
               
                _unitOfWork.ProductRepository.Update(product);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        //public IActionResult Delete(int? id)
        //{
        //    if (id == 0 || id == null)
        //    {
        //        return NotFound();
        //    }
        //    var Product_Db = _unitOfWork.ProductRepository.Get(u => u.Id == id);
        //    if (Product_Db == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(Product_Db);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteProduct(int? Id)
        //{
        //    Product? product = _unitOfWork.ProductRepository.Get(u => u.Id == Id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.ProductRepository.Remove(product);
        //    _unitOfWork.Save();
        //    TempData["Success"] = "Product Deleted Succesfully";
        //    return RedirectToAction("Index");
        //}



        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.ProductRepository.Get(u => u.ProductId == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error deleting product" });
            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.ProductRepository.Remove(obj);
            _unitOfWork.Save();
            //return RedirectToAction("Index");
            return Json(new { success = true, message = "deleting product successfully" });
        }

    }
}
