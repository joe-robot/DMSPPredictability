//RestartGame.cs
//Class to resart the game if player fails/dies
//By Jaiqi Fan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public GameObject restartPanel;
    public GameObject FPS;
    public GameObject timer;
    public Transform Room1restartpoint;
    public Transform Room3restartpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.name =="FPS")  //If player in dead area display restart panel
        {
            restartPanel.SetActive(true);
        }
        
    }

    public void ResetFPS1() //Reset player to positon one
    {
        int movespeed = 1000000;
        FPS.transform.position = Vector3.MoveTowards(FPS.transform.position, Room1restartpoint.position, movespeed * Time.deltaTime);
    }

    public void ResetFPS2() //Rest player to position two and reset the timer
    {
        int movespeed = 1000;
        FPS.transform.position = Vector3.MoveTowards(FPS.transform.position, Room3restartpoint.position, movespeed * Time.deltaTime);
        restartPanel.SetActive(false);
        timer.SetActive(false);
        showtime.spendTime = 180f;

    }
}
