/*
 * Developed by Nishat A. Bhagat
 * Date //01/10/2017
 * Mainmenu.cs script handles flow of mainmenu screen and all other sub screen conncted with it.
 * It has button events for all buttns of main menu.
 * It is taking refernces of all button by providing Const as a name of buttons.
 * It uses switch case which provides events for all buttons.
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {

	//All constant variables defined for buttons..
	private const string DESIGN_HOUSE_BTN = "Design_house";
	private const string DECORATE_HOUSE_BTN = "Decorate_house";
	private const string COUNTINUE_DESIGN_BTN = "Coutinue Design";
	private const string REQ_COUNTINUE_BTN = "Req_Countinue";
	private const string REQ_CANCEL_BTN = "Req_cancel";
	private const string HELP_BTN = "Help";
	private const string OBJ_COUNTINUE_BTN = "Obj_Countinue";
	public const string BACK_YES = "Yes";
	public const string BACK_NO = "No";
	public const string HELP_BACK = "Help_Back";
	public const string SKIP_BTN = "Skip";
	public const string REF_BTN = "References";
	public const string REF_BACK_BTN = "Ref_Back";
	public static MainMenu instance; 
	public GameObject back_btn_warning_screen;

	public GameObject MainMenu_screen, Requirement_screen, Objective_screen,Help_screen,ref_screen;
	public GameObject HUB_BAR, LUD_BAR;
	public List<GameObject> instructions = new List<GameObject>();

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//check back button pressed
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if(HUB_BAR.activeSelf)
				back_btn_warning_screen.transform.GetChild (1).GetComponent<Text>().text = "Quit Desing Mode and goto MainMenu..?";
			else
				back_btn_warning_screen.transform.GetChild (1).GetComponent<Text>().text = "Quit Application..??";
			
			back_btn_warning_screen.SetActive (true);
			//HUD_ingame.instance;

		}

	}

	//Button click event for main menu buttons.....
	public void Mainmenu_Btn_Click(GameObject Main_btn_click)
	{
		switch (Main_btn_click.name) {
		case DESIGN_HOUSE_BTN:
			MainMenu_screen.SetActive (false);
			//HUB_BAR.SetActive (true);
			Requirement_screen.SetActive (true);
			//DE-activate all instructions..
			for(int i = 0; i<4;i++)
				instructions [i].SetActive (false);
			//Show first instruction.
			instructions [0].SetActive (true);
			break;
		case DECORATE_HOUSE_BTN:
			Application.LoadLevel (1);
			//Application.UnloadLevel (0);
			Debug.Log ("yes it clicked");
			break;
		case HELP_BTN:
			Help_screen.SetActive (true);
			MainMenu_screen.SetActive (false);
			break;
		case REQ_COUNTINUE_BTN:
			if (instructions [0].activeSelf == true) 
			{
				instructions [0].SetActive (false);
				instructions [1].SetActive (true);
			}
			else if (instructions [1].activeSelf == true) {
				instructions [1].SetActive (false);
				instructions [2].SetActive (true);
			}
			else if (instructions [2].activeSelf == true) {
				instructions [2].SetActive (false);
				instructions [3].SetActive (true);
			}
			else if (instructions [3].activeSelf == true) {
				Requirement_screen.SetActive (false);
				HUB_BAR.SetActive (true);
			}
			break;
		case REQ_CANCEL_BTN:
			if (instructions [0].activeSelf == true) {
				Requirement_screen.SetActive (false);
				MainMenu_screen.SetActive (true);
			}
			else if (instructions [1].activeSelf == true) {
				instructions [1].SetActive (false);
				instructions [0].SetActive (true);
			}
			else if (instructions [2].activeSelf == true) {
				instructions [2].SetActive (false);
				instructions [1].SetActive (true);
			}
			else if (instructions [3].activeSelf == true) {
				instructions [3].SetActive (false);
				instructions [2].SetActive (true);
			}

			break;
		case OBJ_COUNTINUE_BTN:
			Objective_screen.SetActive (false);
			MainMenu_screen.SetActive (true);
			break;
		case SKIP_BTN:
			Requirement_screen.SetActive (false);
			HUB_BAR.SetActive (true);
			break;
		case BACK_NO:
			back_btn_warning_screen.SetActive (false);
			break;
		case HELP_BACK:
			Help_screen.SetActive (false);
			MainMenu_screen.SetActive (true);
			break;
		case BACK_YES:
			if (HUB_BAR.activeSelf) 
			{
				Application.LoadLevel (Application.loadedLevelName);
			} 
			else 
			{	
				Application.Quit ();
			}

			//this.gameObject.SetActive (false);
			break;

		case REF_BTN:
			MainMenu_screen.SetActive (false);
			ref_screen.SetActive (true);
			break;

		case REF_BACK_BTN:
			MainMenu_screen.SetActive (true);
			ref_screen.SetActive (false);
			break;
		}
	}
}
