﻿using Disaster_Guide.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Disaster_Guide.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Login()
		{
			return View();
		}
        public IActionResult Map()
        {
            return View();
        }
        public IActionResult HomePage()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
