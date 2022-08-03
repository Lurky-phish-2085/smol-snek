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
	public void Move(ConsoleKeyInfo info, Object[] level) 
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
		int pos = Array.IndexOf(level, this);

		// manipulate level
		switch (direction)
		{
			case "W":
				if (pos != level.GetLowerBound(0))
				{
					if (HasCollidedToStar(level[pos - 1]))
					{
						IncrementScore();
					}
					level[pos - 1] = this;
					level[pos] = "-";
				}
				break;
			case "E":
				if (pos != level.GetUpperBound(0))
				{
					if (HasCollidedToStar(level[pos + 1]))
					{
						IncrementScore();
					}

					level[pos + 1] = this;
					level[pos] = "-";
				}
				break;
			default:
				break;
		}

		UpdateSprite();
	}

	public override string ToString()
	{
		return sprite;
	}
}
