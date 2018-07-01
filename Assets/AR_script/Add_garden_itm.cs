/*
 * Developed by Nishat A. Bhagat
 * Date //01/15/2017
 * Add_garden_itm.cs
 * add garden items in AR mode...
*/

using UnityEngine;
using System.Collections;

public class Add_garden_itm : MonoBehaviour {


	//Take references of all sub button for click events..
	public const string ADD_PLANT_BTN = "Plant";
	public const string ADD_TABLE_BTN = "Table";
	public const string ADD_CHAIR_BTN = "Chair";
	public const string PLANT_1_BTN = "Plant_1";
	public const string PLANT_2_BTN = "Plant_2";
	public const string PLANT_3_BTN = "Plant_3";
	public const string TABLE_1_BTN = "Table_1";
	public const string TABLE_2_BTN = "Table_2";
	public const string TABLE_3_BTN = "Table_3";
	public const string CHAIR_1_BTN = "Chair_1";
	public const string CHAIR_2_BTN = "Chair_2";
	public const string CHAIR_3_BTN = "Chair_3";

	//Define all available buttons
	public GameObject Plant_btn, Table_btn, Chair_btn;
	// Use this for initialization
	void Start () {
	
	}

	public void Hide_sub_panel()
	{
		Plant_btn.gameObject.transform.GetChild (1).gameObject.SetActive (false);
		Table_btn.gameObject.transform.GetChild (1).gameObject.SetActive (false);
		Chair_btn.gameObject.transform.GetChild (1).gameObject.SetActive (false);
	}

	//Activeate main parent panel..
	public void Hide_main_panel()
	{
		Plant_btn.gameObject.transform.parent.gameObject.SetActive (false);
	}

	//display 3D item in scene from array on button click....
	public void Instantiate_model(int main_array_no, int sub_array_no)
	{
		DestroyObject (AR_Controller.instance.main_item);
		AR_Controller.instance.main_item = Instantiate ( AR_Controller.instance.garden_itms [main_array_no].intArray [sub_array_no]);
	}

	//Button click event.....
	public void select_itm_btn_click(GameObject Select_item)
	{
		Hide_sub_panel ();
		Hide_main_panel ();
		switch (Select_item.name) {
		case PLANT_1_BTN:
			Instantiate_model (0, 0);
			break;
		case PLANT_2_BTN:
			Instantiate_model (0, 1);
			break;
		case PLANT_3_BTN:
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
		case CHAIR_1_BTN:
			Instantiate_model (2, 0);
			break;
		case CHAIR_2_BTN:
			Instantiate_model (2, 1);
			break;
		case CHAIR_3_BTN:
			Instantiate_model (2, 2);
			break;

		}
	}


	//Click event for main group type buttons....
	public void grdn_room_btn_click(GameObject grdn_rm_click)
	{
		switch(grdn_rm_click.name)
		{
		case ADD_PLANT_BTN:
			Hide_sub_panel ();
			Plant_btn.gameObject.transform.GetChild (1).gameObject.SetActive (true);

			break;
		case ADD_TABLE_BTN:
			Hide_sub_panel ();
			Table_btn.gameObject.transform.GetChild (1).gameObject.SetActive (true);

			break;
		
		case ADD_CHAIR_BTN:
			Hide_sub_panel ();
			Chair_btn.gameObject.transform.GetChild (1).gameObject.SetActive (true);

			break;

		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
