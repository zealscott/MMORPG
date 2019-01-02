using Gamekit3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WearUI : MonoBehaviour
{
    public Text intelligence;
    public Text speed;
    public Text attack;
    public Text defense;
    public string itemName;
    public GameObject ItemDetail;
    public GameObject ClearAfterWear;
    public GameObject UpdateInventory;
    InventoryUI inventoryHandler;
    EquipViewUI handler;
    PacakgeAttributeUI packageHandler;
    TypeUI typeHandler;


    private void Awake()
    {
        if (ItemDetail != null)
        {
            handler = ItemDetail.GetComponent<EquipViewUI>();
        }
        if (ClearAfterWear != null)
        {
            packageHandler = ClearAfterWear.GetComponent<PacakgeAttributeUI>();
        }
        if (UpdateInventory != null)
        {
            inventoryHandler = UpdateInventory.GetComponent<InventoryUI>();
        }
    }


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    
    public void ShowAttributes(string name)
    {
        //Debug.Log("wear show attributes");
        itemName = name;
        intelligence.text = TreasureInfo.treasureAttri[name].intelligence.ToString();
        speed.text = TreasureInfo.treasureAttri[name].speed.ToString();
        attack.text = TreasureInfo.treasureAttri[name].attack.ToString();
        defense.text = TreasureInfo.treasureAttri[name].defense.ToString();
    }

    public void ShowPic()
    {
        int type = TreasureInfo.treasureAttri[itemName].mainType;
        if (type == 1)
            typeHandler = handler.helmet;
        else if (type == 2)
            typeHandler = handler.armour;
        else if (type == 3)
            typeHandler = handler.leftWeapon;
        else if (type == 4)
            typeHandler = handler.rightWeapon;
        else if (type == 5)
            typeHandler = handler.shield;
        else if (type == 6)
            typeHandler = handler.elixir;
        
        if (typeHandler != null)
        {
            typeHandler.AddImage(itemName);
        }
            
        if(packageHandler != null)
        {
            packageHandler.ClearAfterAdd();
        }

        if(inventoryHandler != null)
        {
            inventoryHandler.UpdateInventory();
        }
    }
}
