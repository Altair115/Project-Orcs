using UnityEngine;
using System.Collections;

public class WavesUpdated : MonoBehaviour {

    //Variables
    public Transform spawn;
	public Transform[] waves;

	public int loop;
	public int wavenumber = 0;
	public float spawnWait;
	public float startWait;
	public float waveWait;



	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());	
	}
	

	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds(startWait);
		while(true)
		{
			//How many enemy will spawn
			for (int i = 0; i < loop; i++) 
			{
				//which enemy will be spawned
				Instantiate (waves [wavenumber], spawn.position, spawn.rotation);
				yield return new WaitForSeconds(spawnWait);
			}
			//how much time has to pas before starting a new wave
			yield return new WaitForSeconds (waveWait);
			wavenumber ++;
			WaveDisplay.Wave ++;
			loop += 5;
		}
	
	}
}
