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

	private Card card;
	private bool selected;
	private Vector2 from_pos;
	private Vector2 tar_pos;

	void Awake()
	{
		self_ui = GetComponent<Image>();
		outline_ui = GetComponent<Outline>();
		tar_pos = new Vector2(-1000, -1000);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void set_card(Card c)
	{
		card = c;
	}

	public void set_pos(float x, float y)
	{
		self_ui.rectTransform.anchoredPosition = new Vector2(x, y);
		/*tar_pos = new Vector2(x, y);
		if (Mathf.Abs(from_pos.y - tar_pos.y) > 215)
		{
		}*/
	}

	public void set_selected(bool val)
	{
		selected = val;
		desc_obj.SetActive(selected);
		outline_ui.effectColor = (selected ? Color.yellow : new Color(180/255f, 0f, 240/255f));
	}

	public void set_visible(bool vis)
	{
		gameObject.SetActive(vis);
	}
}
