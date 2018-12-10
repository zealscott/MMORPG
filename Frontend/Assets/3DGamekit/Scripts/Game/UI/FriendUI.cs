using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit3D;
using UnityEngine.UI;
using Gamekit3D.Network;
using Common;

public class FriendUI : MonoBehaviour
{
    public GameObject FriendInfo;
    public Button button;

    public List<GameObject> closeFriends = new List<GameObject>();

    private void Awake()
    {
        FriendInfo.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {

    }

    private void OnEnable()
    {
        Test();
        
        PlayerMyController.Instance.EnabledWindowCount++;
    }

    private void OnDisable()
    {

        foreach (GameObject tmp in closeFriends)
        {
            Destroy(tmp);
        }

        PlayerMyController.Instance.EnabledWindowCount--;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyValuePair<int, string> friend in PlayerInfo.friends)
        {
            bool addFriend = true;
            foreach (GameObject tmp in closeFriends)
            {
                if (tmp.name.Equals(friend.Value))
                {
                    addFriend = false;
                }
            }

            if(addFriend)
            {
                MessageBox.Show("online friends count: " + PlayerInfo.friends.Count);

                closeFriends.Add(GameObject.Instantiate(FriendInfo));
                closeFriends[closeFriends.Count - 1].name = friend.Value;
                closeFriends[closeFriends.Count - 1].transform.SetParent(transform, false);
                closeFriends[closeFriends.Count - 1].SetActive(true);
                var Textvalue = closeFriends[closeFriends.Count - 1].GetComponentInChildren<Text>();
                Textvalue.text = friend.Value;

                // bind a click event
                button = closeFriends[closeFriends.Count - 1].GetComponent<Button>();
                button.onClick.AddListener(Click);
            }
            
        }
    }

    void Test()
    {
        //Debug.Log(PlayerInfo.friends.Count);

        MessageBox.Show("online friends count: " + PlayerInfo.friends.Count);

        foreach (KeyValuePair<int, string> friend in PlayerInfo.friends)
        {
            closeFriends.Add(GameObject.Instantiate(FriendInfo));
            closeFriends[closeFriends.Count - 1].name = friend.Value;
            closeFriends[closeFriends.Count - 1].transform.SetParent(transform, false);
            closeFriends[closeFriends.Count - 1].SetActive(true);
            var Textvalue = closeFriends[closeFriends.Count - 1].GetComponentInChildren<Text>();
            Textvalue.text = friend.Value;

            // bind a click event
            button = closeFriends[closeFriends.Count - 1].GetComponent<Button>();
            button.onClick.AddListener(Click);
        }
    }

    public void Click()
    {
        Debug.Log("Chat with " + this.GetComponentInChildren<Text>().text);
        PlayerInfo.chatName = this.GetComponentInChildren<Text>().text;

        MessageBox.Show("currently chat with " + PlayerInfo.chatName);
    }
}