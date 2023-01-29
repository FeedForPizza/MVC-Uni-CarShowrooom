using CS.Data;
using CS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CS.Controllers
{
    public class CarExtraController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string connectionString = @"Data Source=DESKTOP-C7ALLTO;Initial Catalog=CarShowroom;Integrated Security=True";
        public CarExtraController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string SortOrder, string SearchString )
       {
            ViewData["CurrentFilter"] = SearchString;
            var extras = from e in _context.carExtra select e;
        
               if (!string.IsNullOrEmpty(SearchString))
               {
               extras = extras.Where(e => e.ExtraName.Contains(SearchString));
                }

           extras = extras.OrderBy(e => e.ExtraName);
            ViewData["ExtraNameSortParam"] = string.IsNullOrEmpty(SortOrder) ? "name_sort" : "";
            ViewData["PriceSortParam"] = SortOrder == "Price" ? "price_sort" : "price_sort";
            switch (SortOrder)
            {
               case "name_sort":
                default:
                    extras = extras.OrderBy(e => e.ExtraName);
                    break;
                case "price_sort":
                    extras = extras.OrderBy(e => e.Price);
                    break;
           }
            
            return View(await extras.AsNoTracking().ToListAsync());
        }
        
    }
}
