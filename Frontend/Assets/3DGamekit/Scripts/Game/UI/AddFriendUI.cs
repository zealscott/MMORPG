using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit3D;
using UnityEngine.UI;
using Gamekit3D.Network;
using Common;

public class AddFriendUI : MonoBehaviour
{
    public GameObject RequestInfo;
    public Button agree;
    public Button disagree;

    public List<GameObject> addFriends = new List<GameObject>();


    private void Awake()
    {
        RequestInfo.SetActive(false);
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

        foreach (GameObject tmp in addFriends)
        {
            Destroy(tmp);
        }

        PlayerMyController.Instance.EnabledWindowCount--;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (string request in PlayerInfo.friendRequest)
        {
            bool addRequest = true;
            foreach (GameObject tmp in addFriends)
            {
                if (tmp.name.Equals(request))
                {
                    addRequest = false;
                }
            }

            if(addRequest)
            {
                //MessageBox.Show("online friends count: " + PlayerInfo.friends.Count);

                addFriends.Add(GameObject.Instantiate(RequestInfo));
                addFriends[addFriends.Count - 1].name = request;
                addFriends[addFriends.Count - 1].transform.SetParent(transform, false);
                addFriends[addFriends.Count - 1].SetActive(true);
                var Textvalue = addFriends[addFriends.Count - 1].GetComponentInChildren<Text>();
                Textvalue.text = request;

                // bind a click event
                foreach(Button buttonTmp in addFriends[addFriends.Count - 1].GetComponents<Button>())
                {
                    if (buttonTmp.name.Equals("agree"))
                    {
                        agree = buttonTmp;
                        agree.onClick.AddListener(delegate () {
                            Debug.Log("agree add friend: " + request);
                            Destroy(addFriends[addFriends.Count - 1]);
                            PlayerInfo.friendRequest.Remove(request);
                            CAddFriend msg = new CAddFriend()
                            {
                                success = true,
                                friendName = request
                            };
                            MyNetwork.Send(msg);
                            PlayerInfo.friends.Add(request);
                        });
                    }
                    else if (buttonTmp.name.Equals("disagree"))
                    {
                        disagree = buttonTmp;
                        disagree.onClick.AddListener(delegate () {
                            Debug.Log("disagree add friend: " + request);
                            Destroy(addFriends[addFriends.Count - 1]);
                            PlayerInfo.friendRequest.Remove(request);
                            CAddFriend msg = new CAddFriend()
                            {
                                success = false,
                                friendName = request
                            };
                            MyNetwork.Send(msg);
                        });
                    }
                }
            }
            
        }
    }

    void Test()
    {
        // test
        //List<string> test = new List<string>();
        //test.Add("123");

        //foreach (string request in test)
        foreach (string request in PlayerInfo.friendRequest)
        {
            addFriends.Add(GameObject.Instantiate(RequestInfo));
            addFriends[addFriends.Count - 1].name = request;
            addFriends[addFriends.Count - 1].transform.SetParent(transform, false);
            addFriends[addFriends.Count - 1].SetActive(true);
            var Textvalue = addFriends[addFriends.Count - 1].GetComponentInChildren<Text>();
            Textvalue.text = request;

            // bind a click event
            foreach (Button buttonTmp in addFriends[addFriends.Count - 1].GetComponentsInChildren<Button>())
            {
                //Debug.Log("bind button " + buttonTmp.name);
                if (buttonTmp.name.Equals("agree"))
                {
                    agree = buttonTmp;
                    agree.onClick.AddListener(delegate () {
                        Debug.Log("agree add friend: " + request);
                        Destroy(addFriends[addFriends.Count - 1]);
                        PlayerInfo.friendRequest.Remove(request);
                        CAddFriend msg = new CAddFriend()
                        {
                            success = true,
                            friendName = request
                        };
                        MyNetwork.Send(msg);
                        PlayerInfo.friends.Add(request);
                    });
                }
                else if (buttonTmp.name.Equals("disagree"))
                {
                    disagree = buttonTmp;
                    disagree.onClick.AddListener(delegate () {
                        Debug.Log("disagree add friend: " + request);
                        Destroy(addFriends[addFriends.Count - 1]);
                        PlayerInfo.friendRequest.Remove(request);
                        CAddFriend msg = new CAddFriend()
                        {
                            success = false,
                            friendName = request
                        };
                        MyNetwork.Send(msg);
                    });
                }
            }
        }
    }


}