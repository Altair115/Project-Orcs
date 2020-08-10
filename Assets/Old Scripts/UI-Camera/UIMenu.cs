using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
	 				
public class UIMenu : MonoBehaviour 
{

	//Variables
	private bool dragging	= false;
	private Vector3 offset;
	public Transform Turretpos;
	Animator anim;

	public Transform[] Turret;
	public GameObject menu;
	public GameObject Hider1;
	public GameObject Hider2;
	public GameObject[] TurretMenu;
	public int[] prices;

	public int TurretofChoise = 0;
	public int TurretofChoise1 = 1;
	public int TurretofChoise2 = 2;
	public bool MenuOn = false;

	//Upgrade Variables
	public GameObject Usables;
	public GameObject Hider3;
	public GameObject[] Upgrades;
	static public int Cost;
	public int UpgradeOfChoise = 0;
	public int[] UpgradePrices;

	void Awake()
	{
		anim = GetComponent <Animator> ();
	}

	 void Update()
	 {

	 	TouchUp();
	 	if(MenuOn == true)
	 	{
	 		if(TurretofChoise2 >= 0)
			{
				TurretMenu[0].SetActive(true);
				TurretMenu[1].SetActive(false);
				TurretMenu[2].SetActive(false);
			}
			if(TurretofChoise2 >= 3)
			{
				TurretMenu[0].SetActive(false);
				TurretMenu[1].SetActive(true);
				TurretMenu[2].SetActive(false);
			}
			if(TurretofChoise2 >= 6)
			{
				TurretMenu[0].SetActive(false);
				TurretMenu[1].SetActive(false);
				TurretMenu[2].SetActive(true);
			}
	 	}
	 	else
	 	{
	 		TurretMenu[0].SetActive(false);
			TurretMenu[1].SetActive(false);
			TurretMenu[2].SetActive(false);
	 	}
	 	if(TurretofChoise2 >= 6)
	 	{
	 		TurretofChoise = 6;
	 		TurretofChoise1 = 7;
	 		TurretofChoise2 = 8;
	 	}
	 	if(TurretofChoise2 <= 0)
	 	{
	 		TurretofChoise = 0;
	 		TurretofChoise1 = 1;
	 		TurretofChoise2 = 2;
	 	}
	 	
	 }

	 public void TouchUp() 
	 {
		Cost = UpgradePrices[UpgradeOfChoise];
			if (Input.touchCount != 1) 
			{
	 	 		dragging = false;		
		 		return;
		 	}
			Touch touch = Input.touches[0];
		 	Vector3	pos	= touch.position;
		 	//Casting a ray and checking if it hits an object
			 if(touch.phase	== TouchPhase.Began) 
			 {
			 	//checking if finger is on the UI or on the Playing field
			 	if (!EventSystem.current.IsPointerOverGameObject() == false) return;
			 	{
		 			RaycastHit	hit;
		 			Ray	ray	= Camera.main.ScreenPointToRay(pos);	
		 			if(Physics.Raycast(ray, out	hit) && (hit.collider.tag	== "Tower"))
		 			{
		 				//checking if you have hit an object with your finger and printing its name(The object)
		 				//turretpos saves the position of the tower so the turret can spawn on it when button is pressed
		 				Turretpos = hit.transform;
		 				menu.SetActive(true);
						Hider1.SetActive(true);
						Hider2.SetActive(true);
		 				MenuOn = true;
		 				hit.transform.GetComponent<Renderer>().material.color = Color.red;
						dragging = true;
		 			}
					if(Physics.Raycast(ray, out	hit) && (hit.collider.tag	== "Upgrade"))
					{
						//checking if you have hit an object with your finger and printing its name(The object)
						//turretpos saves the position of the tower so the turret can spawn on it when button is pressed
						Turretpos = hit.transform;
						Usables.SetActive(true);
						Hider3.SetActive(true);
						
						//Detecting which upgrade is needed
						foreach (Transform child in Turretpos)
						{
							if(child.name == "Tow_Crossbow1(Clone)")
							{
								UpgradeOfChoise = 0;
							}
							else if(child.name == "Tow_Crossbow2(Clone)")
							{
								UpgradeOfChoise = 1;
							}
							else if(child.name == "Tow_Tesla1(Clone)")
							{
								UpgradeOfChoise = 2;
							}
							else if(child.name == "Tow_Tesla2(Clone)")
							{
								UpgradeOfChoise = 3;
							}
							else if(child.name == "Tow_Acid1(Clone)")
							{
								UpgradeOfChoise = 4;
							}
							else if(child.name == "Tow_Acid2(Clone)")
							{
								UpgradeOfChoise = 5;
							}
							else if(child.name == "Tow_Plasma1(Clone)")
							{
								UpgradeOfChoise = 6;
							}
							else if(child.name == "Tow_Plasma2(Clone)")
							{
								UpgradeOfChoise = 7;
							}
							else if(child.name == "Tow_Fire1(Clone)")
							{
								UpgradeOfChoise = 8;
							}
							else if(child.name == "Tow_Fire2(Clone)")
							{
								UpgradeOfChoise = 9;
							}
							else if(child.name == "Tow_Gatling1(Clone)")
							{
								UpgradeOfChoise = 10;
							}
							else if(child.name == "Tow_Gatling2(Clone)")
							{
								UpgradeOfChoise = 11;
							}
							else if(child.name == "Tow_Laser1(Clone)")
							{
								UpgradeOfChoise = 12;
							}
							else if(child.name == "Tow_Laser2(Clone)")
							{
								UpgradeOfChoise = 13;
							}
							else if(child.name == "Tow_Gauss1(Clone)")
							{
								UpgradeOfChoise = 14;
							}
							else if(child.name == "Tow_Gauss2(Clone)")
							{
								UpgradeOfChoise = 15;
							}
							else if(child.name == "Tow_Crystal1(Clone)")
							{
								UpgradeOfChoise = 16;
							}
							else if(child.name == "Tow_Crystal2(Clone)")
							{
								UpgradeOfChoise = 17;
							}
							else
							{
								anim.SetTrigger("Maxed");
							}
						}	
					
					}
					
		 		}
		 	}
		 if (dragging && (touch.phase == TouchPhase.Ended ||touch.phase	== TouchPhase.Canceled)) 
		 {
		 	Ray	ray = Camera.main.ScreenPointToRay(pos);
		 	RaycastHit hit;
		 	if(Physics.Raycast(ray, out hit) && (hit.collider.tag == "Tower"))
		 	{
		 		hit.transform.GetComponent<Renderer>().material.color = Color.white;
		 	}
	 		dragging = false;
		 }
	}
	//Button 1
	public void TurretBuild1()
	{
		if(Money.money > prices[TurretofChoise] || Money.money == prices[TurretofChoise])
		{
			Transform clone;
			clone = Instantiate(Turret[TurretofChoise], new Vector3(Turretpos.position.x, Turretpos.position.y + 2.7f, Turretpos.position.z),Quaternion.identity)as Transform;
			clone.transform.parent = Turretpos;
			TurretCheck.Builded = true;
			menu.SetActive(false);
			Hider1.SetActive(false);
			Hider2.SetActive(false);
			MenuOn = false;
			Money.money -= prices[TurretofChoise];
		}
		else
		{
			anim.SetTrigger("Warn");
		}
		
	}
	//Button 2
	public void TurretBuild2()
	{
		if (Money.money > prices [TurretofChoise1] || Money.money == prices [TurretofChoise1])
		{
			Transform clone;
			clone = Instantiate (Turret [TurretofChoise1], new Vector3 (Turretpos.position.x, Turretpos.position.y + 2.7f, Turretpos.position.z), Quaternion.identity)as Transform;
			clone.transform.parent = Turretpos;
			menu.SetActive (false);
			Hider1.SetActive(false);
			Hider2.SetActive(false);
			MenuOn = false;
			Money.money -= prices [TurretofChoise1];

		} 
		else 
		{
			anim.SetTrigger("Warn");
		}
		
	}
	//Button 3
	public void TurretBuild3()
	{
		if (Money.money > prices [TurretofChoise2] || Money.money == prices [TurretofChoise2]) 
		{
			Transform clone;
			clone = Instantiate (Turret [TurretofChoise2], new Vector3 (Turretpos.position.x, Turretpos.position.y + 2.7f, Turretpos.position.z), Quaternion.identity)as Transform;
			clone.transform.parent = Turretpos;
			menu.SetActive (false);
			Hider1.SetActive(false);
			Hider2.SetActive(false);
			MenuOn = false;
			Money.money -= prices [TurretofChoise2];

		} 
		else 
		{
			anim.SetTrigger("Warn");
		}
		
	}
	//Canceling Build button
	public void CancelBuild()
	{
		menu.SetActive(false);
		Hider1.SetActive(false);
		Hider2.SetActive(false);
		MenuOn = false;
		TurretMenu[0].SetActive(false);
		TurretMenu[1].SetActive(false);
		TurretMenu[2].SetActive(false);
		Turretpos.transform.GetComponent<Renderer>().material.color = Color.white;
	}
	//Arrow Right button
	public void ArrowRight()
	{
		TurretofChoise += 3;
		TurretofChoise1 += 3;
		TurretofChoise2 += 3;
	}
	//Button Left
	public void ArrowLeft()
	{	
		TurretofChoise -= 3;
		TurretofChoise1 -= 3;
		TurretofChoise2 -= 3;	
	}
	//Demolish Turret
	public void Demolish()
	{
		foreach (Transform child in Turretpos) 
		{
			Destroy (child.gameObject);
		}
		Usables.SetActive(false);
		Hider3.SetActive(false);
	}
	//Upgrade button
	public void Upgrader()
	{
		if(Money.money > UpgradePrices [UpgradeOfChoise] || Money.money == UpgradePrices [UpgradeOfChoise])
		{
			Usables.SetActive(false);
			Hider3.SetActive(false);
			foreach (Transform child in Turretpos) 
			{
				Destroy (child.gameObject);
			}
			GameObject clone;
			clone = Instantiate (Upgrades [UpgradeOfChoise], new Vector3 (Turretpos.position.x, Turretpos.position.y + 2.7f, Turretpos.position.z), Quaternion.identity)as GameObject;
			clone.transform.parent = Turretpos;
			Money.money -= UpgradePrices [UpgradeOfChoise];
		}
	}
	//Cancel Upgrade
	public void CancelUpgrade()
	{
		Usables.SetActive (false);
		Hider3.SetActive (false);
	}
}