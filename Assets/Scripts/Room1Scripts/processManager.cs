//processManager.cs
//simple method to deactive start panel when button pressed
//By Jaiqi Fan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class processManager : MonoBehaviour
{
    public GameObject startPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickEnter()    //If clicked deactivate start panel
    {
        startPanel.SetActive(false);
    }
}
