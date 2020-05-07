//PushRedButton.cs
//A class for pressing the red button
//By Jaiqi Fan
//Sound and switch to rays by Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRedButton : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool pushredbutton = false;
    bool ismousedown;

    private GetRaycast myRay;
    private bool mode = false;

    private FMOD.Studio.EventInstance buttonClickSound;

    Transform soundEmitter;

    void Start()
    {
        //Get player looking variable
        myRay = GetComponent<GetRaycast>();

        //Intialising button click event and it's position
        buttonClickSound = FMODUnity.RuntimeManager.CreateInstance("event:/Room1/SFX/ButtonClick");

        soundEmitter = transform.Find("SoundEmitter");

        buttonClickSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundEmitter));
    }

    // Update is called once per frame
    void Update()
    {

        if (mode != myRay.raycast) //If player looking state changed
        {
            if (myRay.raycast) //Set player looking
            {
                mode = true;
            }
            else   //Otherwise set player not looking
            {
                mode = false; ;
            }
        }

        if (mode && Input.GetMouseButtonDown(0)) //If player looking and mouse clicked run mouse click
        {
            OnMouseClick();
        }
        if (pushredbutton && Input.GetMouseButtonUp(0)) //If button pressed and mouse released run raise mouse
        {
            OnMouseRaise();
        }
    }

    public void OnMouseClick() //On mouse click play button click sound, play animation for button press and set as pressed
    {
        buttonClickSound.start();
        this.gameObject.GetComponent<Animation>().Play();
        pushredbutton = true;
    }
    public void OnMouseRaise() //If mouse unclicked then reset button press
    {
        pushredbutton = false;
    }

}