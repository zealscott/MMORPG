using Common;
using Gamekit3D;
using Gamekit3D.Network;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellUI : MonoBehaviour
{
    public Text priceNum;
    public Text price;
    public string itemName;
    public bool isMall;
    int price_;
    public GameObject ClearAfterWear;
    PacakgeAttributeUI packageHandler;
    public GameObject UpdateInventory;
    InventoryUI inventoryHandler;

    private void Awake()
    {
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
    
    public void SellKind(string name)
    {
        itemName = name;
        if (TreasureInfo.treasureMall.ContainsKey(itemName))
        {
            priceNum.text = "回收个数";
            isMall = true;
        }            
        else
        {
            priceNum.text = "出售价格";
            isMall = false;
        }
    }

    public void Increase()
    {
        price_ = int.Parse(price.text);
        if (isMall)
        {
            if (price_ + 1 > TreasureInfo.playerTreasure[itemName].number)
            {
                MessageBox.Show("Cannot add any more.");
            }
            else
            {
                price_++;
                price.text = price_.ToString();
            }
        }
        else
        {
            price_++;
            price.text = price_.ToString();
        }
    }

    public void Decrease()
    {
        price_ = int.Parse(price.text);
        if (price_ - 1 <= 0)
        {
            MessageBox.Show("Cannot minus any more.");
        }
        else
        {
            price_--;
            price.text = price_.ToString();
        }
    }

    public void SellGoods()
    {
        if (itemName != null)
        {
            price_ = int.Parse(price.text);
            if(price_ < 0)
            {
                MessageBox.Show("Input text must > 0!");
                return;
            }

            if (isMall)
            {
                if(price_ > TreasureInfo.playerTreasure[itemName].number)
                {
                    MessageBox.Show("You do not have so many treasure!");
                    return;
                }

                CSellSilver msg = new CSellSilver();
                // sell back to mall, remove treasure from package and add silverCoin number
                PlayerInfo.SilverNum += price_ * TreasureInfo.treasureMall[itemName].price;
                msg.silverCoin = PlayerInfo.SilverNum;
                msg.goods = itemName;

                if (TreasureInfo.playerTreasure[itemName].number > price_)
                {
                    TreasureInfo.playerTreasure[itemName].number -= price_;
                    msg.sellAll = false;
                    msg.remainNum = TreasureInfo.playerTreasure[itemName].number;
                }
                else
                {
                    TreasureInfo.playerTreasure.Remove(itemName);
                    msg.sellAll = true;
                }

                // send message
                MyNetwork.Send(msg);
            }
            else
            {
                // gold treasures, remove treasure from package and add to mall
                TreasureInfo.playerTreasure.Remove(itemName);
                TreasureMall tmp = new TreasureMall()
                {
                    ownerName = PlayerInfo.name,
                    price = price_,
                    isGold = true
                };
                TreasureInfo.treasureMall.Add(itemName, tmp);

                // send message 
                CSellGold msg2 = new CSellGold()
                {
                    goods = itemName,
                    price = price_
                };
                MyNetwork.Send(msg2);
            }
        }

        if (packageHandler != null)
        {
            packageHandler.ClearAfterAdd();
        }

        // scene
        if (inventoryHandler != null)
        {
            inventoryHandler.UpdateInventory();
        }
    }
}
