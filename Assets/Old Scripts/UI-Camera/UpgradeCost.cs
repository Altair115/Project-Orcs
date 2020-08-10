using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeCost : MonoBehaviour {

	//Variables
	Text text;

	// Use this for initialization
	void Awake () 
	{
		text = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = "Upgrade Cost: $" + UIMenu.Cost;
	}
}
