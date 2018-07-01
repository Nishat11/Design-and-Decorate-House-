/*
 * Developed by Nishat A. Bhagat
 * Date //01/15/2017
 * WallScripts.cs
 * manage color postion and collision of walls...
*/
using UnityEngine;
using System.Collections;

public class WallScripts : MonoBehaviour {

	public bool wall_connected;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "OpenWall") 
		{
			this.gameObject.tag = "CloseWall";
			other.gameObject.tag = "CloseWall";
			Debug.Log ("collide enter");
		}
		else if(other.gameObject.tag == "Doorwall")
		{
			//this.gameObject.GetComponent<MeshRenderer> ().enabled = false;
		}
	}
	void OnTriggerExit(Collider other) 
	{
		if (other.gameObject.tag == "CloseWall") 
		{
			this.gameObject.tag = "OpenWall";
			other.gameObject.tag = "OpenWall";
			Debug.Log ("collide exit");
		}
		else if(other.gameObject.tag == "Doorwall")
		{
			//this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
		}
	}
}
