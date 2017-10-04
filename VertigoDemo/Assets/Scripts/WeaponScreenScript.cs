using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScreenScript : MonoBehaviour
{

    private GameObject armorScreen, weaponScreen, inventoryScreen;
    private float atkPow, vit, blk, atkSp, dur, atkPowMax, vitMax, blkMax, atkSpMax, durMax;
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
        readWeaponMax();

    }


    void Update()
    {

        readWeaponStats();
        printWeaponStats();

    }
    public void instantiator()
    {

        
        if (InventoryScript.isSpaceAvailable())
        {
            createWeapon();
        }
        returnToInventory();

    }
    public void goToWeaponScreen()
    {
        InventoryScript.getArmorScreen().SetActive(false);
        InventoryScript.getWeaponScreen().SetActive(true);
        InventoryScript.getInventoryScreen().SetActive(false);
    }
    public void returnToInventory()
    {
        InventoryScript.getArmorScreen().SetActive(false);
        InventoryScript.getWeaponScreen().SetActive(false);
        InventoryScript.getInventoryScreen().SetActive(true);
    }
    void createWeapon()
    {
        int pos = InventoryScript.firstEmptySpace();
        GameObject newWeapon = (GameObject)Instantiate(Resources.Load("Weapon"),
                InventoryScript.getInventoryScreen().transform.GetChild(2).GetChild(0).GetChild(pos).transform);
        newWeapon.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.2f + 0.4f * (atkPow / atkPowMax + atkSp / atkSpMax),
        0.2f + 0.4f * (blk / blkMax + vit / vitMax), 0.2f + 0.8f * System.Convert.ToInt32(upg), 0.5f + 0.5f * dur / durMax);
        InventoryScript.addWeapon(InventoryScript.firstEmptySpace());
        newWeapon.name = "Weapon" + InventoryScript.getWeaponCount();
        newWeapon.GetComponent<WeaponScript>().attackPower = atkPow;
        newWeapon.GetComponent<WeaponScript>().vitality = vit;
        newWeapon.GetComponent<WeaponScript>().block = blk;
        newWeapon.GetComponent<WeaponScript>().attackSpeed = atkSp;
        newWeapon.GetComponent<WeaponScript>().durability = dur;
        newWeapon.GetComponent<WeaponScript>().upgradeable = upg;
        newWeapon.GetComponent<WeaponScript>().disenchantable = dis;
        newWeapon.GetComponent<WeaponScript>().invPosition = pos;

    }
    void readWeaponStats()
    {
        /* atkPow = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Slider>().value;
         vit = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Slider>().value;
         blk = transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Slider>().value;
         atkSp = transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Slider>().value;
         dur = transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<Slider>().value;
         upg = transform.GetChild(0).GetChild(5).GetChild(0).GetComponent<Toggle>().isOn;
         dis = transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<Toggle>().isOn;
     */
        atkPow = transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;
        vit = transform.GetChild(1).GetChild(0).GetComponent<Slider>().value;
        blk = transform.GetChild(2).GetChild(0).GetComponent<Slider>().value;
        atkSp = transform.GetChild(3).GetChild(0).GetComponent<Slider>().value;
        dur = transform.GetChild(4).GetChild(0).GetComponent<Slider>().value;
        upg = transform.GetChild(5).GetChild(0).GetComponent<Toggle>().isOn;
        dis = transform.GetChild(6).GetChild(0).GetComponent<Toggle>().isOn;
    }
    void readWeaponMax()
    {
        /*atkPowMax = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Slider>().maxValue;
        vitMax = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Slider>().maxValue;
        blkMax = transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Slider>().maxValue;
        atkSpMax = transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Slider>().maxValue;
        durMax = transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<Slider>().maxValue;
    */
        atkPowMax = transform.GetChild(0).GetChild(0).GetComponent<Slider>().maxValue;
        vitMax = transform.GetChild(1).GetChild(0).GetComponent<Slider>().maxValue;
        blkMax = transform.GetChild(2).GetChild(0).GetComponent<Slider>().maxValue;
        atkSpMax = transform.GetChild(3).GetChild(0).GetComponent<Slider>().maxValue;
        durMax = transform.GetChild(4).GetChild(0).GetComponent<Slider>().maxValue;
    }
    void printWeaponStats()
    {
        /*transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>().text = atkPow.ToString();
        transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Text>().text = vit.ToString();
        transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Text>().text = blk.ToString();
        transform.GetChild(0).GetChild(3).GetChild(1).GetComponent<Text>().text = (Mathf.Ceil(atkSp * 100) / 100).ToString();
        transform.GetChild(0).GetChild(4).GetChild(1).GetComponent<Text>().text = dur.ToString();
        cost = 100 + (int)(atkPow * 20 + vit * 15 + blk * 12 + atkSp * 300 + dur * 5) + System.Convert.ToInt32(upg) * 200 + System.Convert.ToInt32(dis) * 100;
        transform.GetChild(0).GetChild(9).GetChild(0).GetComponent<Text>().text = "Cost : " + cost;
        transform.GetChild(0).GetChild(9).GetComponent<Image>().color = new Color(0.2f + 0.4f * (atkPow / atkPowMax + atkSp / atkSpMax),
            0.2f + 0.4f * (blk / blkMax + vit / vitMax), 0.2f + 0.8f * System.Convert.ToInt32(upg), 0.5f + 0.5f * dur / durMax);
    */
        transform.GetChild(0).GetChild(1).GetComponent<Text>().text = atkPow.ToString();
        transform.GetChild(1).GetChild(1).GetComponent<Text>().text = vit.ToString();
        transform.GetChild(2).GetChild(1).GetComponent<Text>().text = blk.ToString();
        transform.GetChild(3).GetChild(1).GetComponent<Text>().text = (Mathf.Ceil(atkSp * 100) / 100).ToString();
        transform.GetChild(4).GetChild(1).GetComponent<Text>().text = dur.ToString();
        cost = 100 + (int)(atkPow * 20 + vit * 15 + blk * 12 + atkSp * 300 + dur * 5) + System.Convert.ToInt32(upg) * 200 + System.Convert.ToInt32(dis) * 100;
        transform.GetChild(9).GetChild(0).GetComponent<Text>().text = "Cost : " + cost;
        transform.GetChild(9).GetComponent<Image>().color = new Color(0.2f + 0.4f * (atkPow / atkPowMax + atkSp / atkSpMax),
            0.2f + 0.4f * (blk / blkMax + vit / vitMax), 0.2f + 0.8f * System.Convert.ToInt32(upg), 0.5f + 0.5f * dur / durMax);
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
