using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour {


    GameObject inventoryScreen;
    float mouseX,mouseY;
    Vector3 init;
    //STATS
    public float attackPower;
    public float vitality;
    public float block;
    public float attackSpeed;
    public float durability;
    public bool upgradeable;
    public bool disenchantable;
    public int invPosition;
    //

    //CONDITIONS
    private RaycastHit hitInfo;
    private bool nowDragging;
    private bool hit;

    void Start()
    {
        inventoryScreen = InventoryScript.getInventoryScreen();
        
    }

   
    void Update () {
        
       
       hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit) print(hitInfo.transform);
        

    }

    void OnMouseDrag()
    {
       
        transform.localPosition = new Vector3( Input.mousePosition.x/ InventoryScript.getRatios().x ,Input.mousePosition.y/InventoryScript.getRatios().y ,0)-
            new Vector3(inventoryScreen.GetComponent<RectTransform>().rect.width/(2 * InventoryScript.getRatios().x),
            inventoryScreen.GetComponent<RectTransform>().rect.height / (2 * InventoryScript.getRatios().y),0) -
           transform.parent.position;
    }

    //RELEASE
    void OnMouseUp()
    {
       
        nowDragging = false;
        if (hit)
        {
            if(hitInfo.transform.tag=="Space")// && InventoryScript.)
            {
                moveToPanel(getPanelObject(hitInfo.transform.name));
            }else if(hitInfo.transform.tag == "Weapon")
            {
                transform.SetParent(transform.parent.parent.parent.GetChild(1).GetChild(0));
                transform.localPosition = Vector3.zero;
                transform.localScale = 2 * transform.localScale;
                invPosition = 20;
                InventoryScript.setEquippedWeapon(hitInfo.transform.name);
            }else if(hitInfo.transform.tag == "Disenchant")
            {

            }else
            {
                transform.localPosition = Vector3.zero;
            }
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
    }
    //CLICK
    void OnMouseDown() {
        nowDragging = true;
    }
   
    int getPanelObject(string spaceName)
    {
        return getStorageList().Find(spaceName).transform.GetSiblingIndex();

    }

    void moveToPanel(int spaceIndex)
    {
        //print(getStorageList().GetChild(0).childCount);
        if (getStorageList().GetChild(spaceIndex).childCount==1) {
            if (spaceIndex == invPosition)
            {
                transform.localPosition = Vector3.zero;
            }else
            {
                Transform temp = transform.parent;
                transform.SetParent(getStorageList().GetChild(spaceIndex));
                getStorageList().GetChild(spaceIndex).GetChild(0).SetParent(temp);
                transform.localPosition = Vector3.zero;
                getStorageList().GetChild(invPosition).GetChild(0).localPosition = Vector3.zero;        
                getStorageList().GetChild(invPosition).GetChild(0).GetComponent<WeaponScript>().changeInvPosition(invPosition);
                //ADD WEAPON AND ARMOR TOGETHER

                invPosition = spaceIndex;
            }

        }else
        {
            
            InventoryScript.setOccupied(invPosition, false);
            InventoryScript.setOccupied(spaceIndex, true);
            transform.SetParent(getStorageList().GetChild(spaceIndex));
            transform.localPosition = Vector3.zero;
            invPosition = spaceIndex;
        }

    }

    Transform getStorageList()
    {
        return transform.parent.parent;
    }

    public void changeInvPosition(int ind)
    {
        invPosition = ind;
    }
}
