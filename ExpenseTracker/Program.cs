using DotNetEnv;
using MySql.Data.MySqlClient;

namespace ExpenseTracker;

public class Program
{
	public static void Main(string[] args)
	{
		// Load DB password from ENV
		Env.Load();
		string? db_pass = Environment.GetEnvironmentVariable("PC_DATABASE_PASS");

		MySql mysql_db = new MySql();

		// Create mysql connection string.
		string conn_string = $"Server=127.0.0.1;Database=expense_tracker;User ID=root;Password={db_pass};SSL Mode=None;";

		MySqlConnection conn = new MySqlConnection(conn_string);

		// Connect + Get table data info
		try
		{
			Console.WriteLine("Connecting to MySQL...");
			conn.Open();

			// Check if any tables exist
			string table_chk = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'expense_tracker'";

			using (MySqlCommand cmd = new MySqlCommand(table_chk, conn))
			{
				int table_count = Convert.ToInt32(cmd.ExecuteScalar());

				if (table_count > 0)
					Console.WriteLine($"There's {table_count} in the database");
				else
					Console.WriteLine("No Tables in the database");
			}

			conn.Close();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		// ASP.NET Core
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