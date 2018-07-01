/*
 * Developed by Nishat A. Bhagat
 * Date //01/15/2017
 * Room_Movement.cs
 * Move room from current postion to new position...
*/
using UnityEngine;
using System.Collections;

public class Room_Movement : MonoBehaviour {

	public const string RIGHT_ARROW_BTN = "Right_Arrow";
	public const string DOWN_ARROW_BTN = "Down_Arrow";
	public const string LEFT_ARROW_BTN = "Left_Arrow";
	public const string UP_ARROW_BTN = "Up_Arrow";
	public float room_movement_speed = 0.5f;
	public float item_movement_speed = 0.2f;

	public int movement_spped;
	public GameObject temp_selected_room; 
	bool repeatPositionUp = false;
	bool repeatPositionDown = false;
	bool repeatPositionLeft = false;
	bool repeatPositionRight = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(HUD_ingame.instance.selected_room != null)
			temp_selected_room = HUD_ingame.instance.selected_room;
		else
			temp_selected_room = HUD_ingame.instance.clicked_obj;
		//obj_hud_ingame.selected_room
		if (repeatPositionUp) {
			if (temp_selected_room != null) {
				if(HUD_ingame.instance.selected_room != null)
					temp_selected_room = HUD_ingame.instance.selected_room;
				else
					temp_selected_room = HUD_ingame.instance.clicked_obj;
				temp_selected_room.transform.position = new Vector3 (temp_selected_room.transform.position.x
					, temp_selected_room.transform.position.y
					, temp_selected_room.transform.position.z + room_movement_speed);
			}
		}

		if (repeatPositionDown) {
			if (temp_selected_room != null) {
				if(HUD_ingame.instance.selected_room != null)
					temp_selected_room = HUD_ingame.instance.selected_room;
				else
					temp_selected_room = HUD_ingame.instance.clicked_obj;
				temp_selected_room.transform.position = new Vector3 (temp_selected_room.transform.position.x
					, temp_selected_room.transform.position.y
					, temp_selected_room.transform.position.z - room_movement_speed);
			}
		}

		if (repeatPositionLeft) {
			if (temp_selected_room != null) {
				if(HUD_ingame.instance.selected_room != null)
					temp_selected_room = HUD_ingame.instance.selected_room;
				else
					temp_selected_room = HUD_ingame.instance.clicked_obj;
				temp_selected_room.transform.position = new Vector3 (temp_selected_room.transform.position.x - room_movement_speed
					, temp_selected_room.transform.position.y
					, temp_selected_room.transform.position.z);
			}
		}

		if (repeatPositionRight) {
			if (temp_selected_room != null) {
				if(HUD_ingame.instance.selected_room != null)
					temp_selected_room = HUD_ingame.instance.selected_room;
				else
					temp_selected_room = HUD_ingame.instance.clicked_obj;
				temp_selected_room.transform.position = new Vector3 (temp_selected_room.transform.position.x + room_movement_speed
					, temp_selected_room.transform.position.y
					, temp_selected_room.transform.position.z); 
			}
		}
	}
		
	//On click down...
	public void Down_arrow_pressed()
	{
		repeatPositionDown = true;
	}
	public void UP_arrow_pressed()
	{
		repeatPositionUp = true;
	}
	public void Right_arrow_pressed()
	{
		repeatPositionRight = true;
	}
	public void Left_arrow_pressed()
	{
		repeatPositionLeft = true;
	}

	//On click up...
	public void Down_arrow_release()
	{
		repeatPositionDown = false;
	}
	public void UP_arrow_release()
	{
		repeatPositionUp = false;
	}
	public void Right_arrow_release()
	{
		repeatPositionRight = false;
	}
	public void Left_arrow_release()
	{
		repeatPositionLeft = false;
	}

	/*public void arrow_clicked(GameObject arw_btn_click)
	{
		temp_selected_room = HUD_ingame.instance.selected_room;
		if (temp_selected_room != null) 
		{
			switch (arw_btn_click.name) 
			{

			case RIGHT_ARROW_BTN:
				temp_selected_room.transform.position = new Vector3 (temp_selected_room.transform.position.x + room_movement_speed
				, temp_selected_room.transform.position.y
				, temp_selected_room.transform.position.z); 
				//temp_selected_room.rigidbody.AddForce(Vector3.forward*5);
				break;
			case LEFT_ARROW_BTN:
				temp_selected_room.transform.position = new Vector3 (temp_selected_room.transform.position.x - room_movement_speed
				, temp_selected_room.transform.position.y
				, temp_selected_room.transform.position.z);
				break;
			case UP_ARROW_BTN:
				temp_selected_room.transform.position = new Vector3 (temp_selected_room.transform.position.x
				, temp_selected_room.transform.position.y
					, temp_selected_room.transform.position.z + room_movement_speed);
				break;
			case DOWN_ARROW_BTN:
				temp_selected_room.transform.position = new Vector3 (temp_selected_room.transform.position.x
				, temp_selected_room.transform.position.y
					, temp_selected_room.transform.position.z - room_movement_speed);
				break;

			}
		}
		else if (HUD_ingame.instance.clicked_obj != null) 
		{
			temp_selected_room = HUD_ingame.instance.clicked_obj;
			switch (arw_btn_click.name) 
			{

			case RIGHT_ARROW_BTN:
				temp_selected_room.transform.position = new Vector3 (temp_selected_room.transform.position.x +item_movement_speed
					, temp_selected_room.transform.position.y
					, temp_selected_room.transform.position.z);
				break;
			case LEFT_ARROW_BTN:
				temp_selected_room.transform.position = new Vector3 (temp_selected_room.transform.position.x - item_movement_speed
					, temp_selected_room.transform.position.y
					, temp_selected_room.transform.position.z);
				break;
			case UP_ARROW_BTN:
				temp_selected_room.transform.position = new Vector3 (temp_selected_room.transform.position.x
					, temp_selected_room.transform.position.y
					, temp_selected_room.transform.position.z + item_movement_speed);
				break;
			case DOWN_ARROW_BTN:
				temp_selected_room.transform.position = new Vector3 (temp_selected_room.transform.position.x
					, temp_selected_room.transform.position.y
					, temp_selected_room.transform.position.z -item_movement_speed);
				break;

			}
		}
	}*/
}
