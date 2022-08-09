using System;

public class Player
{
	private string sprite = "⮚";
	private string direction = "E";

	private string[] directionSprites = {"⮘", "⮚", "⮙", "⮛"};
	private string[] directions = {"W", "E", "N", "S"};

	private int score;

	public string GetSprite() {
		return sprite;
	}

	public string GetDirection() {
		return direction;
	}

	public int GetScore() {
		return score;
	}

	public void SetSprite(string sprite)
	{
		this.sprite = sprite;
	}

	/*
	public void SetDirection(string direction)
	{
		// should add check here
		this.direction = direction;
	}
	*/

	public void IncrementScore(int increment = 1) {
		score += increment;
	}

	private void UpdateSprite() {
		switch (direction)
		{
			case "W":
				sprite = directionSprites[0];
				break;
			case "E":
				sprite = directionSprites[1];
				break;
			case "N":
				sprite = directionSprites[2];
				break;
			case "S":
				sprite = directionSprites[3];
				break;
		}
	}

	private string EvalKeyForDirection(ConsoleKey key) 
	{
		if (key == ConsoleKey.LeftArrow)
		{
			return directions[0];
		}

		if (key == ConsoleKey.RightArrow)
		{
			return directions[1];
		}

		if (key == ConsoleKey.UpArrow)
		{
			return directions[2];
		}

		if (key == ConsoleKey.DownArrow)
		{
			return directions[3];
		}

		return null;
	}

	//temp
	private bool HasCollidedToStar(Object obj)
	{
		return obj is Star;
	}

	// temp
	public void Move(ConsoleKeyInfo info, Object[,] level) 
	{
		direction = EvalKeyForDirection(info.Key);

		// do checks
		if (direction == null)
		{
			return;
		}

		/*
		bool atTheBound = (pos == level.GetLowerBound(0)) || (pos == level.GetUpperBound(0))
		if (atTheBound)
		{
			return;
		}
		*/

		// find the player's position
		int playerX = 0;
		int playerY = 0;

		for (int i = 0; i < level.GetLength(0); i++)
		{
			for (int j = 0; j < level.GetLength(0); j++)
			{
				if (level[i,j] == this)
				{
					playerX = i;
					playerY = j;
				}
			}
		}


		// manipulate level
		switch (direction)
		{
			case "W":
				if (playerX != level.GetUpperBound(0) || playerX != level.GetLowerBound(1))
				{
					bool atLowerBound = playerY == level.GetLowerBound(0);
					int reversedY = 0;
					if (atLowerBound)
					{
						reversedY = level.GetUpperBound(0);
					}

					if (atLowerBound)
					{
						if (HasCollidedToStar(level[playerX, reversedY]))
						{
							IncrementScore();
						}
						level[playerX, reversedY] = this;
						level[playerX, playerY] = "-";
					}
					else
					{
						if (HasCollidedToStar(level[playerX, playerY - 1]))
						{
							IncrementScore();
						}
						level[playerX, playerY - 1] = this;
						level[playerX, playerY] = "-";
					}
				}
				break;
			case "E":
				if (playerX != level.GetUpperBound(0) || playerX != level.GetLowerBound(1))
				{
					bool atUpperBound = playerY == level.GetUpperBound(0);
					int reversedY = 0;
					if (atUpperBound)
					{
						reversedY = level.GetLowerBound(0);
					}

					if (atUpperBound)
					{
						if (HasCollidedToStar(level[playerX, reversedY]))
						{
							IncrementScore();
						}
						level[playerX, reversedY] = this;
						level[playerX, playerY] = "-";
					}
					else
					{
						if (HasCollidedToStar(level[playerX, playerY + 1]))
						{
							IncrementScore();
						}
						level[playerX, playerY + 1] = this;
						level[playerX, playerY] = "-";
					}
				}
				break;
			case "N":
				//if (playerX != level.GetUpperBound(0))
				if (playerY != level.GetLowerBound(1) || playerY != level.GetUpperBound(0))
				{
					bool atLowerBound = playerX == level.GetLowerBound(0);
					int reversedX = 0;
					if (atLowerBound)
					{
						reversedX = level.GetUpperBound(0);
					}

					if (atLowerBound)
					{
						if (HasCollidedToStar(level[reversedX, playerY]))
						{
							IncrementScore();
						}
						level[reversedX, playerY] = this;
						level[playerX, playerY] = "-";
					}
					else
					{
						if (HasCollidedToStar(level[playerX - 1, playerY]))
						{
							IncrementScore();
						}
						level[playerX - 1, playerY] = this;
						level[playerX, playerY] = "-";
					}
				}
				break;
			case "S":
				//if (playerX != level.GetUpperBound(0))
				if (playerY != level.GetLowerBound(1) || playerY != level.GetUpperBound(0))
				{
					bool atUpperBound = playerX == level.GetUpperBound(0);
					int reversedX = 0;
					if (atUpperBound)
					{
						reversedX = level.GetLowerBound(0);
					}

					if (atUpperBound)
					{
						if (HasCollidedToStar(level[reversedX, playerY]))
						{
							IncrementScore();
						}
						level[reversedX, playerY] = this;
						level[playerX, playerY] = "-";
					}
					else
					{
						if (HasCollidedToStar(level[playerX + 1, playerY]))
						{
							IncrementScore();
						}
						level[playerX + 1, playerY] = this;
						level[playerX, playerY] = "-";
					}
				}
				break;
			default:
				break;
		}


		UpdateSprite();
		// temp
		// find the player's position
		playerX = 0;
		playerY = 0;

		for (int i = 0; i < level.GetLength(0); i++)
		{
			for (int j = 0; j < level.GetLength(0); j++)
			{
				if (level[i,j] == this)
				{
					playerX = i;
					playerY = j;
				}
			}
		}
		Console.WriteLine("X: " + playerX);
		Console.WriteLine("Y: " + playerY);
		// temp

	}

	public override string ToString()
	{
		return sprite;
	}
}
