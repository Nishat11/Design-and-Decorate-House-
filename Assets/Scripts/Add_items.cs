/*
 * Developed by Nishat A. Bhagat
 * Date //01/10/2017
 * HUD_ingame.cs
 * This script manages all assingned variables with 3D model for bedroom, bathroom, living room and garage.
 * Script manages adding new items (room) in the scene.
 * It has multiple list and which is used from generic class of unity collections.
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Add_items : MonoBehaviour {

	// Define all constant and variable for this script..
	private const string DESIGN_HOUSE_BTN = "Design_house";
	private const string DECORATE_HOUSE_BTN = "Decorate_house";
	private const string COUNTINUE_DESIGN_BTN = "Coutinue Design";
	private const string REQ_COUNTINUE_BTN = "Req_Countinue";
	private const string REQ_CANCEL_BTN = "Req_cancel";
	private const string HELP_BTN = "Help";
	private const string OBJ_COUNTINUE_BTN = "Obj_Countinue";
	public static Add_items instance;
	public GameObject selected_wall_for_door;
	public GameObject warning_screen;

	public GameObject ref_position;
	public Dropdown bed_rm_selection, bath_rm_selection, lvng_rm_selection, door_sellection, garage_selection, Kitchen_selection; 
	public GameObject Small_bed_room, large_bed_room,small_bath_room,large_bath_room,Living_room_small,Living_room_large;
	public GameObject Small_kitchen,Large_kitchen,garage_One_car,garage_two_car;
	// Use this for initialization
	void Start () {
		instance = this;

		bed_rm_selection.onValueChanged.AddListener (delegate 
			{
			add_room (bed_rm_selection);
			});
		bath_rm_selection.onValueChanged.AddListener (delegate 
			{
				add_bathroom (bath_rm_selection);
			});

		lvng_rm_selection.onValueChanged.AddListener
		(delegate {
			add_livingroom (lvng_rm_selection);
		});

		door_sellection.onValueChanged.AddListener
		(delegate {
			add_door (door_sellection);
		});
		Kitchen_selection.onValueChanged.AddListener
		(delegate {
			add_kitchen (Kitchen_selection);
		});
		garage_selection.onValueChanged.AddListener
		(delegate {
			add_garage (garage_selection);
		});

	}
	//Hide this panel..
	public void Disable_add_panel()
	{
		HUD_ingame.instance.add_interier_panel.SetActive (false);
	}

	// Update is called once per frame
	void Update () 
	{

	}

    //Temoparary game object to store object in list
	public GameObject temp;
	//add new item next to the old room wall...
	public void instantiate_item(GameObject itemname,  List<GameObject> listname)
	{

		temp = null;
		if (HUD_ingame.instance.walls.Count == 0) {
			temp = Instantiate (itemname, ref_position.transform.position, Quaternion.identity) as GameObject;
			Debug.Log ("First item....");
		}
		else 
		{
			if(HUD_ingame.instance.walls[0].gameObject.name == "wall_1")
				temp = Instantiate (itemname,HUD_ingame.instance.walls[0].transform.position, Quaternion.identity) as GameObject;
			else if(HUD_ingame.instance.walls[0].gameObject.name == "wall_2")
				temp = Instantiate (itemname,HUD_ingame.instance.walls[0].transform.position, Quaternion.Euler(0f,90f,0f)) as GameObject;
			else if(HUD_ingame.instance.walls[0].gameObject.name == "wall_3")
				temp = Instantiate (itemname,HUD_ingame.instance.walls[0].transform.position, Quaternion.Euler(0f,180f,0f)) as GameObject;
			else if(HUD_ingame.instance.walls[0].gameObject.name == "wall_4")
				temp = Instantiate (itemname,HUD_ingame.instance.walls[0].transform.position, Quaternion.Euler(0f,-90f,0f)) as GameObject;
			Debug.Log ("second item....");
		}
		listname.Add (temp);
		HUD_ingame.instance.Invoke ("Disable_all_dropdown", 0.3f);
		Invoke ("Disable_add_panel",0.35f);

		//Adjust light based on modes...
		if (HUD_ingame.instance.direction_light.intensity == 0f) {
			foreach (Transform child in temp.transform) {
				if (child.CompareTag ("Light"))
					child.GetComponent<Light> ().enabled = true;
			}
		}
	}

	//Add new door base on selection of user....
	public void add_door(Dropdown add_door_value)
	{
		if (HUD_ingame.instance.clicked_obj) {
			if (HUD_ingame.instance.clicked_obj.tag == "OpenWall" || HUD_ingame.instance.clicked_obj.tag == "CloseWall") 
			{
				//Assing selected wall to temp object.....
				GameObject temp_obj = HUD_ingame.instance.clicked_obj;

				if(door_sellection.value == 0)
				{
					//remove door...
					temp_obj.GetComponent<MeshRenderer> ().enabled = true;
					//Remove all old door..
					for(int i =0;i<3;i++)
						temp_obj.transform.GetChild (i).gameObject.SetActive (false);
					temp.tag = "OpenWall";
					//HUD_ingame.instance.Invoke ("Disable_all_dropdown", 0.23f);
					//Invoke ("Disable_add_panel",0.33f);
				}
				else if (door_sellection.value == 1) 
				{
					//Create Door on right side...
					temp_obj.GetComponent<MeshRenderer> ().enabled = false;
					//Remove all old door..
					for(int i =0;i<3;i++)
						temp_obj.transform.GetChild (i).gameObject.SetActive (false);
					//Create new door..
					temp_obj.transform.GetChild (0).gameObject.SetActive (true);
					temp.tag = "Doorwall";
					HUD_ingame.instance.Invoke ("Disable_all_dropdown", 0.23f);
					Invoke ("Disable_add_panel",0.33f);
				} else if (door_sellection.value == 2) {
					//Create Door in Middle...
					temp_obj.GetComponent<MeshRenderer> ().enabled = false;
					//Remove all old door..
					for(int i =0;i<3;i++)
						temp_obj.transform.GetChild (i).gameObject.SetActive (false);
					//Create new door..
					temp_obj.transform.GetChild (1).gameObject.SetActive (true);
					temp.tag = "Doorwall";
					HUD_ingame.instance.Invoke ("Disable_all_dropdown", 0.23f);
					Invoke ("Disable_add_panel",0.33f);
				} else if (door_sellection.value == 3) {
					//Create Door on left side...
					temp_obj.GetComponent<MeshRenderer> ().enabled = false;
					//Remove all old door..
					for(int i =0;i<3;i++)
						temp_obj.transform.GetChild (i).gameObject.SetActive (false);
					//Create new door..
					temp_obj.transform.GetChild (2).gameObject.SetActive (true);
					temp.tag = "Doorwall";
					HUD_ingame.instance.Invoke ("Disable_all_dropdown", 0.23f);
					Invoke ("Disable_add_panel",0.33f);
				}
			}
		}else {
			warning_screen.SetActive (true);
			//Debug.Log ("please select wall to add door...");
		}

	}

	//Add new garage in scene....
	public void add_garage(Dropdown add_garage_drp)
	{
		if (garage_selection.value == 0) 
		{
			//HUD_ingame.instance.Invoke ("Disable_all_dropdown", 0.2f);
		}	
		else if (garage_selection.value == 1) 
		{
			//Instantiate small room..
			instantiate_item (garage_One_car,HUD_ingame.instance.garage);
		}
		//Add large bed room...
		else if (garage_selection.value == 2) 
		{
			//Instanciate large room..
			instantiate_item (garage_two_car,HUD_ingame.instance.garage);
		}
	}

	//Create kitchen.....
	public void add_kitchen(Dropdown add_kitchen_drp)
	{
		if (Kitchen_selection.value == 0) 
		{
			//HUD_ingame.instance.Invoke ("Disable_all_dropdown", 0.2f);
		}	
		else if (Kitchen_selection.value == 1) 
		{
			//Instantiate small room..
			instantiate_item (Small_kitchen,HUD_ingame.instance.kitchen);
		}
		//Add large bed room...
		else if (Kitchen_selection.value == 2) 
		{
			//Instanciate large room..
			instantiate_item (Large_kitchen,HUD_ingame.instance.kitchen);
		}
	}

	//Add new living room in scene....
	public void add_livingroom(Dropdown add_living_room)
	{
		if (lvng_rm_selection.value == 0) 
		{
			//HUD_ingame.instance.Invoke ("Disable_all_dropdown", 0.2f);
		}	
		else if (lvng_rm_selection.value == 1) 
		{
			//Instantiate small room..
			instantiate_item (Living_room_small,HUD_ingame.instance.livingroom);
		}
		//Add large bed room...
		else if (lvng_rm_selection.value == 2) 
		{
			//Instanciate large room..
			instantiate_item (Living_room_large,HUD_ingame.instance.livingroom);
		}
	}

	//Add new bathroom in scene...
	public void add_bathroom(Dropdown add_bath_room)
	{
		if (bath_rm_selection.value == 0) 
		{
			//HUD_ingame.instance.Invoke ("Disable_all_dropdown", 0.2f);
		}	
		else if (bath_rm_selection.value == 1) 
		{
			//Instantiate small room..
			instantiate_item (small_bath_room,HUD_ingame.instance.bathroom);
		}
		//Add large bed room...
		else if (bath_rm_selection.value == 2) 
		{
			//Instanciate large room..
			instantiate_item (large_bath_room,HUD_ingame.instance.bathroom);
		}
	}

	//Add new bed room in scene...
	public void add_room(Dropdown add_bed_room)
	{
		if (bed_rm_selection.value == 0) 
		{
			//HUD_ingame.instance.Invoke ("Disable_all_dropdown", 0.2f);
		}	
		else if (bed_rm_selection.value == 1) 
		{
			//Instantiate small room..
			instantiate_item (Small_bed_room,HUD_ingame.instance.rooms);
		}
		//Add large bed room...
		else if (bed_rm_selection.value == 2) 
		{
			//Instanciate large room..
			instantiate_item (large_bed_room,HUD_ingame.instance.rooms);
		}
	}

}
