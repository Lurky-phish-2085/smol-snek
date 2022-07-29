using System;

public class Player
{
	private string sprite = "→";
	private string direction = "E";

	private string[] directionSprites = {"←", "→", "↑", "↓"};
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

	public void Move(ConsoleKeyInfo info) 
	{
		direction = EvalKeyForDirection(info.Key);
		UpdateSprite();
	}

	public override string ToString()
	{
		return sprite;
	}
}
