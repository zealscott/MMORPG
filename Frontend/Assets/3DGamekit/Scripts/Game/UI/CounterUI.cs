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
    Dictionary<string, int> silverGoods = new Dictionary<string, int>();
    List<string> goldGoods = new List<string>();
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
        goldGoods.Add(name);
        TextGoldNeed.text = totalGold.ToString();
    }

    public void DecreaseGold(string name, int Price)
    {
        totalGold -= Price;
        goldGoods.Remove(name);
        TextGoldNeed.text = totalGold.ToString();
    }

    public void IncreaseSilver(string name, int Price)
    {
        totalSilver += Price;
        if (silverGoods.ContainsKey(name))
        {
            silverGoods[name]++;
        }
        else
            silverGoods.Add(name, 1);
        TextSilverNeed.text = totalSilver.ToString();
    }

    public void DecreaseSilver(string name, int Price)
    {
        totalSilver -= Price;
        if (silverGoods[name] == 1)
        {
            silverGoods.Remove(name);
        }
        else
            silverGoods[name]--;
        TextSilverNeed.text = totalSilver.ToString();
    }

    public void OnClickBuy()
    {
        // varify whether has enough money to buy
        if (PlayerInfo.GoldNum >= totalGold && PlayerInfo.SilverNum >= totalSilver)
        {
            PlayerInfo.SilverNum -= totalSilver;

            // whether the silver god 
            Dictionary<string, int> OldSilverGoods = new Dictionary<string, int>();

            foreach (var kv in silverGoods)
            {
                if (TreasureInfo.playerTreasure.ContainsKey(kv.Key))
                {
                    OldSilverGoods.Add(kv.Key, kv.Value);
                    silverGoods.Remove(kv.Key);
                }
            }

            CBuy buyMessage = new CBuy()
            {
                totalGold = this.totalGold,
                totalSilver = this.totalSilver,
                newSilverGoods = this.silverGoods,
                //oldSilverGoods = OldSilverGoods,
                goldGoods = this.goldGoods
            };
            if (OldSilverGoods.Count > 0)
                buyMessage.oldSilverGoods = OldSilverGoods;

            MyNetwork.Send(buyMessage);

            Debug.Log("buy send!");

            //TODO: add silver treasure to package

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
        silverGoods.Clear();
        goldGoods.Clear();
        CartGrid.RemoveAllFromCart();
    }

}
