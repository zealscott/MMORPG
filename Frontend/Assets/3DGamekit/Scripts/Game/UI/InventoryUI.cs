using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gamekit3D;
using Gamekit3D.Network;

public class InventoryUI : MonoBehaviour
{

    public GameObject InventoryCell;
    public GameObject InventoryGridContent;

    // Use this for initialization

    private void Awake()
    {
        InventoryCell.SetActive(false);
    }

    private void OnEnable()
    {
        PlayerMyController.Instance.EnabledWindowCount++;
        int capacity = PlayerMyController.Instance.InventoryCapacity;
        int count = PlayerMyController.Instance.Inventory.Count;
        foreach (var kv in PlayerMyController.Instance.Inventory)
        {
            //Debug.Log("inventory: " + kv.Value.name + " type: " + kv.Value.entityType);

            GameObject cloned = GameObject.Instantiate(InventoryCell);
            Button button = cloned.GetComponent<Button>();
            // TODO ... specify icon by item types
            Sprite icon = GetAllIcons.icons["Sword_2"];
            button.image.sprite = icon;
            cloned.SetActive(true);
            cloned.transform.SetParent(InventoryGridContent.transform, false);
        }

        foreach (var kv in TreasureInfo.playerTreasure)
        {
            GameObject cloned = GameObject.Instantiate(InventoryCell);
            Button button = cloned.GetComponent<Button>();
            Sprite icon = GetAllIcons.icons[kv.Key];
            button.image.sprite = icon;
            cloned.SetActive(true);
            cloned.transform.SetParent(InventoryGridContent.transform, false);
        }

        count += TreasureInfo.playerTreasure.Count;

        // genreate empty cell
        for (int i = 0; i < capacity - count; i++)
        {
            GameObject cloned = GameObject.Instantiate(InventoryCell);
            cloned.SetActive(true);
            cloned.transform.SetParent(InventoryGridContent.transform, false);
        }
    }

    private void OnDisable()
    {
        int cellCount = InventoryGridContent.transform.childCount;
        foreach (Transform transform in InventoryGridContent.transform)
        {
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

    void ExtendBagCapacity(int n)
    {
        int cellCount = InventoryGridContent.transform.childCount;
        for (int i = 0; i < n - cellCount; i++)
        {
            GameObject cloned = GameObject.Instantiate(InventoryCell);
            cloned.SetActive(true);
            cloned.transform.SetParent(InventoryGridContent.transform, false);
        }
    }
}
