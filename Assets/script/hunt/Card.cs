using UnityEngine;
using System.Collections.Generic;

public class Card : MonoBehaviour {

	public enum Side
	{
		BATTLE = 1, 
		DISCOVER = 2, 
	}

	public static List<Card> CARD;

	public static void draw_hand(int idx, HuntScene field)
	{
		/*var id = field.hand[idx];
		var draw_pos = field.hand_pos[idx];
		var c = CARD[id];
		var x = draw_pos.real_x;
		var y = draw_pos.real_y;
		var a = draw_pos.real_a;
		var scale = draw_pos.scale;
		var desc_a = draw_pos.real_desc_a;
		var desc_h = draw_pos.real_desc_h;
		var side = (field.state == HuntScene.State.DISCOVER ? Side.DISCOVER : Side.BATTLE);
		var current = idx == field.hand_current;
		var now_a = g.globalAlpha;
		g.save();
		g.globalAlpha *= a;
		g.translate(x, y);
		g.scale(scale, scale);
		// background
		var style = g.createLinearGradient(0, 0, UI.HAND.WIDTH, 0);
		style.addColorStop(0, COLOR.BLACK);
		style.addColorStop(.5, COLOR.RED);
		style.addColorStop(1, COLOR.DARK_RED);
		g.fillStyle = style;
		g.strokeStyle = "#CC00FF";
		g.fillRect(0, 0, UI.HAND.WIDTH, UI.HAND.HEIGHT);
		var w = 2;
		g.lineWidth = w;
		g.strokeRect(-w, 0, UI.HAND.WIDTH+w, UI.HAND.HEIGHT);
		if (current)
		{
			g.strokeStyle = COLOR.YELLOW;
			g.strokeRect(-w, 0, UI.HAND.WIDTH+w, UI.HAND.HEIGHT);
		}
		// text
		g.textAlign = "left";
		g.textBaseline = "middle";
		var text_y = y;
		var text_x = x;
		var speed;
		var cost;
		var name;
		var desc;
		if (side == Card.SIDE_BATTLE)
		{
			speed = c.speed;
			cost = c.cost;
			name = c.name;
			desc = c.desc;
		}
		else
		{
			speed = c.speed;
			cost = c.cost;
			name = c.name;
			desc = c.desc;
		}
		// speed
		g.fillStyle = UI.HAND.TEXT_COLOR;
		g.font = UI.HAND.SPEED_FONT;
		text_x = 8;
		text_y = 12;
		g.fillText(num_format(speed, 2), text_x, text_y);
		// cost
		g.fillStyle = (Card.is_usable(id, field) ? UI.HAND.USABLE_COLOR : UI.HAND.UNUSABLE_COLOR);
		g.font = UI.HAND.COST_FONT;
		text_x = 4;
		text_y = 32;
		g.fillText(num_format(cost, 2), text_x, text_y);
		// name
		g.fillStyle = UI.HAND.TEXT_COLOR;
		g.font = UI.HAND.TITLE_FONT;
		text_x = 36;
		text_y = UI.HAND.HEIGHT/2;
		g.fillText(name, text_x, text_y);
		// desc
		if (current)
		{
			var temp_a = g.globalAlpha;
			g.globalAlpha *= desc_a;
			// desc back
			text_x = 0;
			text_y = UI.HAND.HEIGHT;
			var h = UI.HAND.MAIN_HEIGHT-UI.HAND.HEIGHT;
			style = g.createLinearGradient(0, text_y, 0, text_y+h);
			style.addColorStop(0, COLOR.DARK_RED);
			style.addColorStop(1, COLOR.DARK_RED2);
			//style.addColorStop(1, COLOR.BLACK);
			g.fillStyle = style;
			g.fillRect(text_x-w, text_y, UI.HAND.WIDTH+w, desc_h);
			g.lineWidth = w;
			g.strokeRect(text_x-w, text_y, UI.HAND.WIDTH+w, desc_h);
			// desc
			g.fillStyle = UI.HAND.TEXT_COLOR;
			g.font = UI.HAND.TEXT_FONT;
			text_x = 12;
			text_y = UI.HAND.HEIGHT + 8;
			g.textBaseline = "top";
			draw_text_width(g, desc, text_x, text_y, UI.HAND.WIDTH-16, 24);
			g.globalAlpha = temp_a;
		}
		g.restore();*/
	}

	public static bool is_usable(int id, HuntScene field)
	{
		//return field.player_battler.mp >= CARD[id].cost;
		return false;
	}

	public static void cost_mp(int id, HuntScene field)
	{
		//field.player_battler.mp -= CARD[id].cost;
	}

	public static void recover_cost_mp(int id, HuntScene field)
	{
		//field.player_battler.mp += CARD[id].cost;
	}
}
