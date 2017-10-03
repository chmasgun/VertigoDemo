using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{

    private static GameObject armorScreen;
    private static GameObject weaponScreen;
    private GameObject inventoryScreen;

    void Start()
    {
        armorScreen = GameObject.Find("ArmorCreation");
        weaponScreen = GameObject.Find("WeaponCreation");
        inventoryScreen = GameObject.Find("InventoryScreen");
      //  print(armorScreen);
       
        weaponScreen.SetActive(false);
        armorScreen.SetActive(false);
        //print(weaponScreen+" "+armorScreen);

    }
    void Update()
    {

    }
    public static GameObject getArmorScreen() {
        print(armorScreen);
        return armorScreen;
    }
    public static GameObject getWeaponScreen() {
        return weaponScreen;
    }
}
