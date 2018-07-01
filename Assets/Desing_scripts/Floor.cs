/*
 * Developed by Nishat A. Bhagat
 * Date //01/10/2017
 * Floor.cs
 * Customize floor color...
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Floor : MonoBehaviour {


	public List<GameObject> buttons = new List<GameObject>();
	public List<Sprite> Wall_texture = new List<Sprite>();
	public List<Sprite> Floor_texture = new List<Sprite>();

	private const string OPTION_1_BTN = "Shade_1";
	private const string OPTION_2_BTN = "Shade_2";
	private const string OPTION_3_BTN = "Shade_3";
	public GameObject main_obj;

	// Use this for initialization
	void Start () {
	
	}
	void OnEnable()
	{
		main_obj = HUD_ingame.instance.clicked_obj;
			if (main_obj)
			if (main_obj.tag == "Room_Floor") {
			for (int i = 0; i < 3; i++) {
				buttons [i].GetComponent<Image> ().sprite = Floor_texture [i];
			}
		}
			else if(main_obj.tag == "OpenWall" || main_obj.tag == "CloseWall")
		{
			for (int i = 0; i < 3; i++) {
				buttons [i].GetComponent<Image> ().sprite = Wall_texture [i];
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

	public void selectOption(GameObject clicked)
	{
		switch(clicked.name)
		{
		case OPTION_1_BTN:
					if (main_obj.tag == "OpenWall" || main_obj.tag == "CloseWall") {
				for (int i = 0; i < 3; i++) {
							main_obj.transform.GetChild(i).GetComponent<Renderer> ().material.mainTexture 
					= buttons [0].GetComponent<Image> ().mainTexture;
					if(i==1)
								main_obj.transform.GetChild(i).GetChild(0).GetComponent<Renderer> ().material.mainTexture 
						= buttons [0].GetComponent<Image> ().mainTexture;
				}
			}

					main_obj.GetComponent<Renderer> ().material.mainTexture = buttons [0].GetComponent<Image> ().mainTexture;
			break;
		case OPTION_2_BTN:
					if (main_obj.tag == "OpenWall" || main_obj.tag == "CloseWall") {
				for (int i = 0; i < 3; i++) {
							main_obj.transform.GetChild(i).GetComponent<Renderer> ().material.mainTexture 
					= buttons [1].GetComponent<Image> ().mainTexture;
					if(i==1)
								main_obj.transform.GetChild(i).GetChild(0).GetComponent<Renderer> ().material.mainTexture 
						= buttons [1].GetComponent<Image> ().mainTexture;
				}
			}

					main_obj.GetComponent<Renderer> ().material.mainTexture = buttons [1].GetComponent<Image> ().mainTexture;
			break;
		case OPTION_3_BTN:
			if (main_obj.tag == "OpenWall" || main_obj.tag == "CloseWall") {
				for (int i = 0; i < 3; i++) {
					main_obj.transform.GetChild(i).GetComponent<Renderer> ().material.mainTexture 
					= buttons [2].GetComponent<Image> ().mainTexture;
					if(i==1)
						main_obj.transform.GetChild(i).GetChild(0).GetComponent<Renderer> ().material.mainTexture 
						= buttons [2].GetComponent<Image> ().mainTexture;
				}
			}

			main_obj.GetComponent<Renderer> ().material.mainTexture = buttons [2].GetComponent<Image> ().mainTexture;
			break;
		}
	}

	void OnTriggerEnter(Collider other) 
	{
//		if(other.gameObject.tag != "Mainroom")
//			other.gameObject.transform.parent = this.gameObject.transform.parent;
	}
	void OnTriggerExit(Collider other)
	{
//		if(other.gameObject.tag != "Mainroom")
//			other.gameObject.transform.parent = null;
	}
}
