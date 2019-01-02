using Common;
using Gamekit3D;
using Gamekit3D.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotSellUI : MonoBehaviour
{
    public GameObject ItemDetail;
    SelfSellUI handler;
    string itemName;

    private void Awake()
    {
        if (ItemDetail != null)
        {
            handler = ItemDetail.GetComponent<SelfSellUI>();
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
    
    public void PassName(string name)
    {
        itemName = name;
    }

    public void ClickSure()
    {
        Debug.Log(itemName);
        // remove from mall and put in package
        TreasureInfo.treasureMall.Remove(itemName);
        TreasurePackage tmp = new TreasurePackage()
        {
            wear = false,
            number = 1
        };
        TreasureInfo.playerTreasure.Add(itemName, tmp);
        foreach(var kv in TreasureInfo.playerTreasure)
        {
            Debug.Log(kv.Key);
        }

        // put item back to inventory
        if(handler != null)
        {
            Debug.Log("refresh sell window");
            handler.Refresh();
        }
        

        // send message
        CNotSell msg = new CNotSell()
        {
            goodsName = itemName
        };
        MyNetwork.Send(msg);
    }

}
