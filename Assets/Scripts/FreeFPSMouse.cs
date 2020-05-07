//FreeMouse.cs
//A class to deal with locking and unlocking the mouse for interacting with UI but locking the mouse
//to allow ease of player looking around
//By Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class FreeFPSMouse : MonoBehaviour
{
    public bool freeMouse = true;
    private bool lastMouseMode = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //If escape button pressed the free the mouse 
        {
            freeMouse = true;
            updateMouse();
        }

        if (freeMouse == !lastMouseMode) //If mouse mode changed update the mouse
        {
            updateMouse();
        }

        if(Input.GetKeyDown(KeyCode.L)) //If L pressed lock the mouse
        {
            freeMouse = false;
            updateMouse();
        }
    }
    private void updateMouse() //Method to update mouse mode
    {
        if (freeMouse == !lastMouseMode) //If mouse mode changed
        {
            lastMouseMode = freeMouse; //Update mouse mode
            GetComponent<FirstPersonController>().enabled = !freeMouse; //Toggle player controller
            GetComponent<CharacterController>().enabled = !freeMouse; //Toggle charectoe controller to allow for mouse movement without changing player position or movement
            if (freeMouse) //If set to free the mouse
            {
                Cursor.lockState = CursorLockMode.None; //Unlock the mouse
                Cursor.visible = true; //Make the mosuse invisible
            }
            else //If mouse to be locked
            {
                Cursor.visible = false; //Set mouse invisible
                Cursor.lockState = CursorLockMode.Locked; //Lock the mouse in place
            }

        }

    }

    public void setMouseMode(bool mouseMode) //Method to set mouse mode to desired mode
    {
        freeMouse = mouseMode;
    }

}