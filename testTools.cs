// Test Tools.dll

using nsTools;
class TestTools
{
	static void Main(string[] args)
	{
		Tools tools = new Tools();
		tools.print("Enter Your Name: ");
		string name = tools.input();
		tools.print("Hello " + name);
	}
}
