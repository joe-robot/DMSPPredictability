//ButtonFunction.cs
//Simple code to open and close the camera
//Camera open and close By Jaiqi Fan
//Sound implementation by Joe Cresswell

using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    //Sound events for camera open close
    private FMOD.Studio.EventInstance openCamera;
    private FMOD.Studio.EventInstance closeCamera;

    //Camera UI symbols
    public GameObject openCameraSymbol;
    public GameObject closeCameraSymbol;

    // Use this for initialization
    void Start()    //intialising sound events
    {
        openCamera = FMODUnity.RuntimeManager.CreateInstance("event:/UI/CameraOpen");
        closeCamera = FMODUnity.RuntimeManager.CreateInstance("event:/UI/CameraClose");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)) //Opening the camera by pressing the C key (by JC)
        {
            if(CameraSetup.CameraOpen == true)
            {
                CloseCamera();
            }
            else
            {
                OpenCamera();
            }
        }

    }



    public void OpenCamera()    //Method to open the camera
    {
        openCameraSymbol.SetActive(false);  //Set correct symbol
        closeCameraSymbol.SetActive(true);
        CameraSetup.CameraOpen = true;      //Open the camera
        openCamera.start();                 //Play open camera sound
        //Debug.Log("opensuccess!");

    }

    public void CloseCamera()   //Method to close the camera
    {   
        openCameraSymbol.SetActive(true);   //Set correct symbol
        closeCameraSymbol.SetActive(false);
        CameraSetup.CameraOpen = false;     //Close camera
        closeCamera.start();                //Play close camera sound
        //Debug.Log("closesuccess!");

    }

}
