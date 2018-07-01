/*
 * Developed by Nishat A. Bhagat
 * Date //01/15/2017
 * AR_Controller.cs
 * Control all AR buttons....
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class AR_Controller : MonoBehaviour {

	private const string HOME_BTN = "Home";
	private const string DECORATE_HOUSE_BTN = "Decorate_house";
	private const string COUNTINUE_DESIGN_BTN = "Coutinue Design";
	private const string BEDROOM_ITM_BTN = "Bed_room";
	private const string LIVINGROOM_ITM_BTN = "Living_room";
	private const string BATHROOM_ITM_BTN = "Bathroom";
	private const string GARDEN_ITM_BTN = "Garden";

	private const string MOVE_UP_BTN = "Up_arrow";
	private const string MOVE_DOWN_BTN = "Down_arrow";
	private const string MOVE_RIGHT_BTN = "Right_arrow";
	private const string MOVE_LEFT_BTN = "Left_arrow";

	public GameObject Bed_room,Living_room,Bathroom,Garden;
	public GameObject main_item;
	public static AR_Controller instance;

	public GameObject[] don;
	public Bedroom_items[] bed_room_itms;
	public Livingroom_items[] living_room_itms;
	public Garden_items[] garden_itms;
	public Other_items [] other_itms;
	public List<GameObject> bedrm_bed = new List<GameObject>();

	public GameObject AR_Active_panel;

	//public List<GameObject> demo = new List<GameObject> ();
	public float scalingSpeed = 0.03f;
	public float rotationSpeed = 70.0f;
	public float translationSpeed = 5.0f;
	//	public GameObject Model;
	bool repeatScaleUp = false;
	bool repeatScaleDown = false;
	bool repeatRotateLeft = false;
	bool repeatRotateRight = false;
	bool repeatPositionUp = false;
	bool repeatPositionDown = false;
	bool repeatPositionLeft = false;
	bool repeatPositionRight = false;

	//float speed = 100.0f; //how fast it shakes
	//float amount = 5f; //how much it shakes
	public float inc_value = 0.5f;


	// Use this for initialization
	void Start () {
		instance = this;
	}


	void swipe_zoom()
	{
		// If there are two touches on the device...
		if (Input.touchCount == 2)
		{
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = (prevTouchDeltaMag - touchDeltaMag)*inc_value;

			main_item.transform.localScale = main_item.transform.localScale + new Vector3 (deltaMagnitudeDiff,deltaMagnitudeDiff,deltaMagnitudeDiff);
			//maincamera.fieldOfView += deltaMagnitudeDiff * inc_value;

			// Clamp the field of view to make sure it's between 0 and 180.
			//main_item.fieldOfView = Mathf.Clamp(maincamera.fieldOfView, 5f,80f);
		}
	}


	// Update is called once per frame
	void Update () {
	
		swipe_zoom ();
		if (repeatScaleUp) {
			ScaleUpButton ();
		}

		if (repeatScaleDown) {
			ScaleDownButton ();
		}

		if (repeatRotateRight) {
			RotationRightButton();
		}

		if (repeatRotateLeft) {
			RotationLeftButton();
		}

		if (repeatPositionUp) {
			PositionUpButton();
		}

		if (repeatPositionDown) {
			PositionDownButton();
		}

		if (repeatPositionLeft) {
			PositionLeftButton();
		}

		if (repeatPositionRight) {
			PositionRightButton();
		}

		//main_item.transform.position = new Vector3 (Mathf.Sin(Time.time * speed),Mathf.Sin(Time.time* speed),main_item.transform.position.z);
		//if(main_item)
			
				//Mathf.Sin(Time.time * speed);
			//HidePanelIfClickOutSide ();
	}

	public void HidePanelIfClickOutSide()
	{
		if (Input.GetMouseButton (0) && AR_Active_panel.activeSelf && RectTransformUtility.RectangleContainsScreenPoint (
			    AR_Active_panel.GetComponent<RectTransform> (), Input.mousePosition, Camera.main)) {
			AR_Active_panel.SetActive (false);
		} else {
			
		}
	}
	public void RotationRightButton ()
	{
		// transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);
		//main_item.transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);
		main_item.transform.eulerAngles = new Vector3 (main_item.transform.eulerAngles.x,main_item.transform.eulerAngles.y-rotationSpeed * Time.deltaTime,main_item.transform.eulerAngles.z);
	}

	public void RotationLeftButton ()
	{
		// transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
		//main_item.transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
		main_item.transform.eulerAngles = new Vector3 (main_item.transform.eulerAngles.x,main_item.transform.eulerAngles.y+rotationSpeed * Time.deltaTime,main_item.transform.eulerAngles.z);
	}

	public void RotationRightButtonRepeat ()
	{
		// transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);
		repeatRotateRight=true;
	}

	public void RotationLeftButtonRepeat ()
	{
		// transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
		repeatRotateLeft=true;
	}

	public void ScaleUpButton ()
	{
		// transform.localScale += new Vector3(scalingSpeed, scalingSpeed, scalingSpeed);
		main_item.transform.localScale += new Vector3 (scalingSpeed, scalingSpeed, scalingSpeed);
	}

	public void ScaleUpButtonRepeat ()
	{
		repeatScaleUp = true;
		Debug.Log ("Up");
	}
	public void ScaleDownButtonRepeat ()
	{
		repeatScaleDown = true;
		Debug.Log ("Down");
	}
	public void PositionDownButtonRepeat ()
	{
		repeatPositionDown = true;
	}
	public void PositionUpButtonRepeat ()
	{
		repeatPositionUp = true;
	}
	public void PositionLeftButtonRepeat ()
	{
		repeatPositionLeft = true;
	}
	public void PositionRightButtonRepeat ()
	{
		repeatPositionRight = true;
	}

	public void ScaleUpButtonOff ()
	{
		repeatScaleUp = false;
		//Debug.Log ("Off");
	}
	public void ScaleDownButtonOff ()
	{
		repeatScaleDown = false;
		//Debug.Log ("Off");
	}

	public void RotateLeftButtonOff ()
	{
		repeatRotateLeft = false;
		//Debug.Log ("Off");
	}

	public void RotateRightButtonOff ()
	{
		repeatRotateRight = false;
		//Debug.Log ("Off");
	}
	public void PositionRightButtonOff ()
	{
		repeatPositionRight = false;
		//Debug.Log ("Off");
	}
	public void PositionLeftButtonOff ()
	{
		repeatPositionLeft = false;
		//Debug.Log ("Off");
	}
	public void PositionUpButtonOff ()
	{
		repeatPositionUp = false;
		//Debug.Log ("Off");
	}
	public void PositionDownButtonOff ()
	{
		repeatPositionDown = false;
		//Debug.Log ("Off");
	}

	public void ScaleDownButton ()
	{
		// transform.localScale += new Vector3(-scalingSpeed, -scalingSpeed, -scalingSpeed);
		main_item.transform.localScale += new Vector3 (-scalingSpeed, -scalingSpeed, -scalingSpeed);
	}

	public void PositionUpButton ()
	{
		//main_item.transform.Translate (0, 0, -translationSpeed * Time.deltaTime);
		main_item.transform.localPosition = new Vector3 (main_item.transform.localPosition.x-translationSpeed * Time.deltaTime,main_item.transform.localPosition.y,main_item.transform.localPosition.z);
	}

	public void PositionDownButton ()
	{
		main_item.transform.localPosition = new Vector3 (main_item.transform.localPosition.x+translationSpeed * Time.deltaTime,main_item.transform.localPosition.y,main_item.transform.localPosition.z);
		//main_item.transform.Translate (0, 0, translationSpeed * Time.deltaTime);
	}

	public void PositionRightButton ()
	{
		//main_item.transform.Translate (0, translationSpeed * Time.deltaTime, 0);
		main_item.transform.localPosition = new Vector3 (main_item.transform.localPosition.x,main_item.transform.localPosition.y+translationSpeed * Time.deltaTime,main_item.transform.localPosition.z);
	}

	public void PositionLeftButton ()
	{
		//main_item.transform.Translate (0,-translationSpeed * Time.deltaTime, 0);  // backward
		main_item.transform.localPosition = new Vector3 (main_item.transform.localPosition.x,main_item.transform.localPosition.y-translationSpeed * Time.deltaTime,main_item.transform.localPosition.z);
	}

	public void Hide_panel()
	{
		Bed_room.gameObject.transform.GetChild (1).gameObject.SetActive (false);
		Living_room.gameObject.transform.GetChild (1).gameObject.SetActive (false);
		Bathroom.gameObject.transform.GetChild (1).gameObject.SetActive (false);
		Garden.gameObject.transform.GetChild (1).gameObject.SetActive (false);
	}

//	public void control_btn_click(GameObject contrl_click)
//	{
//		switch(contrl_click.name)
//		{
//		case MOVE_UP_BTN:
//			Debug.Log ("button clicked....");
//			//main_item.gameObject.transform.position = new Vector3 (0f,0f,0.05f*Time.deltaTime);
//			break;
//		case MOVE_DOWN_BTN:
//			break;
//		case MOVE_LEFT_BTN:
//			break;
//		case MOVE_RIGHT_BTN:
//			break;
//		}
//	}

	public void AR_btn_click(GameObject ar_click)
	{
		switch(ar_click.name)
		{

		case HOME_BTN:
			//CameraController.instance.mCamera.Stop ();
			//if (!CameraController.instance.mCamera.isPlaying) {
				Application.LoadLevel (0);
				//Application.UnloadLevel (1);
			//}
				
			break;
		case BEDROOM_ITM_BTN:
			Hide_panel ();
			Bed_room.gameObject.transform.GetChild (1).gameObject.SetActive (true);
			AR_Active_panel = Bed_room.gameObject.transform.GetChild (1).gameObject;
			break;
		case LIVINGROOM_ITM_BTN:
			Hide_panel ();
			Living_room.gameObject.transform.GetChild (1).gameObject.SetActive (true);
			AR_Active_panel = Living_room.gameObject.transform.GetChild (1).gameObject;
			break;
		case BATHROOM_ITM_BTN:
			Hide_panel ();
			Bathroom.gameObject.transform.GetChild (1).gameObject.SetActive (true);
			AR_Active_panel = Bathroom.gameObject.transform.GetChild (1).gameObject;
			break;
		case GARDEN_ITM_BTN:
			Hide_panel();
			Garden.gameObject.transform.GetChild (1).gameObject.SetActive (true);
			AR_Active_panel = Garden.gameObject.transform.GetChild (1).gameObject;
			break;
		}
	}
}
[System.Serializable]
public class Bedroom_items
{
	public GameObject[] intArray;
}

[System.Serializable]
public class Livingroom_items
{
	public GameObject[] intArray;
}

[System.Serializable]
public class Garden_items
{
	public GameObject[] intArray;
}

[System.Serializable]
public class Other_items
{
	public GameObject[] intArray;
}