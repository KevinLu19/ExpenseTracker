using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

public class UploadController : Controller
{
	// Grabs the cshtml file.
	public IActionResult Upload()
	{
		return View();
	}

	
}
