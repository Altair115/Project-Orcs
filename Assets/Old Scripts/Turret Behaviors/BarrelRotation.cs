using UnityEngine;
using System.Collections;

public class BarrelRotation : MonoBehaviour {
	public float RotateSpeed = 0;
	public Collider[] Targets;
	public float radius = 10; 	

	void Update () 
	{
		if(RotateSpeed < 0)
		{
			RotateSpeed = 0;
		}

		if(RotateSpeed > 700)
		{
			RotateSpeed = 700;
		}

		int layerMask = 1 << 8;
		//if the overlap sphere find a collider then
		Targets = Physics.OverlapSphere(transform.position, radius , layerMask);
		// this devines if somehing is in the overlapsphere and shows it
		foreach(Collider Colls in Targets)
		{                	
			RotateSpeed = RotateSpeed + 100f * Time.deltaTime;
			transform.Rotate(0,0, 0 + RotateSpeed * Time.deltaTime);
			print(Colls);
		}
		if(Targets != null)
		{
			RotateSpeed = RotateSpeed - 100f * Time.deltaTime;
			transform.Rotate(0,0, 0 + RotateSpeed * Time.deltaTime);
		}
	}
}
