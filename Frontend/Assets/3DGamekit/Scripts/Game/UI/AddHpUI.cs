using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gamekit3D;
using Common;
using Gamekit3D.Network;

public class AddHpUI : MonoBehaviour
{
    private Damageable m_damageable;
    private PlayerController m_controller;
    public GameObject UpdateInventory;
    InventoryUI inventoryHandler;

    private void Awake()
    {
        if (m_controller == null || m_damageable == null)
        {
            m_controller = PlayerController.Mine;
            m_damageable = PlayerController.Mine.GetComponent<Damageable>();
        }
        if (UpdateInventory != null)
        {
            inventoryHandler = UpdateInventory.GetComponent<InventoryUI>();
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

    public void AddHp(HealthUI healthUI)
    {
        if (m_damageable.currentHitPoints < m_damageable.maxHitPoints)
        {
            MessageBox.Show("Add HitPoints");
            m_damageable.currentHitPoints++;
            CUseHp msg = new CUseHp();
            if (TreasureInfo.playerTreasure["Elixir_3"].number == 1)
            {
                TreasureInfo.playerTreasure.Remove("Elixir_3");
                // send message
                msg.toDelete = true;
            }
            else
            {
                TreasureInfo.playerTreasure["Elixir_3"].number--;
                // send message
                msg.toDelete = false;
                msg.ownNum = TreasureInfo.playerTreasure["Elixir_3"].number;
            }
            MyNetwork.Send(msg);
            if (inventoryHandler != null)
            {
                inventoryHandler.UpdateInventory();
            }
            healthUI.ChangeHitPointUI(m_damageable);
        }
        else
        {
            MessageBox.Show("currentHitPoints is already max");
        }
    }
}
