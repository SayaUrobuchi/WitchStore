using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIGauge : MonoBehaviour
{
	public const float CONTINUE_STARTLINE = .25f;

	public Text current;
	public Text max;
	public Text diff;
	public Image front;
	public Image back;
	public Image predict;
	public Image whole_bar;
	
	public float fast_anitime = .2f;
	public float slow_anitime = 1f;

	private int fview_cur;
	private int fview_from;
	private int sview_cur;
	private int sview_from;
	private int view_tar;
	private int view_max;
	private int pred_value;
	private bool pred_visual;
	private float fast_timer;
	private float slow_timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (slow_timer < 1f)
		{
			slow_timer = Mathf.Min(1f, slow_timer + Time.deltaTime / slow_anitime);
			if (view_tar < sview_from)
			{
				update_slow(back);
			}
			else
			{
				update_slow(front);
			}
		}
		if (fast_timer < 1f)
		{
			fast_timer = Mathf.Min(1f, fast_timer + Time.deltaTime / fast_anitime);
			if (view_tar < fview_from)
			{
				update_fast(front);
			}
			else
			{
				update_fast(back);
			}
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			set_value(Mathf.Clamp(view_tar+16, 0, view_max));
		}
		if (Input.GetKeyDown(KeyCode.X))
		{
			set_value(Mathf.Clamp(view_tar-16, 0, view_max));
		}
	}

	private void update_fast(Image gauge)
	{
		float curve = UI.swing_curve(fast_timer);
		float length = whole_bar.get_width();
		float value = (view_tar-fview_from) * curve + fview_from;
		float rate = (view_max == 0 ? 0f : (float)value / view_max);
		float width = length * rate;
		gauge.set_width(width);
		fview_cur = Mathf.RoundToInt(value);
	}

	private void update_slow(Image gauge)
	{
		float curve = UI.swing_curve(slow_timer);
		float length = whole_bar.get_width();
		float value = (view_tar-sview_from) * curve + sview_from;
		float rate = (view_max == 0 ? 0f : (float)value / view_max);
		float width = length * rate;
		gauge.set_width(width);
		sview_cur = Mathf.RoundToInt(value);
		current.text = sview_cur.ToString();
	}

	public UIGauge load()
	{
		gameObject.SetActive(true);
		return this;
	}

	public void set_animation()
	{
		// timer: if ended, reset to 0; otherwise reset to a value skipping slow startup curve
		if (fast_timer >= 1f)
		{
			fast_timer = 0f;
			fview_from = fview_cur;
		}
		else
		{
			fast_timer = Mathf.Min(fast_timer, CONTINUE_STARTLINE);
			fview_from = Mathf.RoundToInt(fview_cur - (view_tar-fview_from) * UI.swing_curve(fast_timer));
		}
		if (slow_timer >= 1f)
		{
			slow_timer = 0f;
			sview_from = sview_cur;
		}
		else
		{
			slow_timer = Mathf.Min(slow_timer, CONTINUE_STARTLINE);
			sview_from = Mathf.RoundToInt(sview_cur - (view_tar-sview_from) * UI.swing_curve(slow_timer));
		}
	}

	public void set_value(int value, bool immediate = false)
	{
		if (value != view_tar)
		{
			view_tar = value;
			set_animation();
			if (immediate)
			{
				fast_timer = slow_timer = 1f;
				update_slow(back);
				update_fast(front);
			}
			if (pred_value != 0)
			{
				set_predict(pred_value, pred_visual);
			}
		}
	}

	public void set_max_value(int value)
	{
		view_max = value;
		max.text = value.ToString();
		if (pred_value != 0)
		{
			set_predict(pred_value, pred_visual);
		}
	}

	public void clear_predict()
	{
		predict.set_width(0);
		pred_value = 0;
		pred_visual = false;
		diff.text = "";
	}

	public void set_predict(int value, bool visual = false)
	{
		pred_value = value;
		pred_visual = visual;
		diff.text = string.Format("({0})", value);
		if (visual)
		{
			float left = (view_max == 0 ? 0f : Mathf.Clamp(Mathf.Min(view_tar, view_tar+value), 0f, view_max) / view_max);
			float right = (view_max == 0 ? 0f : Mathf.Clamp(Mathf.Max(view_tar, view_tar+value), 0f, view_max) / view_max);
			float length = whole_bar.get_width();
			predict.set_width(length * (right-left));
			predict.set_pos_x(length * left);
		}
		else
		{
			clear_predict();
		}
	}
}
