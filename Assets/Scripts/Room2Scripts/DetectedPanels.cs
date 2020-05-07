//DetectedPanels.cs
//Class to detect player has moved ip a room as to close the door behind them
//By Jaiqi Fan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedPanels : MonoBehaviour
{
    public GameObject TargetDoor;
    public GameObject displayuserInput1;
    public GameObject displayuserInput2;

    private bool animationPlayed = false;


    void OnTriggerEnter(Collider other) //if player enters the trigger for first time
    {
        if (other.name == "FPS" && !animationPlayed)
        {
            animationPlayed = true;   //Play animation
            TargetDoor.gameObject.GetComponent<Animation>().Play();
            displayuserInput1.SetActive(false);
            displayuserInput2.SetActive(true);


        }

    }

   
}
