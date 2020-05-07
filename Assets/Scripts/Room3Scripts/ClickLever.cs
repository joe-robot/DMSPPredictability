//ClickLever.cs
//Class to deal with player lever presses
//By Jaiqi Fan
//Sound implementation by Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLever : MonoBehaviour
{
    public GameObject hinttext_lever;
    bool mouseEnterObj = false;
    public static bool leverleft;
    public static bool leverright;

    private FMOD.Studio.EventInstance leverClickSound;

    Transform soundEmitter;

    private GetRaycast myRay;
    // Start is called before the first frame update
    void Start()
    {
        //Getting player look state
        myRay = GetComponent<GetRaycast>();

        //Intialising click sound and location of sound
        leverClickSound = FMODUnity.RuntimeManager.CreateInstance("event:/Room3/SFX/LeverClick");

        soundEmitter = transform.Find("SoundEmitter");

        leverClickSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundEmitter));
    }

    // Update is called once per frame
    void Update()
    {
        //If player lookstate canged
        if (mouseEnterObj != myRay.raycast)
        {
            if (myRay.raycast) //If now looking run looking method
            {
                OnRayEnter();
            }
            else   //If not looking run not looking method
            {
                OnRayExit();
            }
        }

        leverleft = false;  //Reset lever press
        leverright = false;
        if (Input.GetKeyDown(KeyCode.Alpha1) && (mouseEnterObj == true)) //If left number pressed and looking at lever
        {
            leverClickSound.start(); //play lever click sound
            this.gameObject.GetComponent<Animation>().Play("leverleft"); //Player lever left animation
            leverleft = true; //Set to left
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && (mouseEnterObj == true)) //If right number pressed and looking at lever
        {
            leverClickSound.start(); //play lever click sound
            this.gameObject.GetComponent<Animation>().Play("leverright"); //Player lever right animaiton
            leverright = true; //set to right
        }

    }

    public void OnRayEnter() //If looking display button press hints
    {
        hinttext_lever.SetActive(true);
        mouseEnterObj = true;
        

    }

    public void OnRayExit() //If stopped looking remove button press hints
    {
        hinttext_lever.SetActive(false);
        mouseEnterObj = false;

    }
}
