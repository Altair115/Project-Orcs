using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour {

	Text text; //reference to UI text
	public static int Wave = 1;

	// Use this for initialization
	void Awake () 
	{

		//Set up reference
		text = GetComponent <Text> ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//display UI and update it
		text.text = "Wave: " + Wave;
	
	}
}
