using ANB_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace ANB_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _Configure;
        private readonly string apiBaseUrl;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("WebAPIBaseUrl");
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewModel view = new ViewModel();
            return View(view);
        }

        [HttpPost]
        public ActionResult Index(ViewModel viewModel)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                    string endpoint = apiBaseUrl + viewModel.Radius;
                    using (var Response = client.GetAsync(endpoint))
                    {
                        if (Response.Result != null)
                        {
                            var area = Response.Result;
                            var readTask = area.Content.ReadAsStringAsync();
                            var calculation = JObject.Parse(readTask.Result);
                            ViewModel model = new ViewModel();

                            model.Area = Convert.ToDecimal(calculation["area"]);
                            model.Diameter = Convert.ToDecimal(calculation["diameter"]);
                            model.Circumference = Convert.ToDecimal(calculation["circumference"]);
                            model.Progress = Convert.ToInt32(calculation["progress"]);
                            model.Status = Convert.ToString(calculation["status"]);

                            stopwatch.Stop();                            
                            model.ExceutionTime = Convert.ToString(stopwatch.Elapsed);

                            return View(model);
                        }
                        else
                        {
                            ModelState.Clear();
                            ModelState.AddModelError(string.Empty, "Radius out of Range");
                            return View();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Unexcpected Error");
                _logger.LogError("Unexcpected Error", ex);
                return View();
            }

        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
