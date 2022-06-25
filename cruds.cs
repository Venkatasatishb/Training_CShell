
using System;
using System.Data;
using System.Data.SQLite;

namespace cruds
{
	public class Cruds
	{
		public void create(SQLiteConnection connection)
		{
			try
			{
				SQLiteCommand statement = connection.CreateCommand();
				Console.Write("Enter Account Number: ");
				string accountNumber = Console.ReadLine();
				Console.Write("Enter Name: ");
				string name = Console.ReadLine();
				Console.Write("Enter Balance: ");
				string balance = Console.ReadLine();
				statement.CommandText = "INSERT INTO bankCustomersDetails VALUES ('" + accountNumber + "', '" + name + "', '" + balance + "', '1');";
				statement.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public void display(SQLiteConnection connection)
		{
			try
			{
				DataTable dataTable = new DataTable();

				string query = "SELECT * FROM bankCustomersDetails";
				SQLiteDataAdapter sqliteAdapter = new SQLiteDataAdapter(query, connection);

				sqliteAdapter.AcceptChangesDuringFill = false;
				sqliteAdapter.Fill(dataTable);

		        foreach(DataRow row in dataTable.Rows)
				{ 
			        Console.WriteLine("Account Number:" + row[0].ToString());
			        Console.WriteLine("Name: " + row[1].ToString());
			        Console.WriteLine("Balance: " + row[2].ToString());
			        Console.WriteLine();
			        Console.ReadLine();

				}
				// connection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}

}