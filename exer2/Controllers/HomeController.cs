using exer2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace exer2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult calc()
        {
            return View();
        }

        [HttpPost]
        public IActionResult calc(Numbers numbers)
        {
            int result = 0;

            switch (numbers.Opertion)
            {
                case '+': result = numbers.nOne + numbers.nTwo;break;
                case '-': result = numbers.nOne - numbers.nTwo;break;

                case '*': result = numbers.nOne * numbers.nTwo; break;
                case '/': if (numbers.nTwo == 0)
                            {
                                result = -1; 
                            }
                            else
                            {
                                result = numbers.nOne + numbers.nTwo;
                            }
                            break;

                default:
                    break;
            }
            ViewBag.n = result;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}