// 

using sqliteConnection;
using cruds;
using System;
using System.Data.SQLite;
class BankCustomersDetails
{
	static void Main(string[] args)
	{
		Connects connects = new Connects();
		SQLiteConnection connection = connects.connect("CRUDSBankCustomer.db");
		Cruds cruds = new Cruds() ;
		while (true)
		{
			Console.Write("1. Create\n2. Display\n3. Exit\nChoose Your Option: ");
			int choice = Convert.ToInt32(Console.ReadLine());

			switch(choice)
			{
				case 1:
					cruds.create(connection);
					break;
				case 2:
					cruds.display(connection);
					break;
				case 3:
					connects.finalize(connection);
					break;
			}
		}
	}
}
