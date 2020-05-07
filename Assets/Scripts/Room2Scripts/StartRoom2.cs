//StartRoom2.cs
//Class to intialise the second room when the player enters it
//By Jaiqi Fan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoom2 : MonoBehaviour
{
    public GameObject TargetDoor;
    public GameObject oldRoomnameCode;
    public GameObject newRoomnameCode;

    private bool animationPlayed = false;

    void OnTriggerEnter(Collider other) //If player enters room then play animation and reset room code
    {
        if (other.name == "FPS" && !animationPlayed)
        {
            animationPlayed = true;
            oldRoomnameCode.SetActive(false);
            newRoomnameCode.SetActive(true);
            TargetDoor.gameObject.GetComponent<Animation>().Play("R2D1moveup");

        }

    }

  
}
