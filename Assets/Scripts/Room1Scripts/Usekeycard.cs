//usekeycard.cs
//Class to use the keycard on the scanner
//By Jaiqi Fan
//Sound integration and ray by Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usekeycard : MonoBehaviour
{
    //Variables
    public GameObject pickObj;
    public GameObject origObj;
    //public GameObject targetObj;
    public GameObject hintText_use;
    public GameObject hintText_pick;
    public Material hintMaterial;
    private Material origMaterial;
    public GameObject wronghint;
    public GameObject room1wall;
    public GameObject room1door;
    public GameObject room1wallcollider;
    public GameObject moveupObj;
    public GameObject originaldoor;

    //public GameObject arealight;
    //public GameObject switchspotlight;

    public Transform start;
    public Transform end;
    float movespeed = 1f;

    bool mouseEnterObj = false;
    public static bool flame = true;
    public static bool playani = false;

    //Ray
    private GetRaycast myRay;

    //Sound events
    private FMOD.Studio.EventInstance keyCardCorrectSound;
    private FMOD.Studio.EventInstance keyCardIncorrectSound;
    private FMOD.Studio.EventInstance wallUpSound;

    Transform soundEmmitter;

    // Start is called before the first frame update
    void Start()
    {
        //Get original material of object
        origMaterial = origObj.gameObject.GetComponent<Renderer>().material;

        //Get ray for checking player looking
        myRay = GetComponent<GetRaycast>();

        //Intialising sund from scanner and setting position to scanner
        keyCardCorrectSound = FMODUnity.RuntimeManager.CreateInstance("event:/Room1/SFX/KeycardScanCorrect");
        keyCardIncorrectSound = FMODUnity.RuntimeManager.CreateInstance("event:/Room1/SFX/KeycardScanWrong");
        wallUpSound = FMODUnity.RuntimeManager.CreateInstance("event:/Room1/SFX/_WallLift");

        soundEmmitter = transform.Find("SoundEmmiter").transform;
        keyCardCorrectSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundEmmitter));
        keyCardIncorrectSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundEmmitter));

        //Set wall position to centre of the wall
        wallUpSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(room1wall.transform.Find("SoundEmitter")));

    }

    // Update is called once per frame
    void Update()
    {
        //If R pressed the player looking at the scanner, the keycard picked up and not activated
        if (Input.GetKeyDown(KeyCode.R) && (myRay.raycast == true) && (Pickkeycard.pickcard == true) && (CameraSetup.Cardpermission == false))
        {
            keyCardIncorrectSound.start();  //Play incorrect sound

            origObj.gameObject.SetActive(true); //Replace keycard

            pickObj.gameObject.SetActive(false);    //Hide picked up keycard
            flame = false;          //Ensure flame off
            hintText_use.SetActive(false);      //Stop displaying button press prompt
            Pickkeycard.pickcard = !Pickkeycard.pickcard;   //Set no longer picked keycard
            wronghint.SetActive(true);      //Display wrong card
            hintText_pick.SetActive(false);
            origObj.gameObject.GetComponent<Renderer>().material = origMaterial;

            

            //switchspotlight.SetActive(true);
            //arealight.SetActive(false);
        }


        
        //If animation set to play then move the wall
        if (playani ==true)
        {
            //moveupObj.transform.position= Vector3.MoveTowards(moveupObj.transform.position, end.position, movespeed * Time.deltaTime);
            moveupObj.transform.Translate(0, movespeed * Time.deltaTime,0);
        }

        //If R pressed the player looking at the scanner, the keycard picked up and is activated
        if (Input.GetKeyDown(KeyCode.R) && (myRay.raycast == true) && (Pickkeycard.pickcard == true) && (CameraSetup.Cardpermission == true))
        {
            keyCardCorrectSound.start(); //Play correct sound

            //Stop holding keycard
            pickObj.gameObject.SetActive(false);

            //Remove wall 1 collider
            room1wallcollider.SetActive(false);
            room1door.SetActive(false);
            originaldoor.SetActive(true);
            //Play wall animation
            playani = true;
            wallUpSound.start();    //Play wall move sound

     


            //room1wall.transform.position = Vector3.MoveTowards(start.position, end.position, speed * Time.deltaTime);
            //room1wall.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(0.075f, 7.17f, -13.89902f), speed * Time.deltaTime);
            //originaldoor.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(-2.64f, 4.8f, -38.56f), speed * Time.deltaTime);
        }

        if ((myRay.raycast == true) && (Pickkeycard.pickcard == true))  //If player looking and keycard picked up
        {

            hintText_use.SetActive(true);       //Display hint text
            //GameObject.Find("Keycard").GetComponent<Renderer>().material = hintMaterial;
        }
        else
        {
            hintText_use.SetActive(false);  //Otherwise stop displaying hint text
            //GameObject.Find("Keycard").GetComponent<Renderer>().material = origMaterial;
        }


    }

}
