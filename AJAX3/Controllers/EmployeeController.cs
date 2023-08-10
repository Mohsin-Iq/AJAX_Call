using Microsoft.AspNetCore.Mvc;
using AJAX3.DAL;
using AJAX3.Models;

namespace AJAX3.Controllers
{
    public class EmployeeController : Controller
    {
      public Connection con { get;  private set; }
      public  IConfiguration _configuration { get; private set; }
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
            con = new Connection(_configuration["ConnectionStrings:Defaultconnection"].ToString());
        }
        public IActionResult Index()
        {
          
            return View();
        }
        public JsonResult Create()
        {
            var add = con.GetStudents();
            return Json(add);
        }
        public JsonResult Add(string Name, string Email, string Phone)
        {
            Employee employee = new Employee
            {
                Name = Name,
                Email = Email,
                Phone = Phone,
            };

            return Json(con.Add(employee));
        }

        public JsonResult Delete(int id)
        {
            Employee employee = con.GetStudents().Where(obj => obj.EmployeeID == id).FirstOrDefault();
            con.Delete(id);
            return Json(employee);   
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
