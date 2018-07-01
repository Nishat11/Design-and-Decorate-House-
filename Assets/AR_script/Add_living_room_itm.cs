/*
 * Developed by Nishat A. Bhagat
 * Date //01/15/2017
 * Add_living_room_itm.cs
 * add living room items in AR mode...
*/
using UnityEngine;
using System.Collections;

public class Add_living_room_itm : MonoBehaviour {

	//Define all available buttons
	public GameObject Sofa_btn, LCD_tv_btn, LCD_Table_btn,Table_btn, Chair_btn;

	//Take references of all sub button for click events..
	public const string ADD_SOFA_BTN = "Sofa";
	public const string ADD_LCD_BTN = "LCD_TV";
	public const string ADD_LCD_TABLE_BTN = "LCD_Table";
	public const string ADD_TABLE_BTN = "Table";
	public const string ADD_CHAIR_BTN = "Chair";
	public const string SOFA_1_BTN = "Sofa_1";
	public const string SOFA_2_BTN = "Sofa_2";
	public const string SOFA_3_BTN = "Sofa_3";
	public const string LCD_TV_1_BTN = "LCD_TV_1";
	public const string LCD_TV_2_BTN = "LCD_TV_2";
	public const string LCD_TV_3_BTN = "LCD_TV_3";
	public const string LCD_TABLE_1_BTN = "LCD_Table_1";
	public const string LCD_TABLE_2_BTN = "LCD_Table_2";
	public const string LCD_TABLE_3_BTN = "LCD_Table_3";
	public const string TABLE_1_BTN = "Table_1";
	public const string TABLE_2_BTN = "Table_2";
	public const string TABLE_3_BTN = "Table_3";
	public const string CHAIR_1_BTN = "Chair_1";
	public const string CHAIR_2_BTN = "Chair_2";
	public const string CHAIR_3_BTN = "Chair_3";

	// Use this for initialization
	void Start () {
	
	}

	//Hide second panel which displays on click of item types/group
	public void Hide_sub_panel()
	{
		Sofa_btn.gameObject.transform.GetChild (1).gameObject.SetActive (false);
		LCD_Table_btn.gameObject.transform.GetChild (1).gameObject.SetActive (false);
		Table_btn.gameObject.transform.GetChild (1).gameObject.SetActive (false);
		Chair_btn.gameObject.transform.GetChild (1).gameObject.SetActive (false);

		LCD_tv_btn.gameObject.transform.GetChild (1).gameObject.SetActive (false);
		
	}

	//Activeate main parent panel..
	public void Hide_main_panel()
	{
		Sofa_btn.gameObject.transform.parent.gameObject.SetActive (false);
	}

	//display 3D item in scene from array on button click....
	public void Instantiate_model(int main_array_no, int sub_array_no)
	{
		
		DestroyObject (AR_Controller.instance.main_item);
		AR_Controller.instance.main_item = Instantiate (AR_Controller.instance.living_room_itms [main_array_no].intArray [sub_array_no]);
	}

	//Button click event.....
	public void select_itm_btn_click(GameObject Select_item)
	{
		Hide_sub_panel ();
		Hide_main_panel ();
		switch (Select_item.name) {
		case SOFA_1_BTN:
			Instantiate_model (0, 0);
			break;
		case SOFA_2_BTN:
			Instantiate_model (0, 1);
			break;
		case SOFA_3_BTN:
			Instantiate_model (0, 2);
			break;
		case LCD_TV_1_BTN:
			Instantiate_model (1, 0);
			break;
		case LCD_TV_2_BTN:
			Instantiate_model (1, 1);
			break;
		case LCD_TV_3_BTN:
			Instantiate_model (1, 2);
			break;
		case LCD_TABLE_1_BTN:
			Instantiate_model (2, 0);
			break;
		case LCD_TABLE_2_BTN:
			Instantiate_model (2, 1);
			break;
		case LCD_TABLE_3_BTN:
			Instantiate_model (2, 2);
			break;
		case TABLE_1_BTN:
			Instantiate_model (3, 0);
			break;
		case TABLE_2_BTN:
			Instantiate_model (3, 1);
			break;
		case TABLE_3_BTN:
			Instantiate_model (3, 2);
			break;

		case CHAIR_1_BTN:
			Instantiate_model (4, 0);
			break;
		case CHAIR_2_BTN:
			Instantiate_model (4, 1);
			break;
		case CHAIR_3_BTN:
			Instantiate_model (4, 2);
			break;

		}
	}

	//Click event for main group type buttons....
	public void lvng_room_btn_click(GameObject lvng_rm_click)
	{
		switch(lvng_rm_click.name)
		{
		case ADD_SOFA_BTN:
			Hide_sub_panel ();
			Sofa_btn.gameObject.transform.GetChild (1).gameObject.SetActive (true);

			break;
		case ADD_LCD_BTN:
			Hide_sub_panel ();
			LCD_tv_btn.gameObject.transform.GetChild (1).gameObject.SetActive (true);
			break;

		case ADD_LCD_TABLE_BTN:
			Hide_sub_panel ();
			LCD_Table_btn.gameObject.transform.GetChild (1).gameObject.SetActive (true);
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
