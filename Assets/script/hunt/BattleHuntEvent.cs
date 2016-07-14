using UnityEngine;
using System.Collections.Generic;
using System;

public class BattleHuntEvent : HuntEvent
{
	public BattleHuntEvent(HuntScene scene, UnityEngine.Object data)
	{
		field = scene;
	}

	public override void setup()
	{
		base.setup();
		field.set_helper(new Dictionary<INPUT, string>() {
			{INPUT.VERTICAL, "選擇卡片" },
			{ INPUT.DECIDE, "宣告發動"},
			{ INPUT.CANCEL, "取消宣告"}, 
			{INPUT.MENU, "回合開始"}, 
		});
	}

	public override void update_draw()
	{
	}

	public override void update_state()
	{
	}
}
