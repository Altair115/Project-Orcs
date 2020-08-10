using UnityEngine;
using System.Collections;

public class TurretCheck : MonoBehaviour {

	static public bool Builded = false;

	// Update is called once per frame, Yup
	void Update () {
		if (transform.childCount >= 1) 
		{
			gameObject.tag = "Upgrade";
		}
		if (transform.childCount <= 0) 
		{
			gameObject.tag = "Tower";
		}
	}

}
