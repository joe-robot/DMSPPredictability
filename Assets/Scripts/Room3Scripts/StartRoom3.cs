//StartRoom3.cs
//Class to run required variables to start the thrid room
//By Jaiqi Fan
//Sound implementation by Joe Cresswell


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoom3 : MonoBehaviour
{
    public GameObject TargetDoor;
    public GameObject Timer;
    public GameObject oldRoomnameCode1;
    public GameObject oldRoomnameCode2;
    public GameObject newRoomnameCode;
    public GameObject roomcodepanel;
    public GameObject commandsmanager;
    public GameObject processbar;
    int count = 0;

    private FMOD.Studio.EventInstance RoomAtomos;

    // Start is called before the first frame update
    void Start()
    {
        //intitialising sound event
        RoomAtomos = FMODUnity.RuntimeManager.CreateInstance("event:/Room3/Atmos/Atmos");
    }

    void OnTriggerEnter(Collider other) //On player enter trigger
    {
        count++; //Increment count
        if (other.name == "FPS" && count == 1) //if first time player enetering
        {
            commandsmanager.gameObject.GetComponent<RandomCommand>().enabled = true; //Start random commands
            Timer.SetActive(true); //Start timer
            oldRoomnameCode1.SetActive(false);
            oldRoomnameCode2.SetActive(false);
            newRoomnameCode.SetActive(true); //Set room code
            //roomcodepanel.SetActive(true);
            processbar.SetActive(true);  //Show progress bar
            TargetDoor.gameObject.GetComponent<Animation>().Play(); //Close door behind the player

        }
        if (other.name == "FPS" && count > 1) //If player entering the reset the timer
        {
            Timer.SetActive(true);
        }

    }
}
