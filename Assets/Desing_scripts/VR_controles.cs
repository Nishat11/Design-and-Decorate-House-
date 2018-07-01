/*
 * Developed by Nishat A. Bhagat
 * Date //01/10/2017
 * VR_controles.cs
 * Manage VR mode...
*/
using UnityEngine;
using System.Collections;

public class VR_controles : MonoBehaviour {

	public float Speed;
	public GameObject head;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//float y_rotation = head.transform.rotation.euler;
		//this.transform.Translate (Vector3.forward*Speed);

		RaycastHit hit;
		Vector3 fwd = head.transform.TransformDirection (Vector3.forward);
		Debug.DrawRay (new Vector3(head.transform.position.x,-6f,head.transform.position.z), fwd , Color.red);
		//Ray ray = (Physics.Raycast(head.transform.position,fwd, out hit, 50));
		if (Physics.Raycast (head.transform.position, fwd, out hit, 1)) {
			Debug.Log ("values is" + hit.collider.name);
//			if (hit.collider)
//				Speed = 0f;
			if (hit.collider.tag == "OpenWall" || hit.collider.tag == "CloseWall")
				Speed = 1.5f;
			else
				Speed = 0f;
		} else
			Speed = 1.5f;
		//Ray ray = Camera.main.ViewportPointToRay()
		//if(hit.collider.tag != "Room_Floor")

		this.transform.position = new Vector3 (transform.position.x+ head.transform.forward.x * Speed * Time.deltaTime, this.transform.position.y,
			this.transform.position.z + head.transform.forward.z * Speed * Time.deltaTime);
			
	}


}
