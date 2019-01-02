using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelfSellItemUI : MonoBehaviour
{
    public string itemName;
    public GameObject ItemDetail;
    NotSellUI handler;

    private void Awake()
    {
        if (ItemDetail != null)
        {
            handler = ItemDetail.GetComponent<NotSellUI>();
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
        Debug.Log("init " + name);
    }


    public void NotSellButton()
    {
        if (handler != null)
        {
            handler.PassName(itemName);
            Debug.Log("pass name " + itemName);
        }           
    }
}
