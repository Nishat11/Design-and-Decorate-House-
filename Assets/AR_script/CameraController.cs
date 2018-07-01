using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public WebCamTexture mCamera = null;
	public GameObject plane;
	public static CameraController instance;

	// Use this for initialization
	void Start ()
	{
		instance = this;
		Debug.Log ("Script has been started");
		plane = GameObject.FindWithTag ("Player");

		mCamera = new WebCamTexture ();
		plane.GetComponent<Renderer>().material.mainTexture = mCamera;
		mCamera.Play ();

	}

	// Update is called once per frame
	void Update ()
	{

	}
}