/*// MySql

using MySql.Data.MySqlClient;
using System;

class BankCustomersDetails
{
	public static void Main(string[] args)
	{
		try
		{
			Connects connects = new Connects();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}

class Connects
{
	public Connects()
	{

		MySqlConnection connection;
		try
		{	
			connection = new MySqlConnection("Server =  165.22.14.77; Database = dbSatish; User Id = satish;password=pwdsatish;");
			connection.Open();
			Console.WriteLine("Connected.");
			MySqlCommand statement = connection.CreateCommand();
			Cruds cruds = new Cruds() ;
			while (true)
			{
				Console.Write("1. Create\n2. Display\n3. Exit\nChoose Your Option: ");
				int choice = Convert.ToInt32(Console.ReadLine());

				switch(choice)
				{
					case 1:
						cruds.create(statement);
						break;
					case 2:
						cruds.display(statement);
						// cruds.ReadData(connection);
						break;
					case 3:
						finalize(connection);
						break;
				}
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
	private void finalize(MySqlConnection connection)
	{
		try
		{
			connection.Close();
			Environment.Exit(0);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}

class Cruds
{
	public void create(MySqlCommand statement)
	{
		try
		{
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

	public void display(MySqlCommand statement)
	{
		try
		{
			MySqlDataReader dataReader;
			statement.CommandText = "SELECT * FROM bankCustomersDetails";
			dataReader = statement.ExecuteReader();
			while(dataReader.Read())
			{
				string accountNumber = dataReader.GetString(0);
				Console.WriteLine("Account Number: " + accountNumber);
				string name = dataReader.GetString(1);
				Console.WriteLine("Name: " + name);
				string balance = dataReader.GetString(2);
				Console.WriteLine("Balance: " + balance);
				Console.WriteLine();
			}
			dataReader.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}
*/



// MySql

using MySql.Data.MySqlClient;
using System;
using System.Data;

class BankCustomersDetails
{
	public static void Main(string[] args)
	{
		try
		{
			Connects connects = new Connects();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}

class Connects
{
	public Connects()
	{

		MySqlConnection connection;
		try
		{	
			connection = new MySqlConnection("Server =  165.22.14.77; Database = dbSatish; User Id = satish;password=pwdsatish;");
			connection.Open();
			Console.WriteLine("Connected.");
			MySqlCommand statement = connection.CreateCommand();
			Cruds cruds = new Cruds() ;
			while (true)
			{
				Console.Write("1. Create\n2. Display\n3. Exit\nChoose Your Option: ");
				int choice = Convert.ToInt32(Console.ReadLine());

				switch(choice)
				{
					case 1:
						cruds.create(statement);
						break;
					case 2:
						cruds.display(connection);
						// cruds.ReadData(connection);
						break;
					case 3:
						finalize(connection);
						break;
				}
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
	private void finalize(MySqlConnection connection)
	{
		try
		{
			connection.Close();
			Environment.Exit(0);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}

class Cruds
{
	public void create(MySqlCommand statement)
	{
		try
		{
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

	public void display(MySqlConnection connection)
	{
		try
		{
			DataTable dataTable = new DataTable();

			string query = "SELECT * FROM bankCustomersDetails";
			MySqlDataAdapter sqliteAdapter = new MySqlDataAdapter(query, connection);

			sqliteAdapter.AcceptChangesDuringFill = false;
			sqliteAdapter.Fill(dataTable);

	        foreach(DataRow row in dataTable.Rows)
			{ 
		        Console.WriteLine("Account Number:" + row[0].ToString());
		        Console.WriteLine("Name: " + row[1].ToString());
		        Console.WriteLine("Balance: " + row[2].ToString());
		        Console.WriteLine();
			}
			connection.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}
