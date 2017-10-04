using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorScreenScript : MonoBehaviour
{

    private GameObject armorScreen, weaponScreen, inventoryScreen;
    private float armor, vit, magDef, movSp, dur, armorMax, vitMax, magDefMax, movSpMax, durMax;
    private int cost;
    private bool upg, dis;
    private const float defaultX = 822;
    private const float defaultY = 334;
    private float ratioX, ratioY;

    void Start()
    {
        armorScreen = InventoryScript.getArmorScreen();
        weaponScreen = InventoryScript.getWeaponScreen();
        inventoryScreen = GameObject.Find("InventoryScreen");
        ratioY = transform.GetComponent<RectTransform>().sizeDelta.y / defaultY;
        ratioX = transform.GetComponent<RectTransform>().sizeDelta.x / defaultX;

        resizeUI();
        readArmorMax();
    }

    void Update()
    {
        readArmorStats();
        printArmorStats();
    }
    public void instantiator()
    {
        if (InventoryScript.isSpaceAvailable())
        {
            createArmor();
        }
        returnToInventory();
    }
    public void goToArmorScreen()
    {
        InventoryScript.getArmorScreen().SetActive(true);
        InventoryScript.getWeaponScreen().SetActive(false);
        InventoryScript.getInventoryScreen().SetActive(false);
    }
    public void returnToInventory()
    {
        InventoryScript.getArmorScreen().SetActive(false);
        InventoryScript.getWeaponScreen().SetActive(false);
        InventoryScript.getInventoryScreen().SetActive(true);
    }
    void createArmor()
    {
        int pos = InventoryScript.firstEmptySpace();
        GameObject newArmor = (GameObject)Instantiate(Resources.Load("Armor"),
                InventoryScript.getInventoryScreen().transform.GetChild(2).GetChild(0).GetChild(pos).transform);
        newArmor.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.2f + 0.4f * (armor / armorMax + magDef / magDefMax),
         -0.2f + 0.6f * (movSp / movSpMax + vit / vitMax), 0.2f + 0.8f * System.Convert.ToInt32(upg), 0.5f + 0.5f * dur / durMax);
        InventoryScript.addArmor(InventoryScript.firstEmptySpace());
        newArmor.name = "Armor" + InventoryScript.getArmorCount();
        newArmor.GetComponent<ArmorScript>().armor = armor;
        newArmor.GetComponent<ArmorScript>().vitality = vit;
        newArmor.GetComponent<ArmorScript>().magicDefense = magDef;
        newArmor.GetComponent<ArmorScript>().movementSpeed = movSp;
        newArmor.GetComponent<ArmorScript>().durability = dur;
        newArmor.GetComponent<ArmorScript>().upgradeable = upg;
        newArmor.GetComponent<ArmorScript>().disenchantable = dis;
        newArmor.GetComponent<ArmorScript>().invPosition = pos;
    }
    void readArmorStats()
    {
        armor = transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;
        vit = transform.GetChild(1).GetChild(0).GetComponent<Slider>().value;
        magDef = transform.GetChild(2).GetChild(0).GetComponent<Slider>().value;
        movSp = transform.GetChild(3).GetChild(0).GetComponent<Slider>().value;
        dur = transform.GetChild(4).GetChild(0).GetComponent<Slider>().value;
        upg = transform.GetChild(5).GetChild(0).GetComponent<Toggle>().isOn;
        dis = transform.GetChild(6).GetChild(0).GetComponent<Toggle>().isOn;
    }
    void readArmorMax()
    {
        armorMax = transform.GetChild(0).GetChild(0).GetComponent<Slider>().maxValue;
        vitMax = transform.GetChild(1).GetChild(0).GetComponent<Slider>().maxValue;
        magDefMax = transform.GetChild(2).GetChild(0).GetComponent<Slider>().maxValue;
        movSpMax = transform.GetChild(3).GetChild(0).GetComponent<Slider>().maxValue;
        durMax = transform.GetChild(4).GetChild(0).GetComponent<Slider>().maxValue;
    }
    void printArmorStats()
    {
        transform.GetChild(0).GetChild(1).GetComponent<Text>().text = armor.ToString();
        transform.GetChild(1).GetChild(1).GetComponent<Text>().text = vit.ToString();
        transform.GetChild(2).GetChild(1).GetComponent<Text>().text = magDef.ToString();
        transform.GetChild(3).GetChild(1).GetComponent<Text>().text = (Mathf.Ceil(movSp * 100) / 100).ToString();
        transform.GetChild(4).GetChild(1).GetComponent<Text>().text = dur.ToString();
        cost = 100 + (int)(armor * 10 + vit * 9 + magDef * 12 + movSp * 200 + dur * 5) + System.Convert.ToInt32(upg) * 150 + System.Convert.ToInt32(dis) * 100;
        transform.GetChild(9).GetChild(0).GetComponent<Text>().text = "Cost : " + cost;
        transform.GetChild(9).GetComponent<Image>().color = new Color(0.2f + 0.4f * (armor / armorMax + magDef / magDefMax),
        -0.2f + 0.6f * (movSp / movSpMax + vit / vitMax), 0.2f + 0.8f * System.Convert.ToInt32(upg), 0.5f + 0.5f * dur / durMax);
    }
    void resizeUI()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<RectTransform>().localScale = new Vector3(ratioX, ratioY, 1);
            child.GetComponent<RectTransform>().localPosition = new Vector3(ratioX * child.GetComponent<RectTransform>().localPosition.x,
           ratioY * child.GetComponent<RectTransform>().localPosition.y, 0);
        }
    }
}
