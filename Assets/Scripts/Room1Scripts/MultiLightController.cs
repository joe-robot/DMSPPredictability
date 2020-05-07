//MultiLightController.cs
//Class to deal with light switch presses
//By Jaiqi Fan
//Raycast mode and sound by Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLightController : MonoBehaviour
{
    //Variables
    int count = 0;
    public GameObject thislight;
    public GameObject roomlight;
    public GameObject hintText_click;
    private GetRaycast myRay;
    private bool currentMode = false;

    //SOund Variables
    private FMOD.Studio.EventInstance buttonClickSound;
    private Transform soundEmitter;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        //Getting ray reciever component, which will have a raycast variable true if the player is looking at the object
        myRay = GetComponent<GetRaycast>();

        //Intialising button click sound
        buttonClickSound = FMODUnity.RuntimeManager.CreateInstance("event:/Room1/SFX/ButtonClick");

        //Setting sound position
        soundEmitter = gameObject.transform.Find("SoundEmitter").transform;
        soundEmitter.position = GetComponentInChildren<MeshRenderer>().bounds.center;
        buttonClickSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundEmitter));
    }

    // Update is called once per frame
    void Update()
    {
        if(myRay.raycast!=currentMode)  //If beam entered or exited the object for first time
        {
            if(myRay.raycast)   //If beam entered the run ray enter method
            {
                OnRayEnter();
            }
            else     //Otherwise run ray exit method
            {
                OnRayExit();
            }
        }

        if(currentMode && Input.GetMouseButtonDown(0))  //If ray in component check for mouse click
        {
            OnMouseClick();

            
        }
    }

    public void OnMouseClick()  //On mouse click method
    {
        buttonClickSound.start();       //Starting the button click event playing


        if (LightManager.lightSwitches == true) //Set light on if light switched
        {
            /*count++;
            if (count % 2 != 0)
            {
                thislight.SetActive(true);
                roomlight.SetActive(false);
                LightManager.updateLights = true;
                
            }
            else
            { 
                thislight.SetActive(false);
            
            }*/

            //LightManager.toggleLights(roomlight);
            LightManager.nextLight = thislight;
            LightManager.updateLights = true;

        }
    }

    public void OnRayEnter()    //If player looking at switch display hint text
    {
        if (LightManager.lightSwitches == true)
        {
            hintText_click.SetActive(true);
        }
        currentMode = true;

    }

    public void OnRayExit() //If player stops looking at switch stop displaying hint text
    {

        if (LightManager.lightSwitches == true)
        {
            hintText_click.SetActive(false);
        }
        currentMode = false;

    }
}
