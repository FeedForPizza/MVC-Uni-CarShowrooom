using CS.Data;
using CS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;


namespace CS.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public async Task<IActionResult> Index(string SortOrder, string SearchString, int pg=1)
        {

            ViewData["CurrentFilter"] = SearchString;
            var extras = from e in _context.cars select e;

            if (!string.IsNullOrEmpty(SearchString))
            {
                extras = extras.Where(e => e.Model.Contains(SearchString));
            }
            

            //extras = extras.OrderBy(e => e.Model);
            ViewData["ExtraNameSortParam"] = string.IsNullOrEmpty(SortOrder) ? "name_sort" : "";
            ViewData["PriceSortParam"] = SortOrder == "HP" ? "price_sort" : "price_sort";
            switch (SortOrder)
            {
                case "name_sort":
                    default:
                    extras = extras.OrderBy(e => e.Model);
                    break;
                case "price_sort":
                    extras = extras.OrderBy(e => e.HP);
                    break;
            }
            //await extras.AsNoTracking().ToListAsync();
            const int pageSize = 2;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = extras.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = await extras.Skip(recSkip).Take(pager.PageSize).AsNoTracking().ToListAsync();
            this.ViewBag.Pager = pager;
            //return View(await extras.AsNoTracking().ToListAsync());
            
            return View(data);
        }
      /*  public IActionResult Index()
        {
            List<Cars> cars = new List<Cars>();
            CarsDAO carsDAO = new CarsDAO();
            cars = carsDAO.FetchAll();
            return View("Index",cars);
        }*/
        public ActionResult Details(int id)
        {
            CarsDAO carsDAO = new CarsDAO();
            Cars cars = carsDAO.FetchOne(id);
            return View("Details",cars);
        }
        public ActionResult Create()
        {
                return View("Create");
                
        }
        public ActionResult Edit(int id)
        {
            CarsDAO carsDAO = new CarsDAO();
            Cars cars = carsDAO.FetchOne(id);
            return View("Create",cars);

        }
        public ActionResult ProcessCreate(Cars cars)
        {
            CarsDAO carsDAO = new CarsDAO();
            carsDAO.CreateOrUpdate(cars);
            TempData["success"] = "Успешно създадена кола! ";
            return View("Details", cars);

        }
        public ActionResult Delete(int id)
        {
            CarsDAO carsDAO = new CarsDAO();
            carsDAO.Delete(id);
            List<Cars> cars = carsDAO.FetchAll();
            TempData["success"] = "Колата беше изтрита! ";
            return View("Index", cars);

        }
        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }
        public ActionResult SearchForModel(string searchPhrase)
        {
            CarsDAO carsDAO=new CarsDAO();
            List<Cars> searchResults = carsDAO.SearchForName(searchPhrase);
            return View("Index", searchResults);
        }


    }
}
