using DotNetEnv;
using MySql.Data.MySqlClient;
using Xunit.Abstractions;

namespace TestExpenseTracker;

public class TestMySql
{
	private string _db_pass;

	private readonly ITestOutputHelper _test_ouput;

	public TestMySql(ITestOutputHelper output)
	{
		_test_ouput = output;

		// Load ENV file from main project.
		string project_root = @"C:\Users\Kevin\Desktop\Programming Project\CSharp\repos\ExpenseTracker\ExpenseTracker\ExpenseTracker";
		string env_path = System.IO.Path.Combine(project_root, ".env");

		// Load ENV
		Env.Load(env_path);
	}

	[Fact]
	public void TestEnv()
	{
		_db_pass = Environment.GetEnvironmentVariable("PC_DATABASE_PASS");

		Assert.NotNull(_db_pass);
	}

	public bool TestConnection()
	{
		_db_pass = Environment.GetEnvironmentVariable("PC_DATABASE_PASS");

		string connection = $"Server=127.0.0.1;Database=expense_tracker;User ID=root;Password={_db_pass};SSL Mode=Required;";

		MySqlConnection try_conn = new MySqlConnection(connection);
		try
		{
			try_conn.Open();

			_test_ouput.WriteLine("Connection successful");

			try_conn.Close();

			return true;
		}
		catch (Exception ex)
		{
			_test_ouput.WriteLine(ex.Message);
		}

		return false;
	}

	[Fact]
	public void GetAllTables()
	{
		// Make connection to DB.
		_db_pass = Environment.GetEnvironmentVariable("PC_DATABASE_PASS");

		string connection = $"Server=127.0.0.1;Database=expense_tracker;User ID=root;Password={_db_pass};SSL Mode=Required;";

		MySqlConnection conn = new MySqlConnection(connection);
		string query = "SHOW TABLES;";

		// Try and fetch tables
		try
		{
			conn.Open();

			_test_ouput.WriteLine("Connection successful");

			// Run query command.			
		}
		catch (Exception ex)
		{
			_test_ouput.WriteLine(ex.Message);
		}
	}

	[Fact]
	public void GetResultsInTable()
	{

	}
}
