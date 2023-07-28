using Kombox.DataAccess.Data;
using Kombox.DataAccess.Repository.IRepository;
using Kombox.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kombox.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            List<Category> categoryList = _unitOfWork.CategoryRepository.GetAll().ToList();
            return View(categoryList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {

            if (obj.DisplayOrder == null && obj.Name == null)
            {
                ModelState.AddModelError("", "Pleas enter a value into inputs");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Add(obj);
                _unitOfWork.CategoryRepository.Save();
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
            var Category_DB = _unitOfWork.CategoryRepository.Get(u => u.CategoryId == id);
            if (Category_DB == null)
            {
                return NotFound();
            }
            return View(Category_DB);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(obj);
                _unitOfWork.CategoryRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var Category_DB = _unitOfWork.CategoryRepository.Get(u => u.CategoryId == id);
            if (Category_DB == null)
            {
                return NotFound();
            }
            return View(Category_DB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCategory(int? id)
        {
            Category? categories = _unitOfWork.CategoryRepository.Get(u => u.CategoryId == id);
            if (categories == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Remove(categories);
            _unitOfWork.CategoryRepository.Save();
            TempData["Success"] = "Category Deleted Succesfully";
            return RedirectToAction("Index");

        }

    }
}
