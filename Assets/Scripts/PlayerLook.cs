//PlayerLook.cs
//A class to use a raycast to detect what the player is looking at as the mouse won't work correctly
//in webGl
//By Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public GameObject emptyObj;
    private GameObject lastHitObject;
    private bool assignObj = false;
    // Update is called once per frame
    void Update()
    {
        //Create raycast and checking if it hits a object
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit))
        {

            if(lastHitObject != hit.transform.gameObject) //If no longer hitting last hit object 
                {
                    if (assignObj) //If object already assigned
                    {
                        lastHitObject.GetComponent<GetRaycast>().rayExit(); //Exit previously set object
                        lastHitObject = emptyObj; //Reset last object hit
                        assignObj = false; //reset that no object hit
                    }
                }
            if (hit.transform.gameObject.CompareTag("Interactable")) //If object that is hit is tagged as interactable
            {
                if (lastHitObject != hit.transform.gameObject || !assignObj) //If object hit different to previous and has hit a object previously
                {
                    assignObj = true; //Set as has hit object
                    lastHitObject = hit.transform.gameObject; //Set last hit object variable
                    lastHitObject.GetComponent<GetRaycast>().rayEnter(); //Update raycast hit in hit object
                    
                }
            }
        }


    }
}
