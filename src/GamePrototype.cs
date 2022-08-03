using System;

public class GamePrototype {

	private Object[] level = new Object[6];
	private Player p1 = new Player();

	public GamePrototype(int playerPos)
	{
		PopulateLevel();
		InitPlayerPosition(playerPos);
	}

	public Player GetPlayer()
	{
		return p1;
	}

	private void PopulateLevel(string str = "-")
	{
		for (int i = 0; i < level.Length; i++)
		{
			level[i] = str;
		}
	}

	private void InitPlayerPosition(int pos)
	{
		level[pos] = p1;
	}

	private void DisplayLevel()
	{
		Console.WriteLine(string.Join(" ", level));
	}

	private void DisplayHud()
	{
		Console.WriteLine("\n--------------------------------------------------");
		Console.WriteLine("PLAYER: " + p1);
		Console.WriteLine("DIRECTION: " + p1.GetDirection());
		Console.WriteLine("SCORE: " + p1.GetScore());
		Console.WriteLine("--------------------------------------------------\n");
	}

	public void DisplayScreen()
	{
		DisplayLevel();
		DisplayHud();
	}

	static public void Main()
	{
		GamePrototype game = new GamePrototype(0);
		game.DisplayLevel();

		ConsoleKeyInfo info = new ConsoleKeyInfo();
		while (info.Key != ConsoleKey.Escape)
		{
			Console.Clear();
			game.DisplayScreen();

			info = Console.ReadKey(true);
			game.GetPlayer().Move(info, game.level);
		}
	}
}
