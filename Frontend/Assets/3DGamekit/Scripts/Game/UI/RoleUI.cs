using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Gamekit3D;
using Common;
using Gamekit3D.Network;

public class RoleUI : MonoBehaviour
{
    public GameObject ItemDetail;
    PacakgeAttributeUI handler;

    public TextMeshProUGUI HPValue;
    public TextMeshProUGUI IntelligenceValue;
    public TextMeshProUGUI SpeedValue;
    public TextMeshProUGUI LevelValue;
    public TextMeshProUGUI AttackValue;
    public TextMeshProUGUI DefenseValue;

    private Damageable m_damageable;
    private PlayerController m_controller;

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
        string hp = string.Format("{0}/{1}", PlayerInfo.currentHP, 5);
        HPValue.SetText(hp, true);

        if (handler != null)
            handler.ClearAfterAdd();
    }

    private void OnEnable()
    {
        PlayerMyController.Instance.EnabledWindowCount++;
        if (m_controller == null || m_damageable == null)
        {
            m_controller = PlayerController.Mine;
            m_damageable = PlayerController.Mine.GetComponent<Damageable>();
        }
        string hp = string.Format("{0}/{1}", m_damageable.currentHitPoints, m_damageable.maxHitPoints);
        HPValue.SetText(hp, true);
        IntelligenceValue.SetText(PlayerInfo.intelligence.ToString(), true);
        SpeedValue.SetText(PlayerInfo.speed.ToString(), true);
        LevelValue.SetText(PlayerInfo.level.ToString(), true);
        AttackValue.SetText(PlayerInfo.attack.ToString(), true);
        DefenseValue.SetText(PlayerInfo.defense.ToString(), true);

        TreasureInfo.modifiedTreasure = new Dictionary<string, bool>();
    }

    private void OnDisable()
    {
        PlayerMyController.Instance.EnabledWindowCount--;
        SendMessage();
        TreasureInfo.modifiedTreasure = new Dictionary<string, bool>();
        if (handler != null)
            handler.ClearAfterAdd();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_controller == null || m_damageable == null)
        {
            m_controller = PlayerController.Mine;
            m_damageable = PlayerController.Mine.GetComponent<Damageable>();
        }
        string hp = string.Format("{0}/{1}", m_damageable.currentHitPoints, m_damageable.maxHitPoints);
        HPValue.SetText(hp, true);
        IntelligenceValue.SetText(PlayerInfo.intelligence.ToString(), true);
        SpeedValue.SetText(PlayerInfo.speed.ToString(), true);
        LevelValue.SetText(PlayerInfo.level.ToString(), true);
        AttackValue.SetText(PlayerInfo.attack.ToString(), true);
        DefenseValue.SetText(PlayerInfo.defense.ToString(), true);
    }

    void Test()
    {
        HPValue.text = "100";
        IntelligenceValue.text = "100";
    }

    public void InitUI(PlayerController controller)
    {
        m_damageable = controller.GetComponent<Damageable>();
        m_controller = controller;
    }

    public void SendMessage()
    {
        // attribute message
        CPlayerAttribute msg1 = new CPlayerAttribute()
        {
            intelligence = PlayerInfo.intelligence,
            speed = PlayerInfo.speed,
            attack = PlayerInfo.attack,
            defense = PlayerInfo.defense
        };
        MyNetwork.Send(msg1);

        // treasure wear or put off message
        if(TreasureInfo.modifiedTreasure.Count != 0)
        {
            CTreasureWear msg2 = new CTreasureWear()
            {
                treasureWear = new Dictionary<string, bool>(TreasureInfo.modifiedTreasure)
            };
            MyNetwork.Send(msg2);
        }  
    }
}
