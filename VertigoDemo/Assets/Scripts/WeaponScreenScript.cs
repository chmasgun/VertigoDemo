using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScreenScript : MonoBehaviour {

    private GameObject armorScreen;
    private GameObject weaponScreen;
    private GameObject inventoryScreen;

    void Start()
    {
        armorScreen = InventoryScript.getArmorScreen();
        weaponScreen = InventoryScript.getWeaponScreen();
        inventoryScreen = GameObject.Find("InventoryScreen");
       // print(armorScreen);
    }

    // Update is called once per frame
    void Update () {
       
        transform.GetChild(0).GetChild(1).GetComponent<Text>().text = transform.GetChild(0).GetChild(0).GetComponent<Slider>().value.ToString();
        transform.GetChild(1).GetChild(1).GetComponent<Text>().text = transform.GetChild(1).GetChild(0).GetComponent<Slider>().value.ToString();
        transform.GetChild(2).GetChild(1).GetComponent<Text>().text = transform.GetChild(2).GetChild(0).GetComponent<Slider>().value.ToString();
        transform.GetChild(3).GetChild(1).GetComponent<Text>().text = (Mathf.Ceil(transform.GetChild(3).GetChild(0).GetComponent<Slider>().value*100)/100).ToString();
        transform.GetChild(4).GetChild(1).GetComponent<Text>().text = transform.GetChild(4).GetChild(0).GetComponent<Slider>().value.ToString();

    }
    public void instantiate() {


        returnToInventory();
    }
    public void goToWeaponScreen()
    {
        InventoryScript.getArmorScreen().SetActive(false);
        InventoryScript.getWeaponScreen().SetActive(true);
        inventoryScreen.SetActive(false);
    }
    public void returnToInventory()
    {
        InventoryScript.getArmorScreen().SetActive(false);
        InventoryScript.getWeaponScreen().SetActive(false);
        inventoryScreen.SetActive(true);
    }
}
