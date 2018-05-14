using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers {
    public class TestController : Controller {
        public string GetString() {
            return "Hello world!";
        }
    }
}
