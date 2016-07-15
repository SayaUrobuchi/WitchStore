using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICard : MonoBehaviour
{
	public Text cost_ui;
	public Text speed_ui;
	public Text name_ui;
	public Outline outline_ui;
	public GameObject desc_obj;
	public Text desc_ui;

	private Image self_ui;
	private Image desc_img;
	private float desc_height;

	private Card card;
	private bool selected;
	private Vector2 from_pos;
	private Vector2 tar_pos;
	private float pos_timer;
	private float move_time = .5f;

	void Awake()
	{
		self_ui = GetComponent<Image>();
		outline_ui = GetComponent<Outline>();
		tar_pos = new Vector2(-1000, -1000);
		desc_img = desc_obj.GetComponent<Image>();
		desc_height = desc_img.get_height();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (pos_timer < 1f)
		{
			pos_timer = Mathf.Clamp01(pos_timer + Time.deltaTime/move_time);
			float curve = UI.swing_curve(pos_timer);
			float x = from_pos.x + (tar_pos.x-from_pos.x) * curve;
			float y = from_pos.y + (tar_pos.y-from_pos.y) * curve;
			self_ui.rectTransform.anchoredPosition = new Vector2(x, y);
			if (selected)
			{
				desc_img.set_height(desc_height * curve);
			}
		}
	}

	public void set_card(Card c)
	{
		card = c;
	}

	public void set_pos(float x, float y)
	{
		//self_ui.rectTransform.anchoredPosition = new Vector2(x, y);
		tar_pos = new Vector2(x, y);
		from_pos = self_ui.rectTransform.anchoredPosition;
		if (Mathf.Abs(from_pos.y - tar_pos.y) > 415)
		{
			from_pos = tar_pos + new Vector2(-100, 50);
		}
		pos_timer = 0f;
	}

	public void set_selected(bool val)
	{
		selected = val;
		if (!selected)
		{
			desc_img.set_height(0f);
		}
		outline_ui.effectColor = (selected ? Color.yellow : new Color(180/255f, 0f, 240/255f));
	}

	public void set_visible(bool vis)
	{
		gameObject.SetActive(vis);
	}
}
