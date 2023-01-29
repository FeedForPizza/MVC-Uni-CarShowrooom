using CS.Data;
using CS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace CS.Controllers
{
    public class TestDriveController : Controller

    {
        private readonly ApplicationDbContext _context;

        public TestDriveController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<TestDrive> td = _context.testDrive;
            return View(td);
        }
        //public IActionResult Index()
        //{
        //    List<TestDrive> td = new List<TestDrive>();
        //    TDDAO tdDAO = new TDDAO();
        //    td = tdDAO.FetchAll();
        //    return View("Index", td);  

        //}

        public ActionResult Details(int id)
        {
            TDDAO tdDAO = new TDDAO();
            TestDrive td = tdDAO.FetchOne(id);
            return View("Details", td);
        }
        public ActionResult Edit(int?id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var testDriveFromDB = _context.testDrive.Find(id);
            if (testDriveFromDB == null)
            {
                return NotFound();
            }
            return View(testDriveFromDB);   

        }



        [HttpPost]
        public ActionResult Edit(TestDrive td)
        {
            if (!ModelState.IsValid)
            {
                _context.testDrive.Update(td);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(td);
        }
        public ActionResult Create()
        {
            var modelList= (from model in _context.cars
                                select new SelectListItem()
                                {
                                    Value = model.Model,
                                    Text = model.Model
                                    
                                }).ToList();

            modelList.Insert(0, new SelectListItem()
            {
                Text = "Моля изберете кола",
                Value = string.Empty
            });

            ViewBag.Listofmodels = modelList;
            return View();
            
        }


        
        [HttpPost]
        public ActionResult Create(TestDrive td)
        {

            var selected = td.Model;
            _context.testDrive.Add(td);
                _context.SaveChanges();
            TempData["success"] = "Успешно заявен тест драйв! ";
            
                return View("Details",td);
            
            

        }
        public ActionResult Delete(int id)
        {
            var delitem = _context.testDrive.Find(id);
            if(delitem == null)
            {
                return NotFound();
            }
            _context.testDrive.Remove(delitem);
            _context.SaveChanges();
            TempData["success"] = "Тест драйвът беше изтрит! ";
            return RedirectToAction("Index");

        }
    }
}
