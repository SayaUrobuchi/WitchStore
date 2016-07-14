using UnityEngine;
using System.Collections;

public static class Game
{
	public static INPUT parse_key(KEY key)
	{
		switch (key)
		{
		case KEY.LEFT:
			return INPUT.LEFT;
		case KEY.RIGHT:
			return INPUT.RIGHT;
		case KEY.UP:
			return INPUT.UP;
		case KEY.DOWN:
			return INPUT.DOWN;
		case KEY.C:
			return INPUT.DECIDE;
		case KEY.X:
			return INPUT.CANCEL;
		case KEY.V:
			return INPUT.MENU;
		case KEY.Z:
			return INPUT.SUB;
		case KEY.A:
			return INPUT.PAGEUP;
		case KEY.S:
			return INPUT.PAGEDOWN;
		}
		return INPUT.UNKNOWN;
	}

	public static Transform Clear(this Transform transform)
	{
		foreach (Transform child in transform)
		{
			if (child.parent == transform)
			{
				child.gameObject.SetActive(false);
			}
		}
		return transform;
	}
}
