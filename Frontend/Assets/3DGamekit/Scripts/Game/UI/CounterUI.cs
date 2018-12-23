using Common;
using Gamekit3D;
using Gamekit3D.Network;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterUI : MonoBehaviour
{
    public CartGridUI CartGrid;
    public Text TextSilverNeed;
    public Text TextGoldNeed;

    // overall detail 
    int totalGold = 0;
    int totalSilver = 0;
    Dictionary<string, int> SilverGoods = new Dictionary<string, int>();
    List<string> GoldGoods = new List<string>();
    private void Awake()
    {
    }
    // Use this for initialization
    void Start()
    {
        TextSilverNeed.text = totalSilver.ToString();
        TextGoldNeed.text = totalGold.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseGold(string name, int Price)
    {
        totalGold += Price;
        GoldGoods.Add(name);
        TextGoldNeed.text = totalGold.ToString();
    }

    public void DecreaseGold(string name, int Price)
    {
        totalGold -= Price;
        GoldGoods.Remove(name);
        TextGoldNeed.text = totalGold.ToString();
    }

    public void IncreaseSilver(string name, int Price)
    {
        totalSilver += Price;
        if (SilverGoods.ContainsKey(name))
        {
            SilverGoods[name]++;
        }
        else
            SilverGoods.Add(name, 1);

        TextSilverNeed.text = totalSilver.ToString();
    }

    public void DecreaseSilver(string name, int Price)
    {
        totalSilver -= Price;
        if (SilverGoods[name] == 1)
        {
            SilverGoods.Remove(name);
        }
        else
            SilverGoods[name]--;

        TextSilverNeed.text = totalSilver.ToString();
    }

    public void OnClickBuy()
    {
        // varify whether has enough money to buy
        if (PlayerInfo.GoldNum >= totalGold && PlayerInfo.SilverNum >= totalSilver)
        {
            PlayerInfo.SilverNum -= totalSilver;

            CBuy buyMessage = new CBuy()
            {
                totalGold = totalGold,
                totalSilver = totalSilver,
                Goods = new List<DTreasureBuy>()
            };

            foreach (string GoldName in GoldGoods)
            {
                buyMessage.Goods.Add(new DTreasureBuy() { name = GoldName, type = 0 });
            }

            foreach (var kv in SilverGoods)
            {
                string sliverName = kv.Key;
                int sliverNum = kv.Value;
                if (TreasureInfo.playerTreasure.ContainsKey(sliverName))
                {
                    TreasureInfo.playerTreasure[sliverName].number += sliverNum;
                    buyMessage.Goods.Add(new DTreasureBuy() { name = sliverName, number = TreasureInfo.playerTreasure[sliverName].number, type = 2 });
                }                   
                else
                {
                    TreasurePackage tmp = new TreasurePackage() {number = sliverNum, wear = false };
                    TreasureInfo.playerTreasure.Add(sliverName, tmp);
                    buyMessage.Goods.Add(new DTreasureBuy() { name = sliverName, number = sliverNum, type = 1 });
                }
                    
            }
            MyNetwork.Send(buyMessage);

            cleanCache();
        }
        else
        {
            MessageBox.Show("don't have enough money!");
        }
    }

    void cleanCache()
    {

        totalGold = 0;
        totalSilver = 0;
        TextSilverNeed.text = totalSilver.ToString();
        TextGoldNeed.text = totalGold.ToString();
        SilverGoods.Clear();
        GoldGoods.Clear();
        CartGrid.RemoveAllFromCart();
    }

}
