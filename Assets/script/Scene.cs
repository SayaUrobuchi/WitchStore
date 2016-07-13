using UnityEngine;
using System.Collections.Generic;

public abstract class Scene
{
	public int fid;

	public abstract void enter();
	public abstract void update_state();
	public abstract void leave();

	public Dictionary<INPUT, bool> input;
	public Dictionary<INPUT, int> input_delay;

	protected Scene()
	{
		input = new Dictionary<INPUT, bool>();
		input_delay = new Dictionary<INPUT, int>();
	}

	public bool is_key(INPUT key)
	{
		if (!input.ContainsKey(key))
		{
			return false;
		}
		return input[key] && (!input_delay.ContainsKey(key) || fid >= input_delay[key]);
	}

	public void key_delay(INPUT key, int delay, int first_delay = -1)
	{
		if (first_delay >= 0 && (!input_delay.ContainsKey(key) || fid-input_delay[key] > delay))
		{
			delay = first_delay;
		}
		input_delay[key] = fid + delay;
	}

	public bool keyup(KEY key)
	{
		INPUT res = Game.parse_key(key);
		if (res != INPUT.UNKNOWN)
		{
			input[res] = false;
			input_delay[res] = 0;
			return false;
		}
		return true;
	}

	public bool keydown(KEY key)
	{
		INPUT res = Game.parse_key(key);
		if (res != INPUT.UNKNOWN)
		{
			input[res] = true;
			/*if (res == INPUT.DECIDE)
			{
				hp -= 8;
			}
			else if (res == INPUT.CANCEL)
			{
				hp += 8;
			}
			else if (res == INPUT.MENU)
			{
				mp_prev++;
			}
			else if (res == INPUT.SUB)
			{
				mp_prev--;
			}*/
			return false;
		}
		return true;
	}

	public void clear_input()
	{
		input.Clear();
		input_delay.Clear();
	}
}
