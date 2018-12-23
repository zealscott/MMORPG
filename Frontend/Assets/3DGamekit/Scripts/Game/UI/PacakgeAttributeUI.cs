using Gamekit3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacakgeAttributeUI : MonoBehaviour
{
    public GameObject ItemDetailWear;
    public GameObject ItemDetailSell;
    public Image itemImage;
    public Text itemName;
    public Text itemNum;
    public Text itemType;
    WearUI handlerWear;
    SellUI handlerSell;

    private void Awake()
    {
        if (ItemDetailWear != null)
        {
            handlerWear = ItemDetailWear.GetComponent<WearUI>();
            handlerSell = ItemDetailSell.GetComponent<SellUI>();
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
        itemImage.sprite = GetAllIcons.icons[name];
        itemName.text = name;
        itemNum.text = TreasureInfo.playerTreasure[name].number.ToString();
        int type = TreasureInfo.treasureAttri[name].mainType;
        if (type == 1)
            itemType.text = "helmet";
        else if (type == 2)
            itemType.text = "armour";
        else if (type == 3)
            itemType.text = "left weapon";
        else if (type == 4)
            itemType.text = "right weapon";
        else if (type == 5)
            itemType.text = "shield";
        else if (type == 6)
            itemType.text = "elixir";
    }

    public void ClickWear()
    {
        if (handlerWear != null)
        {
            handlerWear.ShowAttributes(itemName.text);
        }            
    }

    public void ClickSell()
    {
        if (handlerSell != null)
        {
            handlerSell.SellKind(itemName.text);
        }
    }

    public void ClearAfterAdd()
    {
        itemImage.sprite = Resources.Load<Sprite>("BackPic");
        itemName.text = null;
        itemNum.text = null;
        itemType.text = null;
    }
}
