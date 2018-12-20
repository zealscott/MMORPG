using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShelfItemUI : MonoBehaviour
{
    public string itemName;
    public GameObject ItemDetail;

    public Button button;
    public Text textName;
    public TextMeshProUGUI textCostMash;
    ItemDetailUI handler;

    private void Awake()
    {
        if (ItemDetail != null)
        {
            handler = ItemDetail.GetComponent<ItemDetailUI>();
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

    // type: 0 means golden while 1 means silver
    public void Init(string name, int price,bool isGold)
    {
        itemName = name;
        Sprite sprite;
        if (button == null || textName == null || textCostMash == null)
        {
            return;
        }
        if (!GetAllIcons.icons.TryGetValue(name, out sprite))
        {
            return;
        }
        button.image.sprite = sprite;
        textName.text = name;
        if (isGold)
            textCostMash.text =  "<sprite=1> "  + price.ToString();
        else
            textCostMash.text = "<sprite=0> " + price.ToString();
        // debug
    }


    public void AddToDetail()
    {
        if (handler != null)
            handler.AddToDetail(itemName);
    }
}
