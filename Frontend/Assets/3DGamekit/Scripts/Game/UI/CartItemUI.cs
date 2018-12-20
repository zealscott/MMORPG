using Gamekit3D;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CartItemUI : MonoBehaviour
{
    public CounterUI handler;

    public Button button;
    public TextMeshProUGUI CartCostMash;
    public InputField inputCount;

    int price;
    int count = 0;
    bool isGold = false;
    string itemName;

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Init(string name)
    {
        Sprite sprite;

        price = TreasureInfo.treasureMall[name].price;
        isGold = TreasureInfo.treasureMall[name].isGold;

        if (button == null || CartCostMash == null || CartCostMash == null)
        {
            return;
        }
        if (!GetAllIcons.icons.TryGetValue(name, out sprite))
        {
            return;
        }

        itemName = name;
        count++;
        button.image.sprite = sprite;
        inputCount.text = System.Convert.ToString(count);

        IncreaseCost();
    }

    public void Increase()
    {
        if (isGold)
        {
            MessageBox.Show("This Treasure is unique!");
            return;
        }
        count++;
        inputCount.text = System.Convert.ToString(count);

        IncreaseCost();
    }

    public void Decrease()
    {
        count--;
        DecreaseCost();
        if (count == 0)
        {
            if (transform.parent == null)
            {
                return;
            }
            CartGridUI gridHandler = transform.parent.GetComponent<CartGridUI>();
            if (gridHandler != null)
            {
                gridHandler.RemoveFromCart(itemName);
            }
        }
        else
        {
            inputCount.text = System.Convert.ToString(count);
        }
    }

    void IncreaseCost()
    {
        if (isGold)
        {
            handler.IncreaseGold(itemName, price);
            CartCostMash.text = "<sprite=1> " + (price * count).ToString();
        }
        else
        {
            handler.IncreaseSilver(itemName, price);
            CartCostMash.text = "<sprite=0> " + (price * count).ToString();
        }
    }

    void DecreaseCost()
    {
        if (isGold)
        {
            handler.DecreaseGold(itemName, price);
            CartCostMash.text = "<sprite=1> " + (price * count).ToString();
        }
        else
        {
            handler.DecreaseSilver(itemName, price);
            CartCostMash.text = "<sprite=0> " + (price * count).ToString();
        }
    }

}
