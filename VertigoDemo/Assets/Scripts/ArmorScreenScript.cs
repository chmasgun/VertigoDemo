using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorScreenScript : MonoBehaviour
{

    
    private GameObject armorScreen;
    private GameObject weaponScreen;
    private GameObject inventoryScreen;

    void Start()
    {
        armorScreen = InventoryScript.getArmorScreen();
        weaponScreen = InventoryScript.getWeaponScreen();
        inventoryScreen = GameObject.Find("InventoryScreen");
    }
    
    void Update()
    {

    }

    public void goToArmorScreen()
    {
        InventoryScript.getArmorScreen().SetActive(true);
        InventoryScript.getWeaponScreen().SetActive(false);
        inventoryScreen.SetActive(false);
    }
    public void returnToInventory()
    {
        InventoryScript.getArmorScreen().SetActive(false);
        InventoryScript.getWeaponScreen().SetActive(false);
        inventoryScreen.SetActive(true);
    }
}
