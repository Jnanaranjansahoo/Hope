using Hope.Data;
using Hope.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hope.Controllers
{
    public class PhotoController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PhotoController(ApplicationDbContext db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {
           List<Photo> objPhotoList = _db.Photos.ToList();
            return View(objPhotoList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Photo obj)
        {
            _db.Photos.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }       
    }
}
