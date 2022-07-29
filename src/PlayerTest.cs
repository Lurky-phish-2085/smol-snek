using System;

public class PlayerTest {

	static public void Main()
	{
		Player p1 = new Player();

		ConsoleKeyInfo info = new ConsoleKeyInfo();
		while (info.Key != ConsoleKey.Escape) 
		{
			Console.Clear();
			Console.WriteLine("Player: " + p1);
			Console.WriteLine("Direction: " + p1.GetDirection());
			Console.WriteLine("Score: " + p1.GetScore());

			info = Console.ReadKey(true);
			p1.Move(info);
		}

		Console.WriteLine("Program Terminated...");
	}
}
