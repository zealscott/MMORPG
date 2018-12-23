using Gamekit3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeUI : MonoBehaviour
{
    public int type;
    public Image itemImage;
    public string itemName;
    public GameObject UpdateInventory;
    InventoryUI inventoryHandler;

    private void Awake()
    {
        itemImage.enabled = false;
        if (UpdateInventory != null)
        {
            inventoryHandler = UpdateInventory.GetComponent<InventoryUI>();
        }
    }


    // Use this for initialization
    void Start()
    {
        if (type != 0)
        {
            foreach(KeyValuePair<string, TreasurePackage> kv in TreasureInfo.playerTreasure)
            {
                if (kv.Value.wear == true & TreasureInfo.treasureAttri[kv.Key].mainType == type)
                {
                    itemName = kv.Key;
                    itemImage.sprite = GetAllIcons.icons[itemName];
                    itemImage.enabled = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void AddImage(string name)
    {
        if(itemImage.enabled == true)
        {
            MessageBox.Show("Please put off this kind of weapon first.");
        }
        else
        {
            itemImage.sprite = GetAllIcons.icons[name];
            itemImage.enabled = true;
            itemName = name;

            // change attributes
            TreasureInfo.playerTreasure[name].wear = true;
            PlayerInfo.intelligence += TreasureInfo.treasureAttri[name].intelligence;
            PlayerInfo.speed += TreasureInfo.treasureAttri[name].speed;
            PlayerInfo.attack += TreasureInfo.treasureAttri[name].attack;
            PlayerInfo.defense += TreasureInfo.treasureAttri[name].defense;

            // add message content
            if (TreasureInfo.modifiedTreasure.ContainsKey(itemName))
                TreasureInfo.modifiedTreasure.Remove(itemName);
            else
                TreasureInfo.modifiedTreasure.Add(itemName, true);
        }
    }

    // put off treasure
    public void DeleteImage()
    {
        if(itemImage.enabled == true)
        {
            itemImage.enabled = false;

            // change attributes
            TreasureInfo.playerTreasure[itemName].wear = false;
            PlayerInfo.intelligence -= TreasureInfo.treasureAttri[itemName].intelligence;
            PlayerInfo.speed -= TreasureInfo.treasureAttri[itemName].speed;
            PlayerInfo.attack -= TreasureInfo.treasureAttri[itemName].attack;
            PlayerInfo.defense -= TreasureInfo.treasureAttri[itemName].defense;

            // add message content
            if (TreasureInfo.modifiedTreasure.ContainsKey(itemName))
                TreasureInfo.modifiedTreasure.Remove(itemName);
            else
                TreasureInfo.modifiedTreasure.Add(itemName, false);

            // scene
            if (inventoryHandler != null)
            {
                inventoryHandler.UpdateInventory();
            }
        }
        else
        {
            MessageBox.Show("No treasure to put off.");
        }
    }
}
