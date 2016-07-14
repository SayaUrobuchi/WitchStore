using UnityEngine;
using System.Collections;

public class Megami : MonoBehaviour
{
	public static Megami worship;

	public UIHelper helper;
	public UITachie tachie1;
	public UITachie tachie2;
	public UIGauge hp_bar;
	public UIGauge mp_bar;
	public UISimpleDialog dialog;

	private GameObject canvas;

	public Scene scene;

	void Awake ()
	{
		worship = this;
		canvas = GameObject.FindGameObjectWithTag("canvas");
		ClearCanvas();
	}

	// Use this for initialization
	void Start () {
		scene = new HuntScene();
		scene.enter();
	}
	
	// Update is called once per frame
	void Update () {
		scene.update_state();
	}

	public void ClearCanvas()
	{
		canvas.transform.Clear();
	}
}
