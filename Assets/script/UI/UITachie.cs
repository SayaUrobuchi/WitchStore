using UnityEngine;
using System.Collections;

public class UITachie : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public UITachie load()
	{
		gameObject.SetActive(true);
		return this;
	}
}
