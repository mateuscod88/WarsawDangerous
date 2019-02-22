using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Dangerouses.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WarsawDangerous.Models;

namespace WarsawDangerous.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDangerousesService _service;
        public HomeController(IDangerousesService service)
        {
            this._service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDangerouses()
        {
                try
                {
                    var jsonNotification = await _service.GetAllNotificationsJSON();
                    return Ok(jsonNotification);
                }
                catch (Exception e)
                {
                    return StatusCode(500, "Internal server error");
                }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
