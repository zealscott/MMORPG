using Gamekit3D;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
        ShelfItem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
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
            //MessageBox.Show("mall: " + key);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject go = this.transform.GetChild(i).gameObject;
            Destroy(go);
        }
    }
}
