using Hope.Models;
using Hope.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hope.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            IEnumerable<Photo> photoList = _unitOfWork.Photo.GetAll();
            return View(photoList);
        }
        public IActionResult Aboutus()
        {
            return View();
        }
        public IActionResult Missionvision()
        {
            return View();
        }
        public IActionResult History()
        {
            return View();
        }
        public IActionResult Team()
        {
            return View();
        }
        public IActionResult Joinus()
        {
            return View();
        }
        public IActionResult Management()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Activities()
        {
            return View();
        }
        public IActionResult Images()
        {
            return View();
        }
        public IActionResult Image()
        {
            return View();
        }
        public IActionResult Video()
        {
            return View();
        }
        public IActionResult Legal()
        {
            return View();
        }
        public IActionResult Reports()
        {
            return View();
        }
        public IActionResult Annual()
        {
            return View();
        }
        public IActionResult Audit()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Oldagehome()
        {
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
