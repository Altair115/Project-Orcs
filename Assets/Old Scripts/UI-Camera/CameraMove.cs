using UnityEngine;
using System.Collections;
 
public class CameraMove : MonoBehaviour {
    
    public float PanSpeed = 0.025F;
    public float PinchSpeed = 0.05F;
	//public bool OutOfMap = false;
 
    void Start () {
    }
 
    // Update is called once per frame, of course.
    void Update () 
    {
		// Check if we have one finger down, and if it's moved.
		// You may modify this first portion to '== 1', to only allow pinching or panning at one time.
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			// Translate along world cordinates. (Done this way so we can angle the camera freely.)
			transform.position -= new Vector3 (touchDeltaPosition.x * PanSpeed, 0, touchDeltaPosition.y * PanSpeed);
		}
 
		// Check if we have two fingers down.
		if (Input.touchCount == 2) {
			Touch touch1 = Input.GetTouch (0);
			Touch touch2 = Input.GetTouch (1);
            
			// Find out how the touches have moved relative to eachother.
			Vector2 curDist = touch1.position - touch2.position;
			Vector2 prevDist = (touch1.position - touch1.deltaPosition) - (touch2.position - touch2.deltaPosition);
            
			float touchDelta = curDist.magnitude - prevDist.magnitude;
			// Translate along local coordinate space.
			Camera.main.transform.Translate (0, 0, touchDelta * PinchSpeed);   
		}
		
		if (transform.position.x <= 20) {
			transform.position = new Vector3 (transform.position.x + 0.1f, transform.position.y + 0.0f, transform.position.z + 0.0f);
			//OutOfMap = true;
		} 

		if (transform.position.x >= 55) 
		{
			transform.position = new Vector3 (transform.position.x - 0.1f, transform.position.y - 0.0f, transform.position.z - 0.0f);
			//OutOfMap = true;
		}

		if (transform.position.z <= 2.0f) 
		{
			transform.position = new Vector3 (transform.position.x + 0.0f, transform.position.y + 0.0f, transform.position.z + 0.1f);
			//OutOfMap = true;
		}

		if (transform.position.z >= 51) 
		{
			transform.position = new Vector3 (transform.position.x + 0.0f, transform.position.y + 0.0f, transform.position.z - 0.1f);
			//OutOfMap = true;
		}

		if (transform.position.y <= 10)
		{
			transform.position = new Vector3 (transform.position.x + 0.0f, transform.position.y + 0.1f, transform.position.z + 0.0f);
			//OutOfMap = true;
		}

		if (transform.position.y >= 23) 
		{
			transform.position = new Vector3 (transform.position.x + 0.0f, transform.position.y - 0.1f, transform.position.z + 0.0f);
			//OutOfMap = true;
		}

    }
}
