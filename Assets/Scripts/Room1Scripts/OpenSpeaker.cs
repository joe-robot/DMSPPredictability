//OpenSpeaker.cs
//Simple Class to turn on and off speaker on button press
//By Jaiqi Fan
//Raycast and sound by Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSpeaker : MonoBehaviour
{
    int count = 0;
    //bool mouseEnterObj = false;
    public GameObject hinttext_openspeaker;
    public static bool iswindopen = false;
    private GetRaycast myRay;
    private bool mode = false;

    private FMOD.Studio.EventInstance buttonClickSound;
    // Start is called before the first frame update
    void Start()
    {
        myRay = GetComponent<GetRaycast>(); //Getting raycast to detect player looking

        buttonClickSound = FMODUnity.RuntimeManager.CreateInstance("event:/Room1/SFX/ButtonClick"); //Initialising the button click sound

        buttonClickSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform)); //Playing button sound in space
    }

    // Update is called once per frame
    void Update()
    {
        if(mode != myRay.raycast)   //If player just started or just stopped looking at button
        {
            if(myRay.raycast)   //Run player look method
            {
                OnRayEnter();
            }
            else    //Run player stopped looking method
            {
                OnRayExit();
            }
        }

        if(mode && Input.GetMouseButtonDown(0)) //If player looking and mouse clicked run click method
        {
            OnMouseClick();
        }
    }

    public void OnMouseClick()  //If mouse clicked while looking at the object
    {
        buttonClickSound.start();   //PLay button sound
        count++;
        if (count % 2 != 0) //Turn on or off the speaker depending on numbers of times it has been pressed
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Room1Wind", VolumeUp.countVolumeLevel);   //set wind volume
            iswindopen = true;  //Set wind to open

        }
        else   //If turning off then stop wind
        {
            iswindopen = false;
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Room1Wind", 0);   //Stop wind sound
        }
    }

    public void OnRayEnter()    //If looking display hint
    {
        hinttext_openspeaker.SetActive(true);
        mode = true;

    }

    public void OnRayExit() //IF stopped looking stop displaying the hint
    {
        hinttext_openspeaker.SetActive(false);
        mode = false;
    }
}
