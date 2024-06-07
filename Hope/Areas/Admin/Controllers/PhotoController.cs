using Hope.Data;
using Hope.Models;
using Hope.Repository;
using Hope.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Hope.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhotoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PhotoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Photo> objPhotoList = _unitOfWork.Photo.GetAll().ToList();
            return View(objPhotoList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Photo obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Photo.Add(obj);
                _unitOfWork.Save();
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
            Photo? photoFromDb = _unitOfWork.Photo.Get(u => u.Id == id);
            if (photoFromDb == null)
            {
                return NotFound();
            }
            return View(photoFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Photo obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Photo.Update(obj);
                _unitOfWork.Save();
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
            Photo? photoFromDb = _unitOfWork.Photo.Get(u => u.Id == id);
            if (photoFromDb == null)
            {
                return NotFound();
            }
            return View(photoFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Photo? obj = _unitOfWork.Photo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Photo.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
