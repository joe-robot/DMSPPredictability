//Exit.cs
//Class to exit back to the home screen
//By Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void exitMode() //Method to exit back to main menu called by the button
    {

        //Resetting all static variables to their intial values

        //Camera
        CameraSetup.OpenTwoLights = false;
        CameraSetup.CameraOpen = false;
        CameraSetup.Cardpermission = false;
        CameraSetup.WindDirecUp = false;
        CameraSetup.WindDirecDown = false;
        CameraSetup.WindDirecLeft = true;
        CameraSetup.WindDirecRight = false;

        //KeyCard
        Usekeycard.flame = true;
        Usekeycard.playani = false;


        //ight Manager
        LightManager.isredopen = false;
        LightManager.isblueopen = false;
        LightManager.isyellowopen = false;
        LightManager.isgreenopen = false;
        LightManager.updateLights = false;

        //Pick keycard
        Pickkeycard.pickcard = false;

        //Open Speaker
        OpenSpeaker.iswindopen = false;

        //Pick Snuffer
        PickSnuffer.pick = false;

        //Show Time
        showtime.spendTime = 180f;

        //Loading scene that loads the audio and goes back to the game
        SceneManager.LoadScene("LoadAudio", LoadSceneMode.Single);
    }
}
