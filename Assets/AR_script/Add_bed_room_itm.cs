/*
 * Developed by Nishat A. Bhagat
 * Date //01/10/2017
 * Add_bed_room_itm.cs
 * Add-bed_room.cs is Script to add new items in Augment my room mode.
 * It has variables of all items and its referencee assignned for inspector of unity 3d.
 * It has main function for instantiate new items in Augmented scene. which is taking referece model from assigned variables..
*/

using UnityEngine;
using System.Collections;

public class Add_bed_room_itm : MonoBehaviour {



	//Take references of all sub button for click events..
	public const string ADD_BED_BTN = "Bed";
	public const string ADD_TABLE_BTN = "Table";
	public const string ADD_WALLDROP_BTN = "Walldrop";
	public const string ADD_CHAIR_BTN = "Chair";
	public const string BED_1_BTN = "Bed_1";
	public const string BED_2_BTN = "Bed_2";
	public const string BED_3_BTN = "Bed_3";
	public const string TABLE_1_BTN = "Table_1";
	public const string TABLE_2_BTN = "Table_2";
	public const string TABLE_3_BTN = "Table_3";
	public const string WALLDROP_1_BTN = "Walldrop_1";
	public const string WALLDROP_2_BTN = "Walldrop_2";
	public const string WALLDROP_3_BTN = "Walldrop_3";
	public const string CHAIR_1_BTN = "Chair_1";
	public const string CHAIR_2_BTN = "Chair_2";
	public const string CHAIR_3_BTN = "Chair_3";

	//Define all available buttons
	public GameObject Bed_btn, Table_btn, Chair_btn;
	public GameObject Walldrop_btn;

	// Use this for initialization
	void Start () {
	
	}

	//Hide second panel which displays on click of item types/group
	public void Hide_sub_panel()
	{
		Bed_btn.gameObject.transform.GetChild (1).gameObject.SetActive (false);
		Table_btn.gameObject.transform.GetChild (1).gameObject.SetActive (false);
		Chair_btn.gameObject.transform.GetChild (1).gameObject.SetActive (false);
		Walldrop_btn.gameObject.transform.GetChild (1).gameObject.SetActive (false);
		
	}

	//Activeate main parent panel..
	public void Hide_main_panel()
	{
		Bed_btn.gameObject.transform.parent.gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
	
	}

	//display 3D item in scene from array on button click....
	public void Instantiate_model(int main_array_no, int sub_array_no)
	{
		
		DestroyObject (AR_Controller.instance.main_item);
		AR_Controller.instance.main_item = Instantiate (AR_Controller.instance.bed_room_itms [main_array_no].intArray [sub_array_no]);

	}

	//Button click event.....
	public void select_itm_btn_click(GameObject Select_item)
	{
		Hide_sub_panel ();
		Hide_main_panel ();
		switch (Select_item.name) {
		case BED_1_BTN:
			Instantiate_model (0, 0);
			break;
		case BED_2_BTN:
			Instantiate_model (0, 1);
			break;
		case BED_3_BTN:
			Instantiate_model (0, 2);
			break;
		case TABLE_1_BTN:
			Instantiate_model (1, 0);
			break;
		case TABLE_2_BTN:
			Instantiate_model (1, 1);
			break;
		case TABLE_3_BTN:
			Instantiate_model (1, 2);
			break;
		case WALLDROP_1_BTN:
			Instantiate_model (2, 0);
			break;
		case WALLDROP_2_BTN:
			break;
		case WALLDROP_3_BTN:
			break;
		case CHAIR_1_BTN:
			Instantiate_model (3, 0);
			break;
		case CHAIR_2_BTN:
			Instantiate_model (3, 1);
			break;
		case CHAIR_3_BTN:
			Instantiate_model (3, 2);
			break;

		}
	}


	//Click event for main group type buttons....
	public void Bed_room_btn_click(GameObject bed_rm_click)
	{
		switch(bed_rm_click.name)
		{
		case ADD_BED_BTN:
			Hide_sub_panel ();
			Bed_btn.gameObject.transform.GetChild (1).gameObject.SetActive (true);

			break;
		case ADD_TABLE_BTN:
			Hide_sub_panel ();
			Table_btn.gameObject.transform.GetChild (1).gameObject.SetActive (true);

			break;
		case ADD_WALLDROP_BTN:
			Hide_sub_panel ();
			Walldrop_btn.gameObject.transform.GetChild (1).gameObject.SetActive (true);
		
			break;
		case ADD_CHAIR_BTN:
			Hide_sub_panel ();
			Chair_btn.gameObject.transform.GetChild (1).gameObject.SetActive (true);

			break;

		}
	}
}
