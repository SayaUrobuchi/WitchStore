using UnityEngine;
using System.Collections.Generic;

public abstract class HuntEvent
{
	public enum Type
	{
		NONE = 0, 
		GATHER = 1, 
		BATTLE = 2, 
		TALK = 3, 
	}

	public Type type;

	public abstract void update_draw();
	public abstract void update_state();

	public void setup()
	{
	}

	public void update_hand_move()
	{
	}

	public void update_logic_hand()
	{
	}

	public void update_background()
	{
	}
}

public class HuntScene : Scene
{
	public enum State
	{
		NONE = -1, 
		LOADING = 0, 
		READY = 1, 
		DISCOVER = 2, 
		EVENT = 3, 
		END = 32, 
	}

	public State state;

	public int hand_limit;
	public int turn_draw;

	public int hand_current;
	public List<Hand> hand;
	public List<Hand> hand_temp;
	public List<int> deck;

	public Hero player_battler;

	public Sprite tachie;
	public Sprite tachie2;

	public int enemy_area_x;
	public int enemy_area_y;
	public int enemy_area_w;

	public HuntEvent evt;
	
	public int shake_power;
	public int shake_count;
	public int shake_length;

	public override void enter ()
	{
		fid = 0;
		state = State.NONE;

		hand_limit = 10;
		turn_draw = 3;

		hand_current = 0;
		hand = new List<Hand>();
		hand_temp = new List<Hand>();

		deck = new List<int>(new int[] {
			999, 
			998, 
			997, 
			999, 
			998, 
			997, 
			999, 
			998, 
			997, 
			999, 
			998, 
			997, 
			999, 
			998, 
			997, 
		});

		player_battler = new Hero();

		tachie = null;//image.TACHIE_AKI_NORMAL;
		tachie2 = null;//image.TACHIE_SAKO_NORMAL;

		enemy_area_x = 500;
		enemy_area_y = 450;
		enemy_area_w = 760;

		set_background(null);

		draw_card(hand_limit);

		clear_input();
	}

	public override void leave()
	{
	}

	public bool is_discover()
	{
		return state == State.DISCOVER;
	}

	public bool is_event()
	{
		return state == State.EVENT;
	}

	public bool is_battle()
	{
		return is_event() && evt.type == HuntEvent.Type.BATTLE;
	}

	public bool is_gather()
	{
		return is_event() && evt.type == HuntEvent.Type.GATHER;
	}

	public bool is_talk()
	{
		return is_event() && evt.type == HuntEvent.Type.TALK;
	}
	
	public override void update_state()
	{
		fid++;
		update_logic();

		update_shake();

		if ((int)state >= (int)State.READY)
		{
			update_background();
			update_tachie();

			if (state == State.DISCOVER)
			{
				update_map();
				update_hero_token();
			}
			else if (is_event())
			{
				evt.update_draw();
			}

			update_msg();
			update_hero();
			update_hand();

			update_helper();
		}

		update_shake_after();
	}

	public void update_logic()
	{
		switch (state)
		{
		case State.NONE:
			state = State.READY;
			break;
		case State.READY:
			/*state = State.DISCOVER;
			event = {
				type: HuntEvent.Type.NONE, 
			};*/
			//direct to battle 
			state = State.EVENT;
			evt = new BattleHuntEvent(null);
			evt.setup();

			break;
		case State.DISCOVER:
			update_logic_discover();
			break;
		case State.EVENT:
			evt.update_state();
			break;
		}
	}

	public void update_logic_hand()
	{
		if (is_key(INPUT.DOWN))
		{
			hand_current = (hand_current+1) % hand.Count;
			if (is_event())
			{
				evt.update_hand_move();
			}
			key_delay(INPUT.DOWN, 10, 30);
		}
		if (is_key(INPUT.UP))
		{
			hand_current = (hand_current-1+hand.Count) % hand.Count;
			if (is_event())
			{
				evt.update_hand_move();
			}
			key_delay(INPUT.UP, 10, 30);
		}
		// discover
		if (is_discover())
		{
			if (is_key(INPUT.DECIDE))
			{
				if (can_hand_use())
				{
				}
				key_delay(INPUT.DECIDE, int.MaxValue);
			}
		}
		// event
		else if (is_event())
		{
			evt.update_logic_hand();
		}
	}

	public void update_logic_discover()
	{
		update_logic_hand();
	}

	public void update_background()
	{
		// event block
		if (is_event())
		{
			evt.update_background();
		}
	}

	public void update_tachie()
	{
	}

	public void update_msg()
	{
			/*if (executing_action != null)
			{
				string msg = executing_action.data.name;
			}
			msg = "臣亮言：先帝創業未半，而中道崩殂。今天下三分，益州疲弊，此誠危急存亡之秋也。然侍衛之臣，不懈於內；忠志之士，忘身於外";
			*/
	}

	public void update_map()
	{
	}

	public void update_hero_token()
	{
	}

	public void update_hero()
	{
		/*player_battler.update(self);
		player_battler.draw(self, g);*/
	}

	public void update_hand()
	{
	}

	public void update_helper()
	{
		//set_helper(helper_str || "--");
	}

	public void update_shake()
	{
		/*if (shake_count < shake_length)
		{
			shake_temp_x = 0;
			shake_temp_y = random(shake_power);
			g.translate(shake_temp_x, shake_temp_y);
			shake_count++;
		}*/
	}

	public void update_shake_after()
	{
		/*if (shake_count < shake_length)
		{
			g.translate(-shake_temp_x, -shake_temp_y);
			shake_count++;
		}*/
	}

	public void hand_update()
	{
		/*var spd = .2;
		var diff = Math.abs(data.real_y-data.y);
		if (diff > UI.HAND.HEIGHT-10)
		{
			data.real_desc_a = 0;
			data.real_desc_h = 0;
		}
		else
		{
			data.real_desc_a = lerp(data.real_desc_a, 1, .1);
			data.real_desc_h = lerp(data.real_desc_h, UI.HAND.MAIN_HEIGHT-UI.HAND.HEIGHT, spd);
		}
		data.real_x = lerp(data.real_x, data.x, spd);
		data.real_y = lerp(data.real_y, data.y, spd);
		data.real_a = lerp(data.real_a, data.a, spd);*/
	}

	public void hand_push(Hand card)
	{
		/*var location = (hand.length > 0 ? (hand_current+1) % hand.length : 0);
		hand.splice(location, 0, card);
		hand.splice(location, 0, {
			x: 0, 
			y: 12 + UI.HAND.HEIGHT*4, 
			a: 1, 
			real_x: -UI.HAND.WIDTH, 
			real_y: 12 + UI.HAND.HEIGHT*4, 
			real_a: 0, 
			real_desc_a: 0, 
			real_desc_h: 0, 
		});
		hand_current = location;*/
	}

	public Hand hand_pop()
	{
		Hand res = null;//hand.splice(hand_current, 1)[0];
		//hand.splice(hand_current, 1);
		//hand_current %= hand.length;
		return res;
	}

	public bool can_hand_use()
	{
		//return Card.is_usable(hand[hand_current], self);
		return false;
	}

	public void hand_use()
	{
		/*Card card = hand[hand_current];
		if (Card.is_usable(card, self))
		{
			Card.cost_mp(card, self);
			hand_pop();
			hand_temp.push(card);
			if (is_event())
			{
				evt.hand_use(card);
			}
		}*/
	}

	public bool can_hand_rollback()
	{
		return hand_temp.Count > 0;
	}

	public void clear_hand_rollback()
	{
		hand_temp.Clear();
	}

	public void hand_rollback()
	{
		if (hand_temp.Count > 0)
		{
			/*var card = hand_temp.pop();
			Card.recover_cost_mp(card, self);
			hand_push(card);
			cancel_action(card);*/
		}
	}

	public void draw_card(int num = 1)
	{
		for (var i=0; i<num&&hand.Count<hand_limit; i++)
		{
			Hand card = take_card_from_deck();
			hand_push(card);
		}
	}

	public Hand take_card_from_deck()
	{
		int idx = 0;//random(deck.length);
		Hand res = null;//deck[idx];
		//deck.splice(idx, 1);
		return res;
	}

	public void set_helper(string data)
	{
		//helper_str = generate_helper_str(data);
	}

	public void set_background(Sprite bg)
	{
		//background = bg;
	}

	public void shake(int power, int length)
	{
		shake_power = power;
		shake_length = length;
		shake_count = 0;
	}
}
