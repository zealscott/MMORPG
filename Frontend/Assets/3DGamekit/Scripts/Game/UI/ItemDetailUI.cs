using Gamekit3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailUI : MonoBehaviour {

    public GameObject cartContent;

    public Image icon;
    public Image attributeImage;
    public Text itemName;
    public Text itemCost;
    public Text itemIntellgience;
    public Text itemSpeed;
    public Text itemAttack;
    public Text itemDefense;
    CartGridUI handler;

    private void Awake()
    {
        if (cartContent != null)
        {
            handler = cartContent.GetComponent<CartGridUI>();
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

    public void AddToCart()
    {
        if (handler != null)
            handler.AddToCart(itemName.text);
        Debug.Log(itemName.text);
    }

    public void AddToDetail(string name, bool isGold)
    {
        icon.sprite = GetAllIcons.icons[name];

        itemName.text = name;
        itemIntellgience.text = TreasureInfo.treasureAttri[name].intelligence.ToString();
        itemSpeed.text = TreasureInfo.treasureAttri[name].speed.ToString();
        itemAttack.text = TreasureInfo.treasureAttri[name].attack.ToString();
        itemDefense.text = TreasureInfo.treasureAttri[name].defense.ToString();

        if(isGold)
        {
            itemCost.text = TreasureInfo.goldenT[name].price.ToString();
            attributeImage.sprite = Resources.Load<Sprite>("AttributeGold");
        }       
        else
        {
            itemCost.text = TreasureInfo.silverT[name].ToString();
            attributeImage.sprite = Resources.Load<Sprite>("AttributeSilver");
        }           
    }

}
