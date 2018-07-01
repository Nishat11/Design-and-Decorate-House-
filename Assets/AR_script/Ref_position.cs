using UnityEngine;
using System.Collections;

public class Ref_position : MonoBehaviour {
	public static bool old_object;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) 
	{
		old_object = true;
		Debug.Log ("value should true...."+old_object);
	}
	void OnTriggerExit(Collider other) 
	{
		old_object = false;
		Debug.Log ("value is"+old_object);
	}
}
