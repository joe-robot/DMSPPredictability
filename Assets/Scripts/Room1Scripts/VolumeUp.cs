//VolumeUp.cs
//Class to increase the volume of the wind as well as set flag position
//By Jaiqi Fan
//Sound and switch to ray by Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeUp : MonoBehaviour
{
    public static int countVolumeLevel = 1;
    //bool mouseEnterObj = false;
    public GameObject hinttext_volumeup;
    public GameObject level1Collider;
    public GameObject level2Collider;
    public GameObject level3Collider;
    public GameObject windflag1;
    public GameObject windflag2;

    //Ray cast mode
    private GetRaycast myRay;
    private bool mode = false;

    //Fmod event
    private FMOD.Studio.EventInstance buttonClickSound;

    private Transform soundEmitter;



    // Start is called before the first frame update
    void Start()
    {
        //Get player looking component
        myRay = GetComponent<GetRaycast>();

        //Initialising button click sound and setting it in 3D space
        buttonClickSound = FMODUnity.RuntimeManager.CreateInstance("event:/Room1/SFX/ButtonClick");

        buttonClickSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
    }

    // Update is called once per frame
    void Update()
    {
        if(CameraSetup.WindDirecUp == true && OpenSpeaker.iswindopen == true) //IF wind up and open run wind up
        {
            CaseVolumeLevelUp();
        }


        if (CameraSetup.WindDirecDown == true && OpenSpeaker.iswindopen == true) //IF wind down and open run wind down
        {
            CaseVolumeLevelDown();
        }


        if (CameraSetup.WindDirecLeft == true && OpenSpeaker.iswindopen == true) //IF wind left param and open run wind right (correction)
        {
            //CaseVolumeLevelLeft();
            CaseVolumeLevelRight();
        }



        if (CameraSetup.WindDirecRight == true && OpenSpeaker.iswindopen == true) //IF wind right param and open run wind left (correction)
        {
            CaseVolumeLevelLeft();
            //CaseVolumeLevelRight();
        }

        if(OpenSpeaker.iswindopen == false)  //If wind closed reset the flag
        {
            CaseVolumeLevelReset();

        }

        if (mode != myRay.raycast)  //If player look mode changed
        {
            if (myRay.raycast)  //If now looking at button then run look method
            {
                OnRayEnter();
            }
            else    //Otherwise run stopped looking
            {
                OnRayExit();
            }
        }

        if (mode && Input.GetMouseButtonDown(0))  //If button clicked while looking increase the volume
        {
            OnMouseClick();
        }


    }
    public void CaseVolumeLevelUp()  //if wind up set cloth position to up based on wind power
    {

        switch (countVolumeLevel)
        {
            case 1:
                /*level1Collider.SetActive(true);
                level2Collider.SetActive(false);
                level3Collider.SetActive(false);*/
                Vector3 up1 = new Vector3(0, 15, 0);
                windflag1.gameObject.GetComponent<Cloth>().externalAcceleration = up1;
                windflag2.gameObject.GetComponent<Cloth>().externalAcceleration = up1;
                break;
            case 2:
               /* level2Collider.SetActive(true);
                level1Collider.SetActive(false);
                level3Collider.SetActive(false);*/
                Vector3 up2 = new Vector3(0, 25, 0);
                windflag1.gameObject.GetComponent<Cloth>().externalAcceleration = up2;
                windflag2.gameObject.GetComponent<Cloth>().externalAcceleration = up2;
                break;
            case 3:
               /* level3Collider.SetActive(true);
                level1Collider.SetActive(false);
                level2Collider.SetActive(false);*/
                Vector3 up3 = new Vector3(0, 35, 0);
                windflag1.gameObject.GetComponent<Cloth>().externalAcceleration = up3;
                windflag2.gameObject.GetComponent<Cloth>().externalAcceleration = up3;
                break;

        }

    }


    public void CaseVolumeLevelReset() //If reset wind set flag to no acceleration positon
    {

       /* level1Collider.SetActive(false);
        level2Collider.SetActive(false);
        level3Collider.SetActive(false);*/
        Vector3 reset = new Vector3(0, 0, 0);
        windflag1.gameObject.GetComponent<Cloth>().externalAcceleration = reset;
        windflag2.gameObject.GetComponent<Cloth>().externalAcceleration = reset;


    }



    public void CaseVolumeLevelDown() //if wind down set cloth position to up based on wind power
    {

        switch (countVolumeLevel)
        {
            case 1:
                /*level1Collider.SetActive(false);
                level2Collider.SetActive(false);
                level3Collider.SetActive(false);*/
                Vector3 down1 = new Vector3(0, -10, 0);
                windflag1.gameObject.GetComponent<Cloth>().externalAcceleration = down1;
                windflag2.gameObject.GetComponent<Cloth>().externalAcceleration = down1;
                break;
            case 2:
                /*level2Collider.SetActive(false);
                level1Collider.SetActive(false);
                level3Collider.SetActive(false);*/
                Vector3 down2 = new Vector3(0, -20, 0);
                windflag1.gameObject.GetComponent<Cloth>().externalAcceleration = down2;
                windflag2.gameObject.GetComponent<Cloth>().externalAcceleration = down2;
                break;
            case 3:
                /*level3Collider.SetActive(false);
                level1Collider.SetActive(false);
                level2Collider.SetActive(false);*/
                Vector3 down3 = new Vector3(0, -30, 0);
                windflag1.gameObject.GetComponent<Cloth>().externalAcceleration = down3;
                windflag2.gameObject.GetComponent<Cloth>().externalAcceleration = down3;
                break;

        }

    }


    public void CaseVolumeLevelLeft() //if wind left set cloth position to up based on wind power
    {

        switch (countVolumeLevel)
        {
            case 1:
                /*level1Collider.SetActive(false);
                level2Collider.SetActive(false);
                level3Collider.SetActive(false);*/
                Vector3 left1 = new Vector3(10, 0, 0);
                windflag1.gameObject.GetComponent<Cloth>().externalAcceleration = left1;
                windflag2.gameObject.GetComponent<Cloth>().externalAcceleration = left1;
                break;
            case 2:
                /*level2Collider.SetActive(false);
                level1Collider.SetActive(false);
                level3Collider.SetActive(false);*/
                Vector3 left2 = new Vector3(20, 0, 0);
                windflag1.gameObject.GetComponent<Cloth>().externalAcceleration = left2;
                windflag2.gameObject.GetComponent<Cloth>().externalAcceleration = left2;
                break;
            case 3:
               /* level3Collider.SetActive(false);
                level1Collider.SetActive(false);
                level2Collider.SetActive(false);*/
                Vector3 left3 = new Vector3(30, 0, 0);
                windflag1.gameObject.GetComponent<Cloth>().externalAcceleration = left3;
                windflag2.gameObject.GetComponent<Cloth>().externalAcceleration = left3;
                break;

        }

    }

    public void CaseVolumeLevelRight() //if wind right set cloth position to up based on wind power
    {

        switch (countVolumeLevel)
        {
            case 1:
                /*level1Collider.SetActive(false);
                level2Collider.SetActive(false);
                level3Collider.SetActive(false);*/
                Vector3 right1 = new Vector3(-10, 0, 0);
                windflag1.gameObject.GetComponent<Cloth>().externalAcceleration = right1;
                windflag2.gameObject.GetComponent<Cloth>().externalAcceleration = right1;
                break;
            case 2:
               /* level2Collider.SetActive(false);
                level1Collider.SetActive(false);
                level3Collider.SetActive(false);*/
                Vector3 right2 = new Vector3(-20, 0, 0);
                windflag1.gameObject.GetComponent<Cloth>().externalAcceleration = right2;
                windflag2.gameObject.GetComponent<Cloth>().externalAcceleration = right2;
                break;
            case 3:
                /*level3Collider.SetActive(false);
                level1Collider.SetActive(false);
                level2Collider.SetActive(false);*/
                Vector3 right3 = new Vector3(-30, 0, 0);
                windflag1.gameObject.GetComponent<Cloth>().externalAcceleration = right3;
                windflag2.gameObject.GetComponent<Cloth>().externalAcceleration = right3;
                break;

        }

    }

    public void OnMouseClick() //On mouse click
    {
        buttonClickSound.start(); //Play button sound
        if (countVolumeLevel>=1 && countVolumeLevel<3) //If in bounds to increase then increase volume
        {
            countVolumeLevel++; //Increase volume

            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Room1Wind", countVolumeLevel); //Set wind sound paramter

           // Debug.Log(countVolumeLevel);
        }
            

    }

    public void OnRayEnter() //On player looking display button hint
    {
        hinttext_volumeup.SetActive(true);
        mode = true;

    }

    public void OnRayExit() //On player stopped looking stop displaying the button hint
    {
        hinttext_volumeup.SetActive(false);
        mode = false;
    }
}
