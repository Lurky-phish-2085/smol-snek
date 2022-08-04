using System;

public class GamePrototype {

	private Object[,] level = new Object[6,6];
	private Player p1 = new Player();
	private Star star = new Star();

	private Random random = new Random();

	public GamePrototype(int x = 2, int y = 2)
	{
		PopulateLevel();
		InitPlayerPosition(x, y);
		PlaceStarRandomly();
	}

	public Player GetPlayer()
	{
		return p1;
	}

	private void PopulateLevel(string str = "-")
	{
		for (int i = 0; i < level.GetLength(0); i++)
		{
			for (int j = 0; j < level.GetLength(0); j++)
			{
				level[i,j] = str;
			}
		}
	}

	private void InitPlayerPosition(int x, int y)
	{
		level[x,y] = p1;
	}

	private void PlaceStarRandomly()
	{
		/* CHANGE
		if (Array.Exists(level, x => x == star))
		{
			return;
		}
		CHANGE */ 

		/* CHANGE
		while (pos == Array.IndexOf(level, p1))
		{
			pos = random.Next(level.Length);
		}
		CHANGE */ 

		// gen x y coords of the next star
		// get the x and y coords of player
		// check if our random xy is equal to that
		// if not place star

		// get x y of next star
		int x = random.Next(level.GetLength(0));
		int y = random.Next(level.GetLength(0));

		// get xy of player
		int playerX = 0;
		int playerY = 0;
		for (int i = 0; i < level.GetLength(0); i++)
		{
			for (int j = 0; j < level.GetLength(0); j++)
			{
				if (level[i,j] == p1)
				{
					playerX = i;
					playerY = j;
				}
			}
		}

		while (playerX == x && playerY == y)
		{
			x = random.Next(level.GetLength(0));
			y = random.Next(level.GetLength(0));
		}

		level[x,y] = star;
	}

	private void DisplayLevel()
	{
		for (int i = 0; i < level.GetLength(0); i++)
		{
			for (int j = 0; j < level.GetLength(0); j++)
			{
				Console.Write(level[i,j]);
				if (j != level.GetUpperBound(0))
				{
					Console.Write(" ");
				}
			}
			Console.WriteLine();
		}
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
		/*
		Console.CursorVisible = false;

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

		Console.CursorVisible = true;
		*/
	}
}
