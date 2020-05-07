//PushBlueButton.cs
//A class for pressing the blue button
//By Jaiqi Fan
//Sound and switch to rays by Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlueButton : MonoBehaviour
{
    public static bool pushbluebutton = false;
    private bool mode = false;
    private GetRaycast myRay;

    private FMOD.Studio.EventInstance buttonClickSound;

    Transform soundEmitter;

    // Start is called before the first frame update
    void Start()
    {
        //Get player looking variable
        myRay = GetComponent<GetRaycast>();

        //Initalising button clicked event and setting it's positon on the button
        buttonClickSound = FMODUnity.RuntimeManager.CreateInstance("event:/Room1/SFX/ButtonClick");

        soundEmitter = transform.Find("SoundEmitter");

        buttonClickSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundEmitter));


    }

    // Update is called once per frame
    void Update()
    {

        if (mode != myRay.raycast) //If player looking state changed
        {
            if (myRay.raycast) //If player now looking set as looking
            {
                mode=true;
            }
            else  //Otherwise set as not looking
            {
                mode = false;
            }
        }

        if (mode && Input.GetMouseButtonDown(0)) //If looking and mouse clicked run mouse clicked
        {
            OnMouseClick();
        }
        if(pushbluebutton && Input.GetMouseButtonUp(0)) //if button pressed and mouse depressed the run mouse raise
        {
            OnMouseRaise();
        }
    }

    public void OnMouseClick() //On mouse click play button click sound, play animation for button press and set as pressed
    {
        buttonClickSound.start();
        this.gameObject.GetComponent<Animation>().Play();
        pushbluebutton = true;
    }
    public void OnMouseRaise() //Reset pressed if mouse released
    {
        pushbluebutton = false;
    }
}
