using System;
// using System.Math;

namespace Maths
{

using Maths1;

class TestMath
{
	static void Main(string[] args)
	{
		Math1 math1 = new Math1();
		Math2 math2 = new Math2();
		System.Console.WriteLine(math1.cude(2));
		System.Console.WriteLine(math1.square(8));
		System.Console.WriteLine(math1.half(25));
		System.Console.WriteLine(Math1.half1(51.00));
		System.Console.WriteLine(math2.cude(2));
		System.Console.WriteLine(math2.square(8));
		System.Console.WriteLine(math2.half(25));
		System.Console.WriteLine(math2.half(51.00));
	}
}
}

namespace Maths1
{

class Math1
{
	public int cude(int numberToBeCubed)
	{
		return numberToBeCubed * numberToBeCubed * numberToBeCubed;
	}

	public int square(int numberToBeSquared)
	{
		return numberToBeSquared * numberToBeSquared;
	}
	public float half(int numberToBeHalf)
	{
		return (numberToBeHalf/2);
	}
	public static double half1(double numberToBeHalf)
	{
		return Math.Ceiling((numberToBeHalf/2));
	}
}

class Math2 : Math1
{
	public double half(double numberToBeHalf)
	{
		return Math.Ceiling((numberToBeHalf/2));
	}
}
}