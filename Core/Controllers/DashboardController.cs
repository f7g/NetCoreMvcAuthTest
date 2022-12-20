using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Microsoft.AspNetCore.Authorization;

namespace Core.Controllers;

[Authorize]
public class DashboardController : Controller {
    private readonly ILogger<HomeController> _logger;

    public DashboardController(ILogger<HomeController> logger) {
        _logger = logger;
    }

    public IActionResult Index() {
        return View();
    }
}
