/*
 * Developed by Nishat A. Bhagat
 * Date //01/10/2017
 * Clickable_obj.cs
 * make interier items clickable and track click event...
*/
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Clickable_obj : MonoBehaviour {

	public static string objectname = "";
	public static Clickable_obj instance;
	// Use this for initialization
	void Start () {
		instance = this;
	}

	// Update is called once per frame
	void Update () {
//		if (Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject ()) {
//			HUD_ingame.instance.clicked_obj = null;
//		}
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
		{
			if (!EventSystem.current.IsPointerOverGameObject (Input.GetTouch (0).fingerId))
				HUD_ingame.instance.clicked_obj = null;
		}
		//Debug.Log ("name of object is"+clicked_obj.name);
	}
	public void OnMouseUp()
	{
		if (!EventSystem.current.IsPointerOverGameObject () && HUD_ingame.instance.Playmode != "Play_VR" 
			&& HUD_ingame.instance.Playmode != "Play") 
		{
			HUD_ingame.instance.clicked_obj = gameObject;

			//if (gameObject != null)
				//HUD_ingame.instance.Control_button.SetActive (true);
			//Debug.Log ("name is  " + gameObject.name);
		}
	}
	public void OnMouseDown()
	{
		
	}
}
