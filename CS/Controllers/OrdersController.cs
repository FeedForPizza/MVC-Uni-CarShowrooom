using CS.Data;
using CS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace CS.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //List<Orders> order = new List<Orders>();
            //OrderDAO orderDAO = new OrderDAO();
            //order = orderDAO.FetchAll();
            //return View("Index", order);
            IEnumerable<Orders> td = _context.orders;
            return View(td);
        }
        public ActionResult Details(int id)
        {
            OrderDAO orderDAO = new OrderDAO();
            Orders orders = orderDAO.FetchOne(id);
            return View("Details", orders);
        }
        public ActionResult Create()
        {
            

            var modelList = (from model in _context.cars
                             select new SelectListItem()
                             {
                                 Value = model.Model,
                                 Text = model.Model,

                             }).ToList();
            
            modelList.Insert(0, new SelectListItem()
            {
                Text = "Моля изберете кола",
                Value = string.Empty
            });
            
            ViewBag.Listofmodels = modelList;
            var priceList = (from model in _context.cars
                             select new SelectListItem()
                             {
                                 Value = model.OriginalPrice.ToString(),
                                 Text = model.Model,

                             }).ToList();
            
            ViewBag.pricelist = priceList;
            
            return View();
        }
        public ActionResult Edit(int id)
        {
            OrderDAO orderDAO = new OrderDAO();
            Orders orders = orderDAO.FetchOne(id);
            return View("Edit", orders);

        }
        public ActionResult ProcessEdit(Orders orders)
        {
            OrderDAO orderDAO = new OrderDAO();
            orderDAO.Edit(orders);
            return View("Details", orders);

        }
        [HttpPost]
        
        public ActionResult ProcessCreate(Orders orders)
        {
            var selected = orders.Extra;
            var priceSelect = orders.OriginalPrice;
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-C7ALLTO;Initial Catalog=CarShowroom;Integrated Security=True");
                string sqlquery = "INSERT INTO dbo.orders (Extra,OriginalPrice,SumOfOrder,Quantity,ClientFirstName,ClientMiddleName,ClientLastName,Phone,Address)" +
                " Values(@Extra,@OriPrice,@SOO,@Quantity,@ClientFirstName,@ClientMiddleName,@ClientLastName,@Phone,@Address)";
                SqlCommand cmd = new SqlCommand(sqlquery, conn);
                conn.Open();
            cmd.Parameters.Add("@Extra", System.Data.SqlDbType.VarChar, 1000).Value = selected;
            cmd.Parameters.Add("@OriPrice",System.Data.SqlDbType.Decimal).Value = priceSelect;
            cmd.Parameters.Add("@SOO", System.Data.SqlDbType.Decimal).Value = priceSelect;
            cmd.Parameters.Add("@Quantity", System.Data.SqlDbType.Int, 1000).Value = orders.Quantity;
            cmd.Parameters.Add("@ClientFirstName", System.Data.SqlDbType.VarChar, 1000).Value = orders.ClientFirstName;
            cmd.Parameters.Add("@ClientMiddleName", System.Data.SqlDbType.VarChar, 1000).Value = orders.ClientMiddleName;
            cmd.Parameters.Add("@ClientLastName", System.Data.SqlDbType.VarChar, 1000).Value = orders.ClientLastName;
            cmd.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar, 1000).Value = orders.Phone;
            cmd.Parameters.Add("@Address", System.Data.SqlDbType.VarChar, 1000).Value = orders.Address;
            cmd.ExecuteNonQuery();

            //_context.orders.Add(orders);
            //_context.SaveChanges();
            TempData["success"] = "Успешно създадена поръчка! ";
            return View("Details", orders);

        }
        public ActionResult Delete(int id)
        {
            OrderDAO orderDAO = new OrderDAO();
            orderDAO.Delete(id);
            List<Orders> orders = orderDAO.FetchAll();
            return View("Index", orders);

        }
    }
}
