using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShelfItemUI : MonoBehaviour
{
    public string itemName;
    public GameObject ItemDetail;

    public Button button;
    public Text textName;
    public Text textCost;
    public bool isGold;
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
    public void Init(string name, int type, int price)
    {
        itemName = name;
        Sprite sprite;
        if (button == null || textName == null || textCost == null)
        {
            return;
        }
        if (!GetAllIcons.icons.TryGetValue(name, out sprite))
        {
            return;
        }
        button.image.sprite = sprite;
        textName.text = name;
        textCost.text = price.ToString();

        if (type == 0)
            isGold = true;
        else
            isGold = false;
        // debug
    }


    public void AddToDetail()
    {
        if (handler != null)
            handler.AddToDetail(itemName, isGold);
    }
}
