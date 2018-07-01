/*
 * Developed by Nishat A. Bhagat
 * Date //01/10/2017
 * HUD_ingame.cs
 * Controll and manage lights in scene...
*/

using UnityEngine;
using System.Collections;

public class Adjust_light : MonoBehaviour {

	public const string MORNING_BTN = "Morning";
	public const string AFTERNOON_BTN = "Afternoon";
	public const string EVENING_BTN = "Evening";
	public const string NIGHT_BTN = "Night";
	public GameObject[] Lights;
	public static Adjust_light instance;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Hamgle light buttons click event....
	public void light_btn_clicked(GameObject light_btn)
	{
		switch(light_btn.name)
		{
		case MORNING_BTN:
			HUD_ingame.instance.direction_light.intensity = 1f;
			HUD_ingame.instance.adj_light_panel.SetActive (false);
			HUD_ingame.instance.Light_on = false;
			Lights = GameObject.FindGameObjectsWithTag ("Light");
			foreach (GameObject light in Lights) {
				light.GetComponent<Light> ().enabled = false;
			}
			break;
		case AFTERNOON_BTN:
			HUD_ingame.instance.direction_light.intensity = 1.5f;
			HUD_ingame.instance.adj_light_panel.SetActive (false);
			HUD_ingame.instance.Light_on = false;
			Lights = GameObject.FindGameObjectsWithTag ("Light");
			foreach (GameObject light in Lights) {
				light.GetComponent<Light> ().enabled = false;
			}
			break;
		case EVENING_BTN:
			HUD_ingame.instance.direction_light.intensity = 0.5f;
			HUD_ingame.instance.adj_light_panel.SetActive (false);
			HUD_ingame.instance.Light_on = false;
			Lights = GameObject.FindGameObjectsWithTag ("Light");
			foreach (GameObject light in Lights) {
				light.GetComponent<Light> ().enabled = false;
			}
			break;
		case NIGHT_BTN:
			HUD_ingame.instance.direction_light.intensity = 0f;
			HUD_ingame.instance.adj_light_panel.SetActive (false);
			HUD_ingame.instance.Light_on = true;
			Lights = GameObject.FindGameObjectsWithTag ("Light");
			foreach (GameObject light in Lights) {
				light.GetComponent<Light> ().enabled = true;
			}
			break;
		}
	}
}
