using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gamekit3D;
using Gamekit3D.Network;

public class SelfSellUI : MonoBehaviour
{
    public GameObject SellCell;
    public GameObject SellGridContent;

    // Use this for initialization

    private void Awake()
    {
        SellCell.SetActive(false);
    }

    private void OnEnable()
    {
        PlayerMyController.Instance.EnabledWindowCount++;
        int capacity = 40;
        int count = 0;
        foreach (var kv in TreasureInfo.treasureMall)
        {
            if (kv.Value.ownerName.Equals(PlayerInfo.name))
            {
                GameObject cloned = GameObject.Instantiate(SellCell);
                Button button = cloned.GetComponent<Button>();
                Sprite icon = GetAllIcons.icons[kv.Key];
                button.image.sprite = icon;
                cloned.SetActive(true);
                cloned.transform.SetParent(SellGridContent.transform, false);
                SelfSellItemUI handler = cloned.GetComponent<SelfSellItemUI>();
                handler.Init(kv.Key);
                count++;
            }         
        }


        // genreate empty cell
        for (int i = 0; i < capacity - count; i++)
        {
            GameObject cloned = GameObject.Instantiate(SellCell);
            cloned.SetActive(true);
            cloned.transform.SetParent(SellGridContent.transform, false);
        }
    }

    private void OnDisable()
    {
        int cellCount = SellGridContent.transform.childCount;
        foreach (Transform transform in SellGridContent.transform)
        {
            //Debug.Log("destory inventory: " + transform.name);
            Destroy(transform.gameObject);
        }
        PlayerMyController.Instance.EnabledWindowCount--;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refresh()
    {
        OnDisable();
        OnEnable();
    }
}
