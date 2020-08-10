using UnityEngine;
using System.Collections;

public class MagicBullet : MonoBehaviour {

	public Collider[] Targets;
	public bool LookAt = false;
	public float Radius = 12;
	public float speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//seperating layers so not everything is seen
		int layerMask = 1 << 8;
		Targets = Physics.OverlapSphere (transform.position, Radius, layerMask);
		//foreach target move towards the fist in Targets
		foreach (Collider Colls in Targets) 
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position,  Targets[0].transform.position, step);
			//change the name when firing at spotted target
			Colls.name = "Firing";

			//Note: Not Every Projectile needs this
			if(LookAt == true)
			{
				Vector3 Rpos = Targets [0].transform.position - transform.position;
				Quaternion rotation = Quaternion.LookRotation (Rpos);
				transform.rotation = rotation;
			}
		}
	
	}
	//For Convinience Draw sphere for range and lines at what it is aiming
	void OnDrawGizmos ()
	{
		Gizmos.DrawWireSphere(transform.position, Radius);
		foreach (Collider Colls in Targets)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(transform.position, Colls.transform.position);
		}
	}
}
