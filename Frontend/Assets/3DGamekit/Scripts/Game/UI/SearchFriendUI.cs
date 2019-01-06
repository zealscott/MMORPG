using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit3D;
using UnityEngine.UI;
using Gamekit3D.Network;
using Common;

public class SearchFriendUI : MonoBehaviour
{
    public Text searchFriend;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {

    }



    public void SearchFriend()
    {
        if (searchFriend != null)
        {
            string searchName = searchFriend.text;
            Debug.Log("search friend: " + searchName);
            if (PlayerInfo.friends.Contains(searchName))
            {
                MessageBox.Show(searchName + " is alreay your friend");
            }
            else
            {
                CSearchAddFriend msg = new CSearchAddFriend() { name = searchName };
                MyNetwork.Send(msg);
            }          
        }
    }
}