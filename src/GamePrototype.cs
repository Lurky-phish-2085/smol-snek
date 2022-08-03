using System;

public class GamePrototype {

	private Object[] level = new Object[6];
	private Player p1 = new Player();
	private Star star = new Star();

	private Random random = new Random();

	public GamePrototype(int playerPos = 0)
	{
		PopulateLevel();
		InitPlayerPosition(playerPos);
		PlaceStarRandomly();
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

	private void PlaceStarRandomly()
	{
		if (Array.Exists(level, x => x == star))
		{
			return;
		}

		int pos = random.Next(level.Length);
		while (pos == Array.IndexOf(level, p1))
		{
			pos = random.Next(level.Length);
		}

		level[pos] = star;
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
		GamePrototype game = new GamePrototype();
		game.DisplayLevel();

		ConsoleKeyInfo info = new ConsoleKeyInfo();
		while (info.Key != ConsoleKey.Escape)
		{
			Console.Clear();
			game.PlaceStarRandomly();
			game.DisplayScreen();

			info = Console.ReadKey(true);
			game.GetPlayer().Move(info, game.level);
		}
	}
}
