using UnityEngine;
using System.Collections;

public class Hero
{
	public int hp = 100;
	public int mp = 40;
	public int mp_init = 20;
	public int mp_regen = 15;
	public int atk = 20;
	
	public UIGauge hp_gauge;
	public UIGauge mp_gauge;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void load_ui()
	{
		hp_gauge = Megami.worship.hp_bar.load();
		mp_gauge = Megami.worship.mp_bar.load();
	}
}
