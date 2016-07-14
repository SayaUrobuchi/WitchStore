using UnityEngine;
using System.Collections;

public class UIGauge : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public UIGauge load()
	{
		gameObject.SetActive(true);
		return this;
	}
}
