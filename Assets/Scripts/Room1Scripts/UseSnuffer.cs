//UseSnuffer.cs
//Class to use the snuffer
//By Jaiqi Fan
//update to using rays by Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSnuffer : MonoBehaviour
{
    public GameObject pickObj;
    public GameObject targetObj;
    public GameObject hintText_use;
    public Material hintMaterial;
    private Material origMaterial;
    public GameObject roomlight;
    public GameObject arealight;
    public GameObject switchspotlight;
    public GameObject roomCode;

    private GetRaycast myRay;
    bool mouseEnterObj = false;
    public static bool flame = true;

    // Start is called before the first frame update
    void Start()
    {
        //Getting material
        origMaterial = GameObject.Find("Mesh417").GetComponent<Renderer>().material;
        //Ray class for check player looking
        myRay = GetComponent<GetRaycast>();
    }

    // Update is called once per frame
    void Update()
    {
        //If player looking and button pressed and snuffer picked up extinguish the flame
        if (Input.GetKeyDown(KeyCode.R) && (myRay.raycast == true) && (PickSnuffer.pick == true))
        {
            //Remove snuffer from player and table
            targetObj.gameObject.SetActive(false);
            pickObj.gameObject.SetActive(false);
            //Extingush flame
            flame = false;

            //Stop displaying the hint
            hintText_use.SetActive(false);
            PickSnuffer.pick = false;   //set to no linger picked up
            roomlight.SetActive(true);      //Set room lights
            roomCode.SetActive(true);      
            switchspotlight.SetActive(true);
            arealight.SetActive(false);
        }
        if ((myRay.raycast == true) && (PickSnuffer.pick == true))  //If player looking and snuffer picked up display hint to extingush
        {

            hintText_use.SetActive(true);
            GameObject.Find("Mesh417").GetComponent<Renderer>().material = hintMaterial;
        }
        else     //If player stopped looking stop displaying the hint
        {
            hintText_use.SetActive(false);
            GameObject.Find("Mesh417").GetComponent<Renderer>().material = origMaterial;
        }

        //Debug.Log(PickSnuffer.pick);
    }

   /* public void OnMouseEnter()
    {
        mouseEnterObj = true;



    }*/

    public void rayEnter()
    {
        mouseEnterObj = true;
    }

    public void rayExit()
    {
        mouseEnterObj = false;
    }

    //OnCollis

    /*public void OnMouseExit()
    {
        mouseEnterObj = false;

    }*/
}
