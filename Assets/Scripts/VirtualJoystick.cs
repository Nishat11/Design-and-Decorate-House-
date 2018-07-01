/*
 * Developed by Nishat A. Bhagat
 * Date //01/10/2017
 * VirtualJoystick.cs
 * Controll joysticks input and outputs...
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
	public Camera object_camera;
	private Image bgImg;
	private Image joyStickImg;
	private Vector3 inputVector;

	public int cam_rotate_speed;
	private float temp_x, temp_y,diff_x,diff_y;

	private void Start()
	{
		bgImg = GetComponent<Image>();
		joyStickImg = transform.GetChild (0).GetComponent<Image> ();
	}

	public void Update()
	{
		
	}

	//Track on drack event of joystick....
	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) 
		{
			//Debug.Log ("itworks,,,"+pos.x+"and y is.."+pos.y);
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

			inputVector = new Vector3 (pos.x*2 +1,0,pos.y*2-1);
			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
			joyStickImg.rectTransform.anchoredPosition = new Vector3 (inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3)
														, inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3));
			//Debug.Log (inputVector+"-----"+object_camera.transform.localRotation.eulerAngles.x);
			//if(object_camera.transform.localRotation.eulerAngles.x>340 && object_camera.transform.localRotation.eulerAngles.x < 70 )
			object_camera.transform.eulerAngles = new Vector3 (object_camera.transform.localRotation.eulerAngles.x+(cam_rotate_speed* diff_y)
				,object_camera.transform.localRotation.eulerAngles.y+(cam_rotate_speed* -diff_x),0f);	
			diff_x = temp_x - inputVector.x;
			temp_x = inputVector.x;
			//Debug.Log ("diffreent is"+diff_x*100);

			diff_y = temp_y - inputVector.z;
			temp_y = inputVector.z;

		}
	}

	//Default function on drag up and down...
	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);
		temp_x = inputVector.x;
		temp_y = inputVector.z;
	}
	public virtual void OnPointerUp (PointerEventData ped)
	{
		inputVector = Vector3.zero;
		joyStickImg.rectTransform.anchoredPosition = Vector3.zero;
		temp_x = 0f;
		temp_y = 0f;
		diff_x = 0;diff_y = 0;
	}

//	public float Horizontal()
//	{
//		if (inputVector.x != 0)
//			return inputVector.x;
//		else
//			return Input.GetAxis ("Horizontal");
//	}
//	public float Verical()
//	{
//		if (inputVector.z != 0)
//			return inputVector.z;
//		else
//			return Input.GetAxis ("Verticle");
//	}

}
