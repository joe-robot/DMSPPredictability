//WindPlayerEffect.cs
//Class to effect the player controller based on wind direction and power
//By Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WindPlayerEffect : MonoBehaviour
{
    [SerializeField] GameObject FPSController;
    private CharacterController charController;
    private FirstPersonController controller;

    public bool windUp = false;
    public bool windDown = false;
    public bool windLeft = false;
    public bool windRight = false;

    public GameObject[] windObjects; //Objects for wind sounds

    private int windMode = 3; //Initally set wind mode to right

    // Start is called before the first frame update
    void Start()
    {
        //Get player contllers
        controller = FPSController.GetComponent<FirstPersonController>();
        charController = FPSController.GetComponent<CharacterController>();
    }

    // Update is called at fixed frame rate for physics operations
    void FixedUpdate()
    {
        if (OpenSpeaker.iswindopen)  //If speaker is on
        {
            int windAmount = VolumeUp.countVolumeLevel; //Get wind power
            if (CameraSetup.WindDirecUp)  //If wind upward
            {
                if(windMode!=0) //if wind mode has changed set it
                {
                    moveWind(0);
                }
                float heightMultiplier = windAmount == 3 ? 3.5f : 0.7f * windAmount; //Update gravity multiplier of player to reduced based on wind power
                controller.m_GravityMultiplier = 5f - heightMultiplier;
            }
            else if (CameraSetup.WindDirecDown) //If wind down
            {
                if (windMode != 1) //If wind mode changed update wind
                {
                    moveWind(1);
                }
                controller.m_GravityMultiplier = (5f + 0.4f * windAmount); //Set gravity to stronger if wind down
            }
            else if (CameraSetup.WindDirecLeft) //IF  wind left
            {
                if (windMode != 2) //If wind changed then update wind
                {
                    moveWind(2);
                }
                if (windAmount > 1 && !charController.isGrounded)   //Only move player if jump in wind and move player in direction of wind based on the power of the wind
                {
                    Vector3 leftMove = new Vector3(1f * (windAmount - 1), 0, 0);
                    charController.Move(leftMove * Time.fixedDeltaTime);
                }
            }
            else if (CameraSetup.WindDirecRight)     //If wind right
            {
                if (windMode != 3) //If wind changed then update wind
                {
                    moveWind(3);
                }
                if (windAmount > 1 && !charController.isGrounded) ///Only move player if jump in wind and move player in direction of wind based on the power of the wind
                {
                    Vector3 leftMove = new Vector3(-1f * (windAmount - 1), 0, 0);
                    charController.Move(leftMove * Time.fixedDeltaTime);
                }
            }
            else
            {
                controller.m_GravityMultiplier = 5f;  //Otherwise reset player gravity mutiplier
            }
        }
        else
        {
            controller.m_GravityMultiplier = 5f; //Otherwise reset gravity multiplier
        }
    }

    private void moveWind(int newWindPos) //If wind changed change position of wind sound objects
    {
        windObjects[windMode].SetActive(false);

        windObjects[newWindPos].SetActive(true);

        windMode = newWindPos;
    }
}
