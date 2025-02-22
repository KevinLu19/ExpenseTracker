namespace ExpenseTracker;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllersWithViews();

		var app = builder.Build();

		app.UseRouting();
		app.UseAuthorization();
		app.UseStaticFiles();

		// add MVC Routing
		app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=Index}/{id?}");

		app.Run();
	}
}