using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;


//Building turrets on towers And upgrading them
public class TurretBuilder : MonoBehaviour {

    //Variables
    private Vector3 offset;
    public Animator anim;
    public Transform turretpos;                     // Position of currectly selected tower
    public Turret[] turrets;                        // Special made class array that contains all upgrades for the turrets & the turret itself
    public BuildingButton[] buildableTurrets;       // Special class for button management

    void Awake()
    {
        buildableTurrets[0].turretBuild.onClick.AddListener(() => BuildTurret(0));
        buildableTurrets[1].turretBuild.onClick.AddListener(() => BuildTurret(1));
        buildableTurrets[2].turretBuild.onClick.AddListener(() => BuildTurret(2));
        //buildableTurrets[3].turretBuild.onClick.AddListener(() => BuildTurret(3));

        buildableTurrets[0].turretPrice.text = "$" + turrets[0].price.ToString();
        buildableTurrets[1].turretPrice.text = "$" + turrets[1].price.ToString();
        buildableTurrets[2].turretPrice.text = "$" + turrets[2].price.ToString();
        //buildableTurrets[3].turretPrice.text = turrets[3].price.ToString();
    }

    void Update()
    {
        //Cost = UpgradePrices[UpgradeOfChoise]

        if (Input.GetButtonDown("Fire1"))
        { 
            //Casting a ray and checking if it hits an a tower
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Tower"))
            {
                //checking if you have hit an object with your finger and printing its name(The object)
                //turretpos saves the position of the tower so the turret can spawn on it when button is pressed
                turretpos = hit.transform;
                hit.transform.GetComponent<Renderer>().material.color = Color.red;
            }
            if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Upgrade"))
            {
                //checking if you have hit an object with your finger and printing its name(The object)
                //turretpos saves the position of the tower so the turret can spawn on it when button is pressed
                turretpos = hit.transform;               
            }
        }
        if (Input.GetButtonUp("Fire1"))    
          turretpos.GetComponent<Renderer>().material.color = Color.white;
    }


    void BuildTurret(int i)
    {
        if(ScoreManager.money > turrets[i].price || ScoreManager.money == turrets[i].price)
        {
            Transform clone;
            clone = Instantiate(turrets[i].turret, new Vector3(turretpos.position.x, turretpos.position.y + 2.7f, turretpos.position.z), Quaternion.identity) as Transform;
            clone.transform.parent = turretpos;
        }

    }




    public void TurretOnTower()
    {
        /*foreach (Transform child in turretpos)
        {
            if (child.name == "Tow_Crossbow1(Clone)")
            {

            }
        }*/
    }

    public void TurretBuild1()
    {
        /*if (/*Money.money > prices[TurretofChoise] || Money.money == prices[TurretofChoise])
        {
           */
        Transform clone;
            
        clone = Instantiate(turrets[0].turret, new Vector3(turretpos.position.x, turretpos.position.y + 2.7f, turretpos.position.z), Quaternion.identity) as Transform;
        clone.transform.parent = turretpos;
        //TurretCheck.Builded = true; 

        /*    //Money.money -= prices[TurretofChoise];
        }*/
        /*else
        {
            anim.SetTrigger("Warn");
        }*/

    }

    //The construct for a turret containing the damage, price and the model
    [System.Serializable]
    public class Turret
    {
        public Transform turret;
        public GameObject[] upgrades;
        public int price;
        public int upgradePrice;
    }

    [System.Serializable]
    public class BuildingButton
    {
        public Button turretBuild;
        public Text turretPrice;
    }
}

    /*
    //Variables
    public GameObject menu;
    public GameObject Hider1;
    public GameObject Hider2;
    public GameObject[] TurretMenu;

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
    
    //Button 1
    public void TurretBuild1()
    {
        if (Money.money > prices[TurretofChoise] || Money.money == prices[TurretofChoise])
        {
            Transform clone;
            clone = Instantiate(Turret[TurretofChoise], new Vector3(Turretpos.position.x, Turretpos.position.y + 2.7f, Turretpos.position.z), Quaternion.identity) as Transform;
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
        if (Money.money > prices[TurretofChoise1] || Money.money == prices[TurretofChoise1])
        {
            Transform clone;
            clone = Instantiate(Turret[TurretofChoise1], new Vector3(Turretpos.position.x, Turretpos.position.y + 2.7f, Turretpos.position.z), Quaternion.identity) as Transform;
            clone.transform.parent = Turretpos;
            menu.SetActive(false);
            Hider1.SetActive(false);
            Hider2.SetActive(false);
            MenuOn = false;
            Money.money -= prices[TurretofChoise1];

        }
        else
        {
            anim.SetTrigger("Warn");
        }

    }
    //Button 3
    public void TurretBuild3()
    {
        if (Money.money > prices[TurretofChoise2] || Money.money == prices[TurretofChoise2])
        {
            Transform clone;
            clone = Instantiate(Turret[TurretofChoise2], new Vector3(Turretpos.position.x, Turretpos.position.y + 2.7f, Turretpos.position.z), Quaternion.identity) as Transform;
            clone.transform.parent = Turretpos;
            menu.SetActive(false);
            Hider1.SetActive(false);
            Hider2.SetActive(false);
            MenuOn = false;
            Money.money -= prices[TurretofChoise2];

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
            Destroy(child.gameObject);
        }
        Usables.SetActive(false);
        Hider3.SetActive(false);
    }
    //Upgrade button
    public void Upgrader()
    {
        if (Money.money > UpgradePrices[UpgradeOfChoise] || Money.money == UpgradePrices[UpgradeOfChoise])
        {
            Usables.SetActive(false);
            Hider3.SetActive(false);
            foreach (Transform child in Turretpos)
            {
                Destroy(child.gameObject);
            }
            GameObject clone;
            clone = Instantiate(Upgrades[UpgradeOfChoise], new Vector3(Turretpos.position.x, Turretpos.position.y + 2.7f, Turretpos.position.z), Quaternion.identity) as GameObject;
            clone.transform.parent = Turretpos;
            Money.money -= UpgradePrices[UpgradeOfChoise];
        }
    }
    //Cancel Upgrade
    public void CancelUpgrade()
    {
        Usables.SetActive(false);
        Hider3.SetActive(false);
    }
    */