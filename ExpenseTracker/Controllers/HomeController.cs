using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.src.Controllers;

public class HomeController : Controller
{
	public IActionResult Index()
	{
		return View();	// Will look for "Index.cshtml" in Views/Home
	}
}
