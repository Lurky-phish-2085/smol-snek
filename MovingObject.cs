using System;
using System.Threading;

/*
 * Got Stuck here
 *
 * What I want is to move the Player across the world left or right
 *
 * 1. We have to track the position of Player
 * 2. use that info to move the Player's sprite in the array
 * 3. replace the prev pos with the default empty sprite
 *
 * Found goodies
 *
 * 1. Array.IndexOf(array, value) -> returns int
 *
 */

public class MovingObject 
{
	static string[] world1d = new string[6];
	static string emptySprite = "-";

	static public void PopulateWorld()
	{
		for (int i = 0; i < world1d.Length; i++)
		{
			world1d[i] = emptySprite;
		}
	}

	static public void InitPlayerPos(Player p, int pos) 
	{
		world1d[pos] = p.ToString();
	}

	static public void Main()
	{
		PopulateWorld();

		Player p1 = new Player();
		InitPlayerPos(p1, 3);

		Console.WriteLine("--------------------------------------------------");
		Console.WriteLine(string.Join(", ", world1d));
		Console.WriteLine("--------------------------------------------------");

		ConsoleKeyInfo info;
		info = Console.ReadKey(true);
		while (info.Key != ConsoleKey.Escape)
		{
			int pos = Array.IndexOf(world1d, p1.ToString());
			if (info.Key == ConsoleKey.LeftArrow && pos != world1d.GetLowerBound(0))
			{
				world1d[pos - 1] = p1.ToString();
				world1d[pos] = emptySprite;
			}
	
			if (info.Key == ConsoleKey.RightArrow && pos != world1d.GetUpperBound(0))
			{
				pos = Array.IndexOf(world1d, p1.ToString());
				world1d[pos + 1] = p1.ToString();
				world1d[pos] = emptySprite;
			}
		
			Console.Clear();
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine(string.Join(", ", world1d));
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("POSITION: " + Array.IndexOf(world1d, p1.ToString()));
			Console.WriteLine("LAST KEYPRESS: " + info.Key);
			info = Console.ReadKey(true);
		}
	}
}

public class Player
{
	private string sprite = "✓";

	public override string ToString()
	{
		return sprite;
	}
}
