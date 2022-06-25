/*using System.Data.SQLite;
using System;

class BankCustomersDetails
{
	public static void Main(string[] args)
	{
		try
		{
			Connects connects = new Connects();
			// connects.Connect();
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

		SQLiteConnection connection;
		try
		{	
			connection = new SQLiteConnection("Data Source = CRUDSBankCustomer.db");
			connection.Open();
			Console.WriteLine("Connected.");
			SQLiteCommand statement = connection.CreateCommand();
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
						// cruds.display(statement);
						cruds.ReadData(connection);
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
	private void finalize(SQLiteConnection connection)
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
	public void create(SQLiteCommand statement)
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

	public void display(SQLiteCommand statement)
	{
		try
		{
			SQLiteDataReader dataReader;
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
}*/


using System.Data.SQLite;
using System;
using System.Data;
// using System.Data.SQLite.EF6;

class BankCustomersDetails
{
	public static void Main(string[] args)
	{
		try
		{
			Connects connects = new Connects();
			// connects.Connect();
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

		SQLiteConnection connection;
		try
		{	
			connection = new SQLiteConnection("Data Source = CRUDSBankCustomer.db");
			connection.Open();
			Console.WriteLine("Connected.");
			SQLiteCommand statement = connection.CreateCommand();
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
	private void finalize(SQLiteConnection connection)
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
	public void create(SQLiteCommand statement)
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
			connection.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}





// var sqlAdapter = new SqlDataAdapter("SELECT * FROM the_table", sqlConnection);
// DataTable table = new DataTable();
// sqlAdapter.AcceptChangesDuringFill = false;
// sqlAdapter.Fill(table);






// public void UseDataTable()
// {
//   SQLiteDataTable myDataTable = new SQLiteDataTable("SELECT * FROM Dept", 
//       "DataSource=mydatabase.db;");
//   try
//   {
//     myDataTable.FetchAll = true;
//         myDataTable.Active = true;
//     myDataTable.Rows[3]["DName"] = "Researches";
//     Console.WriteLine(myDataTable.Update()+" rows updated.");
//     foreach(DataRow myRow in myDataTable.Rows)
//     {
//       foreach(DataColumn myCol in myDataTable.Columns)
//       {
//         Console.Write(myRow[myCol]+"\t");
//       }
//       Console.WriteLine();
//     }
//   }
//   finally
//   {
//     myDataTable.Active = false;
//   }
// }