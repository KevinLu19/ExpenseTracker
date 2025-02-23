using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

public class ExpenseListController : Controller
{
	public IActionResult ExpenseList()
	{
		return View();
	}
}
