using Gamekit3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoneyUI : MonoBehaviour
{

    public Text GoldNum;
    public Text SilverNum;

    private void Awake()
    {
        GoldNum.text = PlayerInfo.GoldNum.ToString();
        SilverNum.text = PlayerInfo.SilverNum.ToString();
    }


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GoldNum.text = PlayerInfo.GoldNum.ToString();
        SilverNum.text = PlayerInfo.SilverNum.ToString();
    }

}
