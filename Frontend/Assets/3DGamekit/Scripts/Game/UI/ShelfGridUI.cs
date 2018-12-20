using Gamekit3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelfGridUI : MonoBehaviour
{
    public GameObject ShelfItem;

    private void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        foreach (KeyValuePair<string, TreasureMall> goods in TreasureInfo.treasureMall)
        {
            string key = goods.Key;
            GameObject cloned = GameObject.Instantiate(ShelfItem);
            if (cloned == null)
            {
                continue;
            }
            cloned.SetActive(true);
            cloned.transform.SetParent(this.transform, false);
            ShelfItemUI handler = cloned.GetComponent<ShelfItemUI>();
            if (handler == null)
            {
                continue;
            }
            handler.Init(key, goods.Value.price, goods.Value.isGold);
            //Debug.Log("name: " + key + " defense: " + TreasureInfo.treasureAttri[key].defense);
        }

        ShelfItem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        //foreach (KeyValuePair<string, Treasure> tmp in TreasureInfo.treasureAttri)
        //{
        //    Debug.Log("attribute: " + tmp.Key);
        //}

        //foreach (KeyValuePair<string, TreasureMall> tmp in TreasureInfo.treasureMall)
        //{
        //    Debug.Log("mall: " + tmp.Key);
        //}
    }
}
