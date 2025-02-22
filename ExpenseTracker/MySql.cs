using MySql.Data.MySqlClient;
using DotNetEnv;

namespace ExpenseTracker;

// Database -> MariaBD / MySql
public class MySql
{
	public MySql()
	{
		//Env.Load();
		//string? db_pass = Environment.GetEnvironmentVariable("PC_DATABASE_PASS");

		//// Check environment variable if null 
		//if (db_pass != null)
		//{
		//	Console.WriteLine($"{db_pass} is not null");
		//}

		//MySqlConnection my_connection;
		//string conn_string = $"Server=127.0.0.1;Database=expense_tracker;User ID=root;Password={db_pass};SSL Mode=None;";

		//// Connect to database 
		//using (MySqlConnection conn = new MySqlConnection(conn_string))
		//{
		//	try
		//	{
		//		conn.Open();
		//		Console.WriteLine("Successfully connected to the databse.");

		//		// run query...

		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine("Something went wrong with the connection to the database");
		//		Console.WriteLine(ex.Message);
		//	}
		//}

		
	}

	// Displays the collection of given table.
	public void DisplayData(System.Data.DataTable table)
	{
		foreach (System.Data.DataRow row in table.Rows)
		{
			foreach (System.Data.DataColumn colm in table.Columns)
			{
				Console.WriteLine($"{colm.ColumnName} = {row[colm]}");
				Console.WriteLine("==================================");
			}
		}
	}

	// Create tables
	private bool CreateTable()
	{ 
		/*
			Creating base tables layed out by mysql schemas. Tables consists of:
			
			bills, rental (1:M), Home (1:M), car payment (1:m), food, savings
		 */
		using (MySqlCommand cmd = new MySqlCommand())
		{
			string create_table = @"CREATE TABLE IF NOT EXISTS bills
				(
					bills_id NOT NULL,
					PRIMARY KEY (bills_id),
					water FLOAT,
					electricity FLOAT,
					gas FLOAT,
					internet FLOAT,
					cellphone FLOAT,
					subscription FLOAT
				)";

			cmd.ExecuteNonQuery();
	
			return true;
		}

		return false;
	}
}
