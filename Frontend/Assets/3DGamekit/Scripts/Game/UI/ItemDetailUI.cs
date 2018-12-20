using Gamekit3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailUI : MonoBehaviour {

    public Image icon;
    public Image attributeImage;
    public Text itemName;
    public Text itemCost;
    public Text itemIntellgience;
    public Text itemSpeed;
    public Text itemAttack;
    public Text itemDefense;
    public CartGridUI handler;

    private void Awake()
    {
    }


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddToCart()
    {
        if (handler != null)
            handler.AddToCart(itemName.text);
        //Debug.Log(itemName.text);
    }

    public void AddToDetail(string name)
    {
        icon.sprite = GetAllIcons.icons[name];

        TreasureMall itemInMall =  TreasureInfo.treasureMall[name];
        Treasure item =  TreasureInfo.treasureAttri[name];

        // display attributes 
        itemName.text = name;
        itemIntellgience.text = item.intelligence.ToString();
        itemSpeed.text = item.speed.ToString();
        itemAttack.text = item.attack.ToString();
        itemDefense.text = item.defense.ToString();
        itemCost.text = itemInMall.price.ToString();

        if(itemInMall.isGold)
            attributeImage.sprite = Resources.Load<Sprite>("AttributeGold");
        else
            attributeImage.sprite = Resources.Load<Sprite>("AttributeSilver");
          
    }

}
