using UnityEngine;
using System.Collections.Generic;

public class UIHand : MonoBehaviour
{
	public const int CARD_POOL_SIZE = 11;
	public const int DISPLAY_COUNT = 9;

	public UICard card_template;

	public float center_line = -400f;
	public int[] level_x = new int[DISPLAY_COUNT/2] {
		8, 14, 26, 42, 
	};
	public int[] level_y = new int[DISPLAY_COUNT/2] {
		4, 8, 12, 16, 
	};
	public int base_x = 20;
	public int base_y = 50;
	public int desc_y = 70;

	private List<Card> card_list;
	private List<UICard> card_ui_list;
	private List<UICard> card_pool;
	private int length;
	private int selected;

	void Awake()
	{
		if (card_template == null)
		{
			card_template = GetComponentInChildren<UICard>();
		}
		card_template.gameObject.SetActive(false);
		card_ui_list = new List<UICard>();
		card_pool = new List<UICard>();
		for (int i=0; i<CARD_POOL_SIZE; i++)
		{
			UICard c = Instantiate(card_template);
			card_pool.Add(c);
			c.transform.SetParent(transform, false);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public UIHand load()
	{
		gameObject.SetActive(true);
		return this;
	}

	private void delete_card(int idx)
	{
		UICard card = card_ui_list[idx];
		card_pool.Add(card);
		card_ui_list.RemoveAt(idx);
		card.gameObject.SetActive(false);
	}

	private void add_card()
	{
		UICard card = card_pool[card_pool.Count-1];
		card_ui_list.Add(card);
		card_pool.RemoveAt(card_pool.Count-1);
		card.gameObject.SetActive(true);
	}

	private int get_dis(int idx)
	{
		int dis = selected - idx;
		if (dis+dis > length)
		{
			dis -= length;
		}
		else if (dis+dis < -length)
		{
			dis += length;
		}
		return dis;
	}

	private void set_ui_pos(UICard card, int dis)
	{
		int abs_dis = Mathf.Abs(dis);
		int sign = (dis > 0 ? -1 : 1);
		float x = base_x;
		float y = center_line + (dis > 0 ? -desc_y : 0);
		for (int i=0; i<abs_dis; i++)
		{
			y += sign * (base_y - level_y[i]);
		}
		for (int i=DISPLAY_COUNT/2-1; i>=abs_dis; i--)
		{
			x += level_x[i];
		}
		card.set_pos(x, y);
	}

	public void set_hand(List<Card> hand, int sel = 0)
	{
		card_list = hand;
		length = card_list.Count;
		selected = sel;
		// sync card number
		if (card_ui_list.Count > length)
		{
			while (card_ui_list.Count > length)
			{
				delete_card(card_ui_list.Count-1);
			}
		}
		else if (card_ui_list.Count < length)
		{
			while (card_ui_list.Count < length)
			{
				add_card();
			}
		}
		// set card into ui
		for (int i=0; i<length; i++)
		{
			UICard ui = card_ui_list[i];
			ui.set_card(card_list[i]);
			ui.set_selected(selected == i);
			// get location
			int dis = get_dis(i);
			if (Mathf.Abs(dis) > DISPLAY_COUNT/2)
			{
				ui.set_visible(false);
			}
			else
			{
				ui.set_visible(true);
				set_ui_pos(ui, dis);
			}
		}
		// sibling needs to do last
		int half = Mathf.Min(DISPLAY_COUNT, length)/2;
		for (int i=selected-half; i<selected; i++)
		{
			int idx = (i+length) % length;
			card_ui_list[idx].transform.SetAsLastSibling();
		}
		for (int i=selected; i<=selected+half; i++)
		{
			int idx = i % length;
			card_ui_list[idx].transform.SetAsFirstSibling();
		}
	}
}
