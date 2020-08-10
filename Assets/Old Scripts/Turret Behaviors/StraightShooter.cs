using UnityEngine;
using System.Collections;

public class StraightShooter : MonoBehaviour {

	public float speed = 25;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z);	
	}
	
	// Update is called once per frame
	void Update () {
		//float step = speed * Time.deltaTime;
		//transform.position = Vector3.MoveTowards(transform.position,  Detection.EnemyOne.transform.position, step);
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
		Destroy (gameObject, 4);
	}
}
