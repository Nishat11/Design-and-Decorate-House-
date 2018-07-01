/*
 * Developed by Nishat A. Bhagat
 * Date //01/10/2017
 * HUD_ingame.cs is contrelled script for in game screens and buttons.
 * It takes references of all screen and buttons to make active and deactive on button event.
 * Script has functions with switch cases which tackes button click events.
 * Name of buttons are defined as a conctant string initilly. 
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class HUD_ingame : MonoBehaviour {

	//Define all contant name for buttons....
	public const string ADD_ITEM_BTN = "Add_interier";
	public const string ADD_ROOM_INTERIER_BTN = "Add_room_interier";
	public const string REARRANGE_BTN = "Rearrange_room";
	public const string CANCEL_BTN = "Cancel";
	public const string DAY_LIGHT_BTN = "Daylight";
	public const string PLAY_VR_MODE_BTN = "Play_VR_mode";
	public const string PLAY_BTN = "Play";
	public const string ADD_ITEM_CLOSE_BTN = "Add_itm_close";
	public const string DAY_LIGHT_CLOSE_BTN = "adj_light_close";
	public const string REARRANGE_CLOSE_BTN = "rearrange_close";
	public const string WARNING_CLOSE_BTN = "Warning_close";
	public const string DELETE_BTN = "Delete";
	public const string ROTATE_BTN = "Rotate";
	public GameObject controll_joystick, Control_button;
	public bool Light_on;
	public int clckd_Room_btn_id,clckd_Living_btn_ids,clckd_Bathrm_btn_ids,clckd_kitchen_btn_ids,clckd_Garage_btn_ids;
	public string Re_clicked_btn_type;

	public GameObject ref_button,content_obj;
	public const string ADD_BEDROOM_BTN = "Add_Bed_Room";
	public const string ADD_BATHROOM_BTN = "Add_Bathroom";
	public const string ADD_LIVINGROOM_BTN = "Add_Living_Room";
	public const string ADD_DOOR_BTN = "Add_Door";
	public const string ADD_WINDOW_BTN = "Add_Window";
	public const string ADD_GARAGE_BTN = "Add_Garage";
	public const string ADD_KITCHEN_BTN = "Add_Kitchen";
	public const string TWO_DIME_BTN = "2D_view";
	public const string THREE_DIME_BTN = "3D_view";



	public int total_no_buttons;
	public GameObject delete_btn;
	public GameObject Bedroom_drpdw, Bathroom_drpdw, Livingroom_drpdw;
	public GameObject Door_drpdw, window_drpdw, Garage_drpdw,kitchen_drpdw;
	public Button button_obj;
	public Slider zoom_slider;
	public GameObject selected_room;
	public GameObject add_interier_panel, adj_light_panel, rearrange_panel, Interier_itm_panel,add_room_interier;
	public Light direction_light;
	public List<GameObject> walls = new List<GameObject> ();
	public List<GameObject> rooms = new List<GameObject> ();
	public List<GameObject> livingroom = new List<GameObject> ();
	public List<GameObject> kitchen = new List<GameObject> ();
	public List<GameObject> bathroom = new List<GameObject> ();
	public List<GameObject> garage = new List<GameObject> ();
	public Camera main_cam;


	//public GameObject fps_controlls,fps_object;
	public Text Selected_itm_name;
	public GameObject clicked_obj;
	public GameObject Design_controls, Play_controls, VR_controls,fps_obj,VR_object;
	public string Playmode;
	//Three modes //1 Desing //2 Play //3 Play_VR
	public GameObject Customize_room_screen,Two_dime_button,Three_Dime_button,Cam_2D_pos,Cam_3D_Pos,Customize_wall_screen;


	public static HUD_ingame instance;
	// Use this for initialization
	void Start () {
		instance = this;
		zoom_slider.onValueChanged.AddListener (delegate {
			OnvalueChange_slider();
		});
		Playmode = "Desing";
		check_playmode ();
	}
		
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
		{
			if (!EventSystem.current.IsPointerOverGameObject (Input.GetTouch (0).fingerId)) 
			{
				Disable_all_dropdown ();
				Deselect_item ();
			}
		}
		#if UNITY_EDITOR
		if (Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject ()) 
		{
			Disable_all_dropdown ();
			Deselect_item ();
		}
		#endif

		if (clicked_obj) {
			Selected_itm_name.text = clicked_obj.name; //+" of "+clicked_obj.transform.parent.name;
			//Show interier panelif selected items layer is interier
			if (clicked_obj.tag == "Bed" || clicked_obj.tag == "Bed_room_Table" || clicked_obj.tag == "livingroom_Table"
				|| clicked_obj.tag == "livingroom_chair" || clicked_obj.tag == "Lcd_table" || clicked_obj.tag == "sofa"
				||clicked_obj.tag == "Dinning_Table") 
			{
				Control_button.SetActive (true);
				if(clicked_obj.tag != "Dinning_Table")
				Interier_itm_panel.SetActive (true);
				
			}
			else
				Interier_itm_panel.SetActive (false);
		} else if (selected_room) {
			Selected_itm_name.text = selected_room.name;
			Interier_itm_panel.SetActive (false);
		} else {
			Selected_itm_name.text = "None";
			Interier_itm_panel.SetActive (false);
		}

		//Show delete btn if room is selected.
		if (selected_room) {
			Customize_room_screen.SetActive (true);
		} else {
			Customize_room_screen.SetActive (false);
			delete_btn.SetActive (true);
		}

		if (clicked_obj) 
		{
			if (clicked_obj.tag == "Room_Floor" || clicked_obj.tag == "OpenWall" || clicked_obj.tag == "CloseWall") {
				Customize_wall_screen.SetActive (true);
				Control_button.SetActive (false);
			}
			else
			{
				if (clicked_obj.tag == "Dinning_Table")
				delete_btn.SetActive (false);
				
				Customize_wall_screen.SetActive (false);
				Customize_room_screen.SetActive (true);
			}

		} else {
			Customize_wall_screen.SetActive (false);
			//Customize_room_screen.SetActive (false);
		}

	}

	//Delete selected room/ item......
	public void Deselect_item()
	{
		if (selected_room) 
		{
			selected_room.transform.position = new Vector3 (selected_room.transform.position.x, 2.5f, selected_room.transform.position.z);
			selected_room = null;
		}
		Control_button.SetActive (false);

		if(clicked_obj)
			clicked_obj = null;
	}

	public void OnvalueChange_slider()
	{
		//For increment and decrement proper value of field of view for camera...
		//float temp_size_x = ;
		if (zoom_slider.value <=0.1f)
			main_cam.fieldOfView = 60;
		else if(zoom_slider.value <=0.2f)
			main_cam.fieldOfView = 55;
		else if(zoom_slider.value <= 0.3f)
			main_cam.fieldOfView = 50;
		else if(zoom_slider.value <=0.4f)
			main_cam.fieldOfView = 45;
		else if(zoom_slider.value <=0.5f)
			main_cam.fieldOfView = 40;
		else if(zoom_slider.value <= 0.6f)
			main_cam.fieldOfView = 35;
		else if(zoom_slider.value <= 0.7f)
			main_cam.fieldOfView = 30;
		else if(zoom_slider.value <= 0.8f)
			main_cam.fieldOfView = 25;
		else if(zoom_slider.value <= 0.9f)
			main_cam.fieldOfView = 20;
		else if(zoom_slider.value <=1)
			main_cam.fieldOfView = 15;
//
//		selected_room.transform.localScale = new Vector3(selected_room.transform.localScale.x
//			,selected_room.transform.localScale.y,selected_room.transform.localScale.z);
	}
	//Disable all dropdown..
	public void Disable_all_dropdown()
	{
		Bedroom_drpdw.SetActive (false);
		Bathroom_drpdw.SetActive (false);
		Livingroom_drpdw.SetActive (false);
		Door_drpdw.SetActive (false);
		window_drpdw.SetActive (false);
		Garage_drpdw.SetActive (false);
		kitchen_drpdw.SetActive (false);
	}

	//Add button click event for in game buttons....
	public void Add_item_btn_clcik(GameObject add_itm_click)
	{
		Disable_all_dropdown ();
		switch (add_itm_click.name) 
		{

		case ADD_BEDROOM_BTN:
			Add_items.instance.bed_rm_selection.value = 0;
			Bedroom_drpdw.SetActive (true);
			break;
		case ADD_BATHROOM_BTN:
			Add_items.instance.bath_rm_selection.value = 0;
			Bathroom_drpdw.SetActive (true);
			break;
		case ADD_LIVINGROOM_BTN:
			Add_items.instance.lvng_rm_selection.value = 0;
			Livingroom_drpdw.SetActive (true);
			break;
		case ADD_DOOR_BTN:
			Add_items.instance.door_sellection.value = 0;
			Door_drpdw.SetActive (true);
			break;
		case ADD_WINDOW_BTN:
			window_drpdw.SetActive (true);
			break;
		case ADD_GARAGE_BTN:
			Add_items.instance.garage_selection.value = 0;
			Garage_drpdw.SetActive (true);
			break;
		case ADD_KITCHEN_BTN:
			Add_items.instance.Kitchen_selection.value = 0;
			kitchen_drpdw.SetActive (true);
			break;

		}
	}

	//Instantiate buttons and assign them delegate.....
	public void generate_buttons(string btn_name, int loop_i)
	{
		Button temp =  Instantiate (button_obj) as Button;
		temp.transform.SetParent(content_obj.transform);
		temp.transform.localPosition = new Vector3 (91f,(-5-7*(total_no_buttons)),0f);
		temp.transform.localScale = new Vector3(1f,0.2f,1f);
		temp.transform.GetChild (0).GetComponent<Text> ().text = btn_name+(loop_i+1);
		total_no_buttons++;


		temp.onClick.AddListener (delegate 
		{
				//Assign gameobject from array to selected_room...
				switch(btn_name)
				{
				case "BedRoom":
					Deselect_item();
					selected_room = rooms[loop_i];
					clckd_Room_btn_id = loop_i;
					Re_clicked_btn_type = btn_name;
					clicked_obj = null;

					break;
				case "Bathroom":
					Deselect_item();
					selected_room = bathroom[loop_i];
					clckd_Bathrm_btn_ids = loop_i;
					Re_clicked_btn_type = btn_name;
					clicked_obj = null;

					break;
				case "LivingRoom":
					Deselect_item();
					selected_room = livingroom[loop_i];
					clckd_Living_btn_ids = loop_i;
					Re_clicked_btn_type = btn_name;
					clicked_obj = null;
					break;
				case "Kitchen":
					Deselect_item();
					selected_room = kitchen[loop_i];
					clckd_kitchen_btn_ids = loop_i;
					Re_clicked_btn_type = btn_name;
					clicked_obj = null;
					break;
				case "Garage":
					Deselect_item();
					selected_room = garage[loop_i];
					//to get type name and number when deleteing room from list for new buttons...
					clckd_Garage_btn_ids = loop_i;
					Re_clicked_btn_type = btn_name;
					//make null other selected objects...
					clicked_obj = null;
					break;
				}

				//Show room above to sho as selected...
//				if(selected_room.transform.position.y < 3f)
//					selected_room.transform.position = new Vector3(selected_room.transform.position.x,selected_room.transform.position.y+3,selected_room.transform.position.z);

				Control_button.SetActive(true);
				rearrange_panel.SetActive(false);
			});
		
	}
	//On click on re_arrange delete and generate all new buttons..
	public void available_buttons()
	{
		//Initially alll btton ids are zero....
		//Room_btn_ids = Bathrm_btn_ids = Living_btn_ids = Garage_btn_ids = kitchen_btn_ids = 0;

		foreach (Transform child in content_obj.transform) {
			Destroy (child.gameObject);
			total_no_buttons = 0;
		}
		for (int i = 0; i < rooms.Count; i++) 
		{
			generate_buttons ("BedRoom",i);
			//clckd_Room_btn_ids++;
		}
		for (int i = 0; i < bathroom.Count; i++) 
		{
			generate_buttons ("Bathroom",i);
			//clckd_Bathrm_btn_ids++;
		}
		for (int i = 0; i < livingroom.Count; i++) 
		{
			generate_buttons ("LivingRoom",i);
			//clckd_Living_btn_ids++;
		}
		for (int i = 0; i < kitchen.Count; i++) 
		{
			generate_buttons ("Kitchen",i);
			//clckd_kitchen_btn_ids++;
		}
		for (int i = 0; i < garage.Count; i++) 
		{
			generate_buttons ("Garage",i);
			//clckd_Garage_btn_ids++;
		}
	}

	public void check_playmode()
	{
		rearrange_panel.SetActive (false);
		add_interier_panel.SetActive (false);
		adj_light_panel.SetActive (false);
		//GameObject Vr_temp_object = null;
		Deselect_item();
		switch(Playmode)
		{
		case "Desing":
			Design_controls.SetActive (true);
			Play_controls.SetActive (false);
			VR_controls.SetActive (false);
			//fps_obj.SetActive (false);
			main_cam.enabled = true;
			if(GameObject.Find("GvrMain(Clone)"))
				Destroy (GameObject.Find("GvrMain(Clone)"));
			if(GameObject.Find("FPSController(Clone)"))
				Destroy (GameObject.Find("FPSController(Clone)"));
			//VR_object.SetActive (false);
			break;
		case "Play":
			Play_controls.SetActive (true);
			Design_controls.SetActive (false);
			VR_controls.SetActive (false);
			Instantiate (fps_obj);
			main_cam.enabled = false;
			break;
		case "Play_VR":
			VR_controls.SetActive (true);
			Design_controls.SetActive (false);
			Play_controls.SetActive (false);
			//fps_obj.SetActive (false);
			main_cam.enabled = false;
			Instantiate (VR_object);
			//VR_object.SetActive (true);
			break;
		}
	}

	//Handle click event for ingame button click....
	public void Hud_btn_click(GameObject hud_click)
	{
		switch (hud_click.name) 
		{
		case ADD_ITEM_BTN:
			
			walls.Clear ();
			walls.AddRange (GameObject.FindGameObjectsWithTag ("OpenWall"));
			add_interier_panel.SetActive (true);
			adj_light_panel.SetActive (false);
			rearrange_panel.SetActive (false);
			add_room_interier.SetActive (false);
			selected_room = null;
			Control_button.SetActive (false);
			if(clicked_obj)
			if (clicked_obj.tag != "OpenWall" && clicked_obj.tag != "CloseWall") {
				clicked_obj = null;
			}
				
			break;
		case ADD_ROOM_INTERIER_BTN:
			add_room_interier.SetActive (true);
			add_interier_panel.SetActive (false);
			adj_light_panel.SetActive (false);
			rearrange_panel.SetActive (false);
			break;
		case REARRANGE_BTN:
			available_buttons ();
			rearrange_panel.SetActive (true);
			add_interier_panel.SetActive (false);
			adj_light_panel.SetActive (false);
			add_room_interier.SetActive (false);
			break;
		case DAY_LIGHT_BTN:
			adj_light_panel.SetActive (true);
			add_interier_panel.SetActive (false);
			rearrange_panel.SetActive (false);
			add_room_interier.SetActive (false);
			break;
		case ADD_ITEM_CLOSE_BTN:
			add_interier_panel.SetActive (false);
			Disable_all_dropdown ();
			break;
		case WARNING_CLOSE_BTN:
			Add_items.instance.warning_screen.SetActive (false);
			break;
		case DAY_LIGHT_CLOSE_BTN:
			adj_light_panel.SetActive (false);
			break;
		case REARRANGE_CLOSE_BTN:
			rearrange_panel.SetActive (false);

			break;


		case ROTATE_BTN:
			if (selected_room) {
				selected_room.transform.RotateAround (selected_room.transform.position, Vector3.up, 90);
			}
			else if(clicked_obj)
			{
				clicked_obj.transform.RotateAround (clicked_obj.transform.position, Vector3.up, 90);
			}
			break;

		case DELETE_BTN:
			if (selected_room) {
				Destroy (selected_room.gameObject);
				selected_room = null;
				Deselect_item ();
				switch (Re_clicked_btn_type.ToString ()) {
				case "BedRoom":
					rooms.RemoveAt (clckd_Room_btn_id);
					break;
				case "Bathroom":
					bathroom.RemoveAt (clckd_Bathrm_btn_ids);
					break;
				case "LivingRoom":
					livingroom.RemoveAt (clckd_Living_btn_ids);
					break;
				case "Kitchen":
					kitchen.RemoveAt (clckd_kitchen_btn_ids);
					break;
				case "Garage":
					garage.RemoveAt (clckd_Garage_btn_ids);
					break;
				}
			} else if(clicked_obj){
					Destroy (clicked_obj.gameObject);
				Deselect_item ();
			}
			break;
	

		case PLAY_VR_MODE_BTN:
			Playmode = "Play_VR";
			check_playmode ();
			break;

		case PLAY_BTN: 
			Playmode = "Play";
			check_playmode ();
			break;

		case CANCEL_BTN:
			Playmode = "Desing";
			check_playmode ();
			break;
		case TWO_DIME_BTN:
			Three_Dime_button.SetActive (true);
			Two_dime_button.SetActive (false);
			main_cam.transform.position = Cam_2D_pos.transform.position;
			main_cam.transform.eulerAngles = Cam_2D_pos.transform.eulerAngles;
			break;
		case THREE_DIME_BTN:
			Three_Dime_button.SetActive (false);
			Two_dime_button.SetActive (true);
			main_cam.transform.position = Cam_3D_Pos.transform.position;
			main_cam.transform.eulerAngles = new Vector3 (25f,0f,0f);
			break;

		

		}
	}
}
