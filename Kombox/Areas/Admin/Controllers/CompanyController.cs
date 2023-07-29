using Bulky.Models.ViewModel;
using Kombox.DataAccess.Repository.IRepository;
using Kombox.Models.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kombox.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }
        public IActionResult Index()
        {
            List<Company> companys = _unitOfWork.CompanyRepository.GetAll().ToList();
            return View(companys);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Company obj)
        {
            if (obj == null)
            {
                ModelState.AddModelError("", "Pleas enter a value into inputs");
            }
            else
            {
                _unitOfWork.CompanyRepository.Add(obj);
                _unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var Company_DB = _unitOfWork.CompanyRepository.Get(u => u.CompanyId == id);
            if (Company_DB == null)
            {
                return NotFound();
            }
            return View(Company_DB);
        }

        [HttpPost]
        public IActionResult Edit(Company obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CompanyRepository.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.CompanyRepository.Get(u => u.CompanyId == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error deleting product" });
            }
            
            _unitOfWork.CompanyRepository.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "deleting product successfully" });

        }

    }
}
