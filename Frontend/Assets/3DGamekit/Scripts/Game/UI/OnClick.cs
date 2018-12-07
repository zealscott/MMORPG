using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClick : MonoBehaviour
{
    public Button button;
    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(Click);
    }

    public void Click()
    {
        Debug.Log(this.GetComponentInChildren<Text>().text);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
