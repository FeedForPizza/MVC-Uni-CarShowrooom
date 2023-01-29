using CS.Data;
using CS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CS.Controllers
{
    public class StorageController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StorageController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Storage> st = _context.storage;
            return View(st);
        }
    }
}
