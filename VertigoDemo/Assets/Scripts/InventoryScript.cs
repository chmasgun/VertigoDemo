using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{

    private static GameObject armorScreen;
    private static GameObject weaponScreen;
    private static GameObject inventoryScreen;
   private static bool[] spaceOccupied;
    private static int numOccupied;
    private static int weaponNumber;
    private static int armorNumber;
    private const float defaultX = 822;
    private const float defaultY = 334;
    private static float ratioX, ratioY;
    private static string equippedWeapon;
    private static string[] equippedArmors;
    

    void Start()
    {
        equippedArmors = new string[3];
        numOccupied = 0;
        weaponNumber = 0;
        armorNumber = 0;
        
        spaceOccupied = new bool[16];
        armorScreen = GameObject.Find("ArmorCreation");
        weaponScreen = GameObject.Find("WeaponCreation");
        inventoryScreen = GameObject.Find("InventoryScreen");
        ratioY = transform.GetComponent<RectTransform>().sizeDelta.y / defaultY;
        ratioX = transform.GetComponent<RectTransform>().sizeDelta.x / defaultX;
        resizeUI();
        weaponScreen.SetActive(false);
        armorScreen.SetActive(false);
       

    }
    void Update()
    {
       // if (Input.GetMouseButtonDown(0)) print(Input.mousePosition);
    }
    public static GameObject getArmorScreen() {
        return armorScreen;
    }
    public static GameObject getWeaponScreen() {
        return weaponScreen;
    }
    public static GameObject getInventoryScreen()
    {
        return inventoryScreen;
    }
    void resizeUI()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<RectTransform>().localPosition = new Vector3(ratioX * child.GetComponent<RectTransform>().localPosition.x,
            ratioY * child.GetComponent<RectTransform>().localPosition.y, 0);
            child.GetComponent<RectTransform>().localScale = new Vector3(ratioX, ratioY, 1);
        }
    }
    public static int firstEmptySpace()
    {
        for(int i=0; i<16; i++)
        {
            if (!spaceOccupied[i]) return i;
        }
        return -1;
    }
    public static bool isSpaceAvailable() {

        return numOccupied < 16;
    }

    public static void addWeapon(int ind) {
        spaceOccupied[ind] = true;
        numOccupied++;
        weaponNumber++;
    }
    public static void addArmor(int ind)
    {
        spaceOccupied[ind] = true;
        numOccupied++;
        armorNumber++;
    }
    public static int getWeaponCount() {
        return weaponNumber;
    }
    public static int getArmorCount()
    {
        return armorNumber;
    }

    public static Vector3 getBottomLeftCorner()
    {
       
        return new Vector3(ratioX*(inventoryScreen.transform.GetChild(1).position.x - inventoryScreen.transform.GetChild(1).GetComponent<RectTransform>().rect.width / 2),
          ratioY*(  inventoryScreen.transform.GetChild(1).position.y - inventoryScreen.transform.GetChild(1).GetComponent<RectTransform>().rect.height / 2), 0);
    }
    public static Vector2 getRatios()
    {
        return new Vector2(ratioX, ratioY);
    }
    public static void setOccupied(int ind,bool option)
    {
        spaceOccupied[ind] = option;
    }
    public static void setEquippedWeapon(string Wname)
    {
        equippedWeapon = Wname;
    }
    public static void setEquippedArmor(string aname,int ind)
    {
        equippedArmors[ind] = aname;
    }
    public static string[] getEquippedArmorList()
    {
        return equippedArmors;
    }
}
