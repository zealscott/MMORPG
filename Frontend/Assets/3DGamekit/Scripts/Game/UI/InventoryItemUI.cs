using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemUI : MonoBehaviour
{
    public string itemName;
    public GameObject ItemDetail;
    PacakgeAttributeUI handler;

    private void Awake()
    {
        if (ItemDetail != null)
        {
            handler = ItemDetail.GetComponent<PacakgeAttributeUI>();
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

    public void Init(string name)
    {
        itemName = name;
    }


    public void AddToDetail()
    {
        if (handler != null)
            handler.ShowAttributes(itemName);
    }
}
