using UnityEngine;
using System.Collections;

public class BattleAction : MonoBehaviour
{
	public GROUP group;
	public bool is_finished;

	public int speed;

	public BattleAction(int id, int caster, bool is_preview)
	{
		group = /*caster.group || */GROUP.NONE;
	}
	
	public void init()
	{
		/*caster = caster;
		card_id = id;
		data = CARD[id];
		group = group;
		speed = data.speed;
		name = data.name;
		cost = data.cost;
		is_preview = is_preview;*/
	}
	
	public int compare_to(BattleAction action)
	{
		if (speed != action.speed)
		{
			return speed - action.speed;
		}
		return (int)action.group - (int)group;
	}
	
	public bool is_available(HuntScene field)
	{
		return false;//return caster.can_act(field) && target.length > 0;
	}
	
	public void prepare(HuntScene field)
	{
		//get_target(field);
		//is_finished = false;
	}
	
	public void start(HuntScene field)
	{
		/*if (target.length > 0)
		{
			power = [];
			for (var i=0; i<data.effect.length; i++)
			{
				var list = [];
				for (var j=0; j<target[i].length; j++)
				{
					list.push(calc_power(field, data.effect[i], target[i][j]));
				}
				power.push(list);
			}
		}
		fcnt = 0;
		wait = -1;
		eidx = 0;
		tidx = -1;*/
	}
	
	public void execute(HuntScene field)
	{
		/*if (!caster.can_act(field) || target.length <= 0)
		{
			is_finished = true;
			return;
		}
		if (caster.is_casting(field))
		{
			return;
		}
		if (fcnt <= 0)
		{
			caster.cast_animation(field, self);
		}
		else if (fcnt > wait)
		{
			tidx++;
			if (tidx >= target[eidx].length)
			{
				eidx++;
				tidx = 0;
				wait = fcnt + 15;
				if (eidx >= data.effect.length)
				{
					is_finished = true;
					return;
				}
			}
			else
			{
				wait = fcnt + 15;
			}
			execute_effect(field, data.effect[eidx], 
				target[eidx][tidx], power[eidx][tidx]);
		}
		fcnt++;*/
	}
	
	public void execute_effect(HuntScene field/*, effect, target, power*/)
	{
		/*switch (effect.type)
		{
		case EFFECT.DAMAGE:
			target.take_damage(field, power);
			break;
		case EFFECT.HEAL:
			target.heal(field, power);
			break;
		}*/
	}
	
	public void get_target(HuntScene field)
	{
		/*target = [];
		for (var i=0; i<data.effect.length; i++)
		{
			target.push(field.event.get_target(data.effect[i], caster, group));
		}*/
	}
	
	public int calc_power(HuntScene field/*, effect, target*/)
	{
		/*var power = 0;
		if (effect.atk)
		{
			power += caster.atk * effect.atk / 100;
		}
		if (effect.hp)
		{
			power += target.hp * effect.hp / 100;
		}
		if (effect.mhp)
		{
			power += target.mhp * effect.mhp / 100;
		}
		return Math.floor(power * (1+field.event.get_chain_bonus()));*/
		return 0;
	}
	
	public bool is_finish()
	{
		return is_finished;
	}
}
