//VolumeDown.cs
//Class to reduce volume of wind
//By Jaiqi Fan
//Sound and Ray switch by Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeDown : MonoBehaviour
{
    //bool mouseEnterObj = false;
    public GameObject hinttext_volumedown;

    private GetRaycast myRay;
    private bool mode = false;

    private FMOD.Studio.EventInstance buttonClickSound;

    // Start is called before the first frame update
    void Start()
    {
        //Getting if player looking at button
        myRay = GetComponent<GetRaycast>();

        //Button click sound and setting 3D positon of it
        buttonClickSound = FMODUnity.RuntimeManager.CreateInstance("event:/Room1/SFX/ButtonClick");

        buttonClickSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
    }

    // Update is called once per frame
    void Update()
    {
        if (mode != myRay.raycast)  //IF player look state changed
        {
            if (myRay.raycast) //If player started looking run looking method
            {
                OnRayEnter();
            }
            else   //If player stopped looking run stopped looking method
            {
                OnRayExit();
            }
        }

        if(mode && Input.GetMouseButtonDown(0))  //If player looking and mouse clicked play clicked mehtod
        {
            OnMouseClick();
        }

    }



    public void OnMouseClick()
    {
        buttonClickSound.start();  //Play clicked sound
        if (VolumeUp.countVolumeLevel >= 2 && VolumeUp.countVolumeLevel < 4) //If volume in bounds to turn down
        {
            VolumeUp.countVolumeLevel--; //Reduce volume
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Room1Wind", VolumeUp.countVolumeLevel); //Set volume parameter
        }


    }

    public void OnRayEnter() //On player looking display hint
    {
        hinttext_volumedown.SetActive(true);
        mode = true;

    }

    public void OnRayExit() //On player stopped looking stop displaying the hint
    {
        hinttext_volumedown.SetActive(false);
        mode = false;
    }
}
