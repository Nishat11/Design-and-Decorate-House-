/*
 * Developed by Nishat A. Bhagat
 * Date //01/10/2017
 * Interier_item.cs
 * Customize interier items and models...
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Interier_item : MonoBehaviour {
	public const string INTERIER_BTN_1 = "Int_btn_1";
	public const string INTERIER_BTN_2 = "Int_btn_2";
	public const string INTERIER_BTN_3 = "Int_btn_3";
	public const string INTERIER_BTN_CLOSE = "Int_close";

	public List<GameObject> Int_buttons = new List<GameObject>();
	public List<Sprite> Bed = new List<Sprite> ();
	public List<Sprite> Bed_room_Table = new List<Sprite> ();
	public List<Sprite> livingroom_Table = new List<Sprite> ();
	public List<Sprite> livingroom_chair = new List<Sprite> ();
	public List<Sprite> Lcd_table = new List<Sprite> ();
	public List<Sprite> sofa = new List<Sprite> ();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnEnable()
	{
		if(HUD_ingame.instance.clicked_obj)
		switch (HUD_ingame.instance.clicked_obj.tag) {
		case "Bed":
			for (int i = 0; i < Int_buttons.Count; i++)
				Int_buttons [i].GetComponent<Image> ().sprite = Bed [i];
			break;
		case "Bed_room_Table":
			for (int i = 0; i < Int_buttons.Count; i++)
				Int_buttons [i].GetComponent<Image> ().sprite = Bed_room_Table [i];
			break;
		case "livingroom_Table":
			for (int i = 0; i < Int_buttons.Count; i++)
				Int_buttons [i].GetComponent<Image> ().sprite = livingroom_Table [i];
			break;
		case "livingroom_chair":
			for (int i = 0; i < Int_buttons.Count; i++)
				Int_buttons [i].GetComponent<Image> ().sprite = livingroom_chair [i];
			break;
		case "Lcd_table":
			for (int i = 0; i < Int_buttons.Count; i++)
				Int_buttons [i].GetComponent<Image> ().sprite = Lcd_table [i];
			break;
		case "sofa":
			for (int i = 0; i < Int_buttons.Count; i++)
				Int_buttons [i].GetComponent<Image> ().sprite = sofa [i];
			break;
		}
			
	}

	public void Int_btn_clicked(GameObject int_clicked)
	{
		switch(int_clicked.name)
		{
		case INTERIER_BTN_1:
			HUD_ingame.instance.clicked_obj.transform.GetChild (0).gameObject.SetActive (true);
			HUD_ingame.instance.clicked_obj.transform.GetChild (1).gameObject.SetActive (false);
			HUD_ingame.instance.clicked_obj.transform.GetChild (2).gameObject.SetActive (false);
			break;
		case INTERIER_BTN_2:
			HUD_ingame.instance.clicked_obj.transform.GetChild (1).gameObject.SetActive (true);
			HUD_ingame.instance.clicked_obj.transform.GetChild (0).gameObject.SetActive (false);
			HUD_ingame.instance.clicked_obj.transform.GetChild (2).gameObject.SetActive (false);
			break;
		case INTERIER_BTN_3:
			HUD_ingame.instance.clicked_obj.transform.GetChild (2).gameObject.SetActive (true);
			HUD_ingame.instance.clicked_obj.transform.GetChild (1).gameObject.SetActive (false);
			HUD_ingame.instance.clicked_obj.transform.GetChild (0).gameObject.SetActive (false);
			break;
		case INTERIER_BTN_CLOSE:
			this.gameObject.SetActive (false);
			break;
		}
	}
}
