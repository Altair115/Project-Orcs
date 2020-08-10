using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Money : MonoBehaviour {

	public static int money; //Player money
	Text text; //reference to UI text

	void Awake () 
	{
		//Set up reference
		text = GetComponent <Text> ();

		//reset Score
		//money = 1500;
		//money = 5000;
		money = 15000;
	}
	
	void Update () {
		//display UI and update it
		text.text = "Money = $" + money;
	}
}
