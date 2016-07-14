using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISimpleDialog : MonoBehaviour
{
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

	public UISimpleDialog load()
	{
		gameObject.SetActive(true);
		return this;
	}
}
