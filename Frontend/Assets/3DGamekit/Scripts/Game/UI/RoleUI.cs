using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Gamekit3D;

public class RoleUI : MonoBehaviour
{

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

    }
    // Use this for initialization
    void Start()
    {
        string hp = string.Format("{0}/{1}", PlayerInfo.currentHP, 5);
        HPValue.SetText(hp, true);
        
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

        // debug
        IntelligenceValue.SetText(PlayerInfo.intelligence.ToString(), true);
        SpeedValue.SetText(PlayerInfo.speed.ToString(), true);
        LevelValue.SetText(PlayerInfo.level.ToString(), true);
        AttackValue.SetText(PlayerInfo.attack.ToString(), true);
        DefenseValue.SetText(PlayerInfo.defense.ToString(), true);
    }

    private void OnDisable()
    {
        PlayerMyController.Instance.EnabledWindowCount--;
    }

    // Update is called once per frame
    void Update()
    {

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
}
