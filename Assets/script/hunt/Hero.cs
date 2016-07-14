using UnityEngine;
using System.Collections;

public class Hero
{
	public int hp = 100;
	public int max_hp = 350;
	public int mp = 20;
	public int max_mp = 40;
	public int mp_init = 20;
	public int mp_regen = 15;
	public int atk = 20;
	
	public UIGauge hp_gauge;
	public UIGauge mp_gauge;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hp_gauge != null)
		{
		}
		if (mp_gauge != null)
		{
		}
	}

	public void load_ui()
	{
		hp_gauge = Megami.worship.hp_bar.load();
		mp_gauge = Megami.worship.mp_bar.load();
		hp_gauge.set_max_value(max_hp);
		mp_gauge.set_max_value(max_mp);
		hp_gauge.set_value(hp);
		mp_gauge.set_value(mp);
		hp_gauge.clear_predict();
		mp_gauge.clear_predict();
		mp_gauge.set_predict(-8, true);
	}
}
