using UnityEngine;
using System.Collections;

public class CamPCMAC : MonoBehaviour {

	public float speed = 20;

	// Update is called once per frame
	void Update () {
		if(Input.GetKey("w"))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
		}
		if(Input.GetKey("s"))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
		}
		if(Input.GetKey("a"))
		{
			transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
		}
		if(Input.GetKey("d"))
		{
			transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
		}
	
	}
}
