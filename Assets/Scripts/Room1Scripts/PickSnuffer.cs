//PickSnuffer.cs
//Class to pick up the snuffer object
//By Jaiqi Fan
//Sound and ray switch by Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSnuffer : MonoBehaviour
{
    //public GameObject pickObj;
    public GameObject displayObj;
    public Material hintMaterial;
    private Material origMaterial;
    public GameObject hintText_pick;
    bool mouseEnterObj = false;
    public static bool pick = false;
    private GetRaycast myRay;

    //Fmod variable
    private FMOD.Studio.EventInstance objectPickUp;

    // Start is called before the first frame update
    void Start()
    {
        //Intialise FMOD event
        objectPickUp = FMODUnity.RuntimeManager.CreateInstance("event:/Room1/SFX/PickUpObject");

        //Set original material
        origMaterial = this.gameObject.GetComponent<Renderer>().material;

        //Get raycast for player looking
        myRay = GetComponent<GetRaycast>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && (myRay.raycast == true)) //If player looking and e pressed pick up snuffer
        {
            objectPickUp.start();           //Play pick up sound
            displayObj.gameObject.SetActive(true);  //Set snuffer pick up to true
            pick = true;        //Set to picked up
            hintText_pick.SetActive(false); //Remove hint text
            this.gameObject.SetActive(false);

        }

        if(mouseEnterObj != myRay.raycast)  //If player look status changed
        {
            if (myRay.raycast)  //If looking run looking method
            {
                OnRayEnter();
            }
            else   //If no longer looking run that method
            {
                OnRayExit();
            }
        }


    }



   public void OnRayEnter()  //If player looking set as looking, dsplay hint and highlight the snuffer     {
        mouseEnterObj = true;
        this.gameObject.GetComponent<Renderer>().material = hintMaterial;
        hintText_pick.SetActive(true);

     }      public void OnRayExit()  //If player not looking set as not looking, stop displaying the hint and unhighlight the snuffer
    {
        mouseEnterObj = false;
        this.gameObject.GetComponent<Renderer>().material = origMaterial;
        hintText_pick.SetActive(false);     }


}
