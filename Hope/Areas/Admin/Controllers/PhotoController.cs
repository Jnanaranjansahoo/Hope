using Hope.Data;
using Hope.Models;
using Hope.Repository;
using Hope.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Linq;

namespace Hope.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhotoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PhotoController(IUnitOfWork unitOfWork , IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Photo> objPhotoList = _unitOfWork.Photo.GetAll().ToList();
            return View(objPhotoList);
        }
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                // Create

                return View(new Photo());
            }
            else
            {
                //Update

                Photo photoObj = _unitOfWork.Photo.Get(u=>u.Id == id);
                return View(photoObj);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Photo PhotoObj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string photoPath = Path.Combine(wwwRootPath, @"images\photo");

                    if (!string.IsNullOrEmpty(PhotoObj.ImageUrl))
                    {
                        // Delete the old images

                        var oldImagePath = Path.Combine(wwwRootPath, PhotoObj.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(photoPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    PhotoObj.ImageUrl = @"\images\photo\" + fileName;
                }
                
                if (PhotoObj.Id == 0)
                {
                    _unitOfWork.Photo.Add(PhotoObj);
                }
                else
                {
                    _unitOfWork.Photo.Update(PhotoObj);
                }
                
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(PhotoObj);
            }
             
            
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
            var photoToBeDeleted = _unitOfWork.Photo.Get(u => u.Id == id);
            if (photoToBeDeleted == null)
            {
                return Json(new { success = false, Message = "Error while deleting" });
            }
            var oldImagePath =
                            Path.Combine(_webHostEnvironment.WebRootPath,
                            photoToBeDeleted.ImageUrl.TrimStart('\\'));


            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Photo.Remove(photoToBeDeleted);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

       
    }
}
