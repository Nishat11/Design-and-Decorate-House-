/*
 * Developed by Nishat A. Bhagat
 * Date //01/10/2017
 * Add_room_interier.cs
 * add interier items in room...
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Add_room_interier : MonoBehaviour {

	public const string ADD_LIVING_ITEMS = "Living_room";
	public const string ADD_BED_ITEMS = "Bed_room";
	public const string CLOSE_INTERIER_BTN = "Interier_close";
	public const string ADD_LIVING_LARGE_ITEMS = "Living_room_large";
	public const string ADD_BED_LARGE_ITEMS = "Bed_room_large";
	public GameObject add_bed_panel,add_living_panel,add_bed_panel_large,add_living_panel_large;
	public static Add_room_interier instance; 

	//public 
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Diable_all_panel()
	{
		//Diable all panel except passed panel;
		add_bed_panel.SetActive (false);
		add_living_panel.SetActive (false);
		add_bed_panel_large.SetActive (false);
		add_living_panel_large.SetActive (false);
	}

	//open panel to add item...
	public void add_panel_click(GameObject clicked)
	{
		switch(clicked.name)
		{
		case ADD_LIVING_ITEMS:
			Diable_all_panel ();
			add_living_panel.SetActive (true);
			break;
		case ADD_BED_ITEMS:
			Diable_all_panel ();
			add_bed_panel.SetActive (true);
			break;
		case ADD_LIVING_LARGE_ITEMS:
			Diable_all_panel ();
			add_living_panel_large.SetActive (true);
			break;
		case ADD_BED_LARGE_ITEMS:
			Diable_all_panel ();
			add_bed_panel_large.SetActive (true);
			break;
		case CLOSE_INTERIER_BTN:
			Diable_all_panel ();
			this.gameObject.SetActive (false);
			break;
		}
	}
}
