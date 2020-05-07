//CameraSetup
//Main class for getting and interpreting QR codes using the ZXing library
//By Jaiqi Fan

using ZXing;
using ZXing.QrCode;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraSetup : MonoBehaviour
{
    //Initalising variables
    private WebCamTexture camTexture;
    private Rect screenRect;
    public GameObject text1;
    public GameObject text2;
    public GameObject RoomLight;
    public GameObject hintBoard;
    public GameObject closeButton;
    public GameObject hint_twolights;
    public GameObject hint_cardactivated;
    public GameObject wintext;
    public GameObject Speaker;
    public GameObject finaldoor;
    public Vector3 speakerpointLR;
    public Vector3 speakerpointUD;

    //private Image Boardimage;
    //public GameObject scanCamera;
    public static bool OpenTwoLights = false;
    public static bool CameraOpen = false;
    public static bool Cardpermission = false;
    public static bool WindDirecUp = false;
    public static bool WindDirecDown = false;
    public static bool WindDirecLeft = true;
    public static bool WindDirecRight = false;

    public int sampleNum = 0;

    private FMOD.Studio.EventInstance speakerMoveSound; //Sound event for speaker moving by JC



    void Start()
    {
        //Intialising the camera size and camera texture and sample rate
        screenRect = new Rect(0, 100, Screen.width/4, Screen.height/4);
        camTexture = new WebCamTexture(Screen.width, Screen.height, 11);
        camTexture.requestedHeight = Screen.height;
        camTexture.requestedWidth = Screen.width;
        if (camTexture != null) //Ensure camera texture exists
        {
            camTexture.Play();
        }
        else
        { 
            camTexture.Stop(); 
        }

        speakerpointLR = Speaker.gameObject.GetComponent<Transform>().position; //Get position of pseaker

        speakerMoveSound = FMODUnity.RuntimeManager.CreateInstance("event:/Room1/SFX/SpeakerMove"); //Initalising speaker sound event

    }

    public void clickCloseButton()  //Method to close hint board
    {
        hintBoard.SetActive(false);

    }

    void OnGUI()    //Method called for rendering GUI events
    {
        // drawing the camera on screen
        if (CameraOpen == true)
        {
            GUI.DrawTexture(screenRect, camTexture, ScaleMode.ScaleToFit);  //Drawing camera to screen
            if(sampleNum == 0)  //Checking QR only every 5 interations (optimised by JC)
            {
                //
                try
                {
                    IBarcodeReader barcodeReader = new BarcodeReader(); //Create barcode reader
                    // decode the current frame
                    var result = barcodeReader.Decode(camTexture.GetPixels32(),
                      camTexture.width, camTexture.height);         //Decoding the pixels
                    if (result != null)
                    {
                        Debug.Log("DECODED TEXT FROM QR: " + result.Text);  //Printing message from QR

                        if (result.Text == "Move")      //IF QR message is to move
                        {
                            text1.SetActive(false);         //Change hint box
                            text2.SetActive(true);
                            hintBoard.GetComponent<Image>().color = Color.white;    //Change hint box colour
                            closeButton.SetActive(true);            //Allow player to close hint box
                            GameObject.Find("FPS").GetComponent<FPSInputController>().enabled = true;   //Allow player to move
                            GameObject.Find("FPS").GetComponent<Mouselook>().enabled = true;
                            GameObject.Find("FPS").GetComponent<CharacterMotor>().enabled = true;

                        }

                        /*if (result.Text == "OpenTwoLights")
                        {
                            OpenTwoLights = true;
                            hint_twolights.SetActive(true);
                        }*/

                        if (result.Text == "KeyCardActivated")  //If keycard activated set card permissions
                        {
                            Cardpermission = true;
                            hint_cardactivated.SetActive(true);
                        }

                        if (result.Text == "Up")    //If up set speaker positon to up and play speaker move sound
                        {
                            Vector3 up = new Vector3(90, -90, -90);


                            Speaker.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(up.x, up.y, up.z);
                            Speaker.gameObject.GetComponent<Transform>().position = speakerpointUD;

                            if(!WindDirecUp)    //Only change if different from previous
                            {
                                speakerMoveSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(Speaker.transform));
                                speakerMoveSound.start();
                            }

                            WindDirecUp = true;
                            WindDirecDown = false;
                            WindDirecRight = false;
                            WindDirecLeft = false;
                        }


                        if (result.Text == "Down")  //If down set speaker position to down and play speaker move sound
                        {
                            Vector3 down = new Vector3(-90, -90, -90);

                            Speaker.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(down.x, down.y, down.z);
                            Speaker.gameObject.GetComponent<Transform>().position = speakerpointUD;

                            if (!WindDirecDown) //Only change if different from previous
                            {
                                speakerMoveSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(Speaker.transform));
                                speakerMoveSound.start();
                            }

                            WindDirecUp = false;
                            WindDirecDown = true;
                            WindDirecRight = false;
                            WindDirecLeft = false;


                        }

                        if (result.Text == "Right") //If down set speaker position to right and play speaker move sound
                        {
                            Vector3 right = new Vector3(0, 90, 0);

                            Speaker.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(right.x, right.y, right.z);
                            Speaker.gameObject.GetComponent<Transform>().position = speakerpointLR;

                            if (!WindDirecRight) //Only change if different from previous
                            {
                                speakerMoveSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(Speaker.transform));
                                speakerMoveSound.start();
                            }

                            WindDirecUp = false;
                            WindDirecDown = false;
                            WindDirecRight = true;
                            WindDirecLeft = false;

                        }


                        if (result.Text == "Left")  //If down set speaker position to right and play speaker move sound
                        {
                            Vector3 left = new Vector3(0, -90, 0);

                            Speaker.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(left.x, left.y, left.z);
                            Speaker.gameObject.GetComponent<Transform>().position = speakerpointLR;

                            if (!WindDirecLeft) //Only change if different from previous
                            {
                                speakerMoveSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(Speaker.transform));
                                speakerMoveSound.start();
                            }

                            WindDirecUp = false;
                            WindDirecDown = false;
                            WindDirecRight = false;
                            WindDirecLeft = true;

                        }


                        if (result.Text == "DeleteSystem")  //If delete system code display congratulations and open final wall
                        {
                            wintext.SetActive(true);
                            finaldoor.gameObject.GetComponent<Animation>().Play();
                        }



                    }
                }
                catch (Exception ex) { Debug.LogWarning(ex.Message); }
            }

            sampleNum++;    //Update sample number
            if(sampleNum > 5)   //If sample num bigger than 5 then set it to 0
            {
                sampleNum = 0;
            }

        }

    }

    /*static WebCamTexture myWebCam;
    // Start is called before the first frame update
    void Start()
    {
        if (myWebCam == null)
            myWebCam = new WebCamTexture();

        GetComponent<Renderer>().material.mainTexture = myWebCam;

        if (!myWebCam.isPlaying)
            myWebCam.Play();
    }*/
}
