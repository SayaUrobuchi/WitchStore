using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISimpleDialog : MonoBehaviour
{
	public Text text;

	public float fadein_time = .6f;
	
	private float alpha = 0f;

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
		if (alpha < 1f)
		{
			alpha = Mathf.Min(alpha + Time.deltaTime/fadein_time, 1f);
			Color c = text.color;
			c.a = alpha;
			text.color = c;
		}
	}

	public UISimpleDialog load()
	{
		gameObject.SetActive(true);
		return this;
	}

	public void set_content(string s)
	{
		text.text = s;
		alpha = 0;
	}
}
