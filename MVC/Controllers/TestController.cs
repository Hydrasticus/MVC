using Core;
using Facade;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers {
    
    public class TestController : Controller {
        
        public ActionResult GetView() {
            var emp = new Employee("Sukesh", "Maria", 20000);

            var vmEmp = new EmployeeViewModel(emp, "Admin");
            return View("MyView", vmEmp);
        }
    }
}
