using UnityEngine;
using System.Collections;

public class Detection : MonoBehaviour {
	//Variables
	public Collider[] targets;
	static public Collider enemyOne;
	public Transform projectiles;
	public float radius = 12;
	public float time = 0;
	public float fireRate;

	void Update () 
	{	
		//seperating layers so not everything is seen by the overlap sphere
		int layerMask = 1 << 8;
		targets = Physics.OverlapSphere (transform.position, radius, layerMask);

		//foreach object in the overlap sphere look at the first One
		foreach (Collider Colls in targets) 
		{
			Vector3 Rpos = targets [0].transform.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation (Rpos);
			transform.rotation = rotation;
			//change name when in range of turret
			Colls.name = "In Range";

			time = time + 1 * Time.deltaTime;

			//Spawning projectiles
			if(time >= fireRate && !enemyOne.isTrigger)
			{
				Instantiate(projectiles, transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z),transform.rotation);
				time =0;
			}
			enemyOne = targets [0]; 
		}



		
	}
	void OnDrawGizmos ()
	{
		Gizmos.DrawWireSphere(transform.position, radius);
		foreach (Collider Colls in targets)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(transform.position, Colls.transform.position);
			Gizmos.color = Color.blue;
			Gizmos.DrawWireSphere(Colls.transform.position, 0.5f);
		}
	}
}
