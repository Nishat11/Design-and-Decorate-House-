/*
 * Developed by Nishat A. Bhagat
 * Date //01/10/2017
 * Add_bedroom_items.cs
 * add bed rooom items in Design mode...
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class Add_bedroom_items : MonoBehaviour {


	//public List<GameObject> bed_room_itms= new List<>(GameObject);
	//public GameObject obj_bed,obj_table,obj_chair;
	public const string ADD_BUTTON_1 = "Item_1";
	public const string ADD_BUTTON_2 = "Item_2";
	public const string ADD_BUTTON_3 = "Item_3";
	public const string ADD_BUTTON_4 = "Item_4";

	public List<GameObject> items = new List<GameObject>();

	/*bed room item list values
	 * 0=bed
	 * 1=table
	 * 3=chair
	/*bed room item list..
	 * 0=sofa
	 * 1=lcd_table
	 * 3 = table
	 * 4 = chair
	*/

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void bed_room_clicked(GameObject clicked)
	{
		Add_room_interier.instance.Diable_all_panel ();
		Add_room_interier.instance.gameObject.SetActive (false);
		switch(clicked.name)
		{
		case ADD_BUTTON_1:
			Instantiate (items[0]);
			break;
		case ADD_BUTTON_2:
			Instantiate (items[1]);
			break;
		case ADD_BUTTON_3:
			Instantiate (items[2]);
			break;
		case ADD_BUTTON_4:
			Instantiate (items[3]);
			break;
		
		}
	}
}
