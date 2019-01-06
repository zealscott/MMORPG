using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit3D;
using UnityEngine.UI;
using Gamekit3D.Network;
using Common;

public class ChangeFunctionUI : MonoBehaviour
{
    public GameObject Chat;
    public GameObject Friend;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {

    }



    public void ClickChat()
    {
        Chat.SetActive(true);
        Friend.SetActive(false);
    }

    public void ClickFriend()
    {
        Chat.SetActive(false);
        Friend.SetActive(true);
    }
}