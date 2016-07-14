using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIHelper : MonoBehaviour {

	public Dictionary<INPUT, string> symbol_mapping = new Dictionary<INPUT, string>() {
		{ INPUT.VERTICAL, "↓↑" },
		{ INPUT.HORIZONTAL, "←→" },
		{ INPUT.ARROW, "←↓↑→" },
		{ INPUT.DECIDE, "Ｃ" },
		{ INPUT.CANCEL, "Ｘ" },
		{ INPUT.MENU, "Ｖ" },
		{ INPUT.SUB, "Ｚ" },
		{ INPUT.PAGEUP, "Ａ" },
		{ INPUT.PAGEDOWN, "Ｓ" },
		{ INPUT.UP, "↑" },
		{ INPUT.DOWN, "↓" },
		{ INPUT.LEFT, "←" },
		{ INPUT.RIGHT, "→" },
	};

	public Text text;

	void Awake()
	{
		if (text == null)
		{
			text = GetComponentInChildren<Text>();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public UIHelper load()
	{
		gameObject.SetActive(true);
		return this;
	}

	public void setContent(string s)
	{
		text.text = s;
	}

	public void setContent(Dictionary<INPUT, string> dict)
	{
		string res = "";
		foreach (var item in dict)
		{
			res += string.Format("{0}{1}　　", 
				generate_richtext_colored_str(symbol_mapping[item.Key], "#FFFF66"), 
				item.Value);
		}
		setContent(res);
	}

	public string generate_richtext_colored_str(string s, string color)
	{
		return string.Format("<color=\"{1}\">{0}</color>", s, color);
	}
}
