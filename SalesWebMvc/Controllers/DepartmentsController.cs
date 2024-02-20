using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> departmentsList = new List<Department>();
            departmentsList.Add(new Department { Id = 1, Name = "Eletronics"});
            departmentsList.Add(new Department { Id = 2, Name = "Fashion" });
            return View(departmentsList);
        }
    }
}
