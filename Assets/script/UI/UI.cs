using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public static class UI
{
	public static float swing_curve(float x)
	{
		return -Mathf.Cos(x*Mathf.PI)/2 + .5f;
	}

	public static void set_width(this Image img, float width)
	{
		img.rectTransform.sizeDelta = new Vector2(width, img.rectTransform.sizeDelta.y);
	}

	public static void set_height(this Image img, float height)
	{
		img.rectTransform.sizeDelta = new Vector2(img.rectTransform.sizeDelta.x, height);
	}

	public static float get_width(this Image img)
	{
		return img.rectTransform.sizeDelta.x;
	}

	public static float get_height(this Image img)
	{
		return img.rectTransform.sizeDelta.y;
	}

	public static void set_pos_x(this Image img, float x)
	{
		img.rectTransform.anchoredPosition = new Vector2(x, img.rectTransform.anchoredPosition.y);
	}

	public static void set_pos_y(this Image img, float y)
	{
		img.rectTransform.anchoredPosition = new Vector2(img.rectTransform.anchoredPosition.x, y);
	}

	public static float get_pos_x(this Image img)
	{
		return img.rectTransform.anchoredPosition.x;
	}

	public static float get_pos_y(this Image img)
	{
		return img.rectTransform.anchoredPosition.y;
	}

	public static void resize<T>(this List<T> list, int size) where T : new()
	{
		if (list.Count > size)
		{
			list.RemoveRange(size, list.Count-size);
		}
		if (list.Count < size)
		{
			while (list.Count < size)
			{
				list.Add(new T());
			}
		}
	}
}
