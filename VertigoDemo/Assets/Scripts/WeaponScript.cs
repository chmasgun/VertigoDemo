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
    private bool nowDragging;

    void Start()
    {
        inventoryScreen = InventoryScript.getInventoryScreen();
        
    }

   
    void Update () {
        
       RaycastHit hitInfo = new RaycastHit();
       bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
       if(hit) print(hitInfo.transform.gameObject);
        else { print("Zaaa"); }

    }

    void OnMouseDrag()
    {
       
        transform.localPosition = new Vector3( Input.mousePosition.x/ InventoryScript.getRatios().x ,Input.mousePosition.y/InventoryScript.getRatios().y ,0)-
            new Vector3(inventoryScreen.GetComponent<RectTransform>().rect.width/(2 * InventoryScript.getRatios().x),
            inventoryScreen.GetComponent<RectTransform>().rect.height / (2 * InventoryScript.getRatios().y),0) -
           transform.parent.position;
    }

    void OnMouseUp()
    {
        print("zaa");
        nowDragging = false;
    }

    void OnMouseDown() {
        print("xd");
    }
   
   
}
