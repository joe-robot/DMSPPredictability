//Pickkeycard.cs
//Class to pick up the keycard
//By Jaiqi Fan
//Sound and switch to ray by Joe

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickkeycard : MonoBehaviour
{
    //public GameObject pickObj;
    public GameObject displayObj;
    public Material hintMaterial;
    private Material origMaterial;
    public GameObject hintText_pick;
    public GameObject scannerSpotlight;
    bool mouseEnterObj = false;
    public static bool pickcard = false;

    private GetRaycast myRay;

    private FMOD.Studio.EventInstance objectPickUp;

    // Start is called before the first frame update
    void Start()
    {
        //intialis sound of picking up obkect
        objectPickUp = FMODUnity.RuntimeManager.CreateInstance("event:/Room1/SFX/PickUpObject");

        //The original material of keycard
        origMaterial = this.gameObject.GetComponent<Renderer>().material;

        //Getting the raycast to check player looking
        myRay = GetComponent<GetRaycast>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && (mouseEnterObj == true)&&(UseSnuffer.flame==false))  //If button pressed and player looking and candle extinguished then pick up keycard
        {
            objectPickUp.start();       //PLay pick up sound
            this.gameObject.SetActive(false);           //Remove keycard
            displayObj.gameObject.SetActive(true);      //Set display keycard to true
            pickcard = !pickcard;                       //Set keycard to picked up
            hintText_pick.SetActive(false);         //Stop displaying the hint
            scannerSpotlight.SetActive(true);       //Put spotlight over scanner
            this.gameObject.GetComponent<Renderer>().material = origMaterial;   //Set material to original material


        }

        if(mouseEnterObj != myRay.raycast)  //If player looking state changed
        {
            if(myRay.raycast)   //If player now looking at keycard then run player looking
            {
                OnRayEnter();
            }
            else    //Otherwise run player not looking
            {
                OnRayExit();
            }
        }

    }


    public void OnRayEnter()  //If player looking set as looking and change keycard material
    {
        if((pickcard == false) && (UseSnuffer.flame ==false))
        {
            mouseEnterObj = true;
            this.gameObject.GetComponent<Renderer>().material = hintMaterial;
            hintText_pick.SetActive(true);

        }




    }

    public void OnRayExit() //If player stopped looking unset as looking and reset keycard material
    {
        this.gameObject.GetComponent<Renderer>().material = origMaterial;
        mouseEnterObj = false;
        hintText_pick.SetActive(false);
    }


}
