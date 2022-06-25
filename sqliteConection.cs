

using System.Data.SQLite;
using System;

namespace sqliteConnection
{
	public class Connects
	{
		SQLiteConnection connection;
		public SQLiteConnection connect(string dataBaseName)
		{
			try
			{	
				connection = new SQLiteConnection("Data Source = " + dataBaseName);
				connection.Open();
				SQLiteCommand statement = connection.CreateCommand();

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			return connection;
		}
		public void finalize(SQLiteConnection connection)
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
}




				// Cruds cruds = new Cruds() ;
				// while (true)
				// {
				// 	Console.Write("1. Create\n2. Display\n3. Exit\nChoose Your Option: ");
				// 	int choice = Convert.ToInt32(Console.ReadLine());

				// 	switch(choice)
				// 	{
				// 		case 1:
				// 			cruds.create(statement);
				// 			break;
				// 		case 2:
				// 			cruds.display(connection);
				// 			break;
				// 		case 3:
				// 			finalize(connection);
				// 			break;
				// 	}
				// }