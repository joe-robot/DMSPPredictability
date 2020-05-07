//LightManager.cs
//Class to manage the lights
//By Jaiqi Fan
//adjustments for puzzle By Joe Cresswell


using UnityEngine;

public class LightManager : MonoBehaviour
{
    public GameObject room1WhiteLight;
    public static bool lightSwitches = false;
    public GameObject activeLight;
    public static GameObject nextLight;
    public static bool isredopen = false;
    public static bool isblueopen = false;
    public static bool isyellowopen = false;
    public static bool isgreenopen = false;
    public static bool updateLights = false;

    public GameObject room1door;
    public GameObject room1fakewall;


    // Start is called before the first frame update
    void Start()
    {
        activeLight = room1WhiteLight;  //Initally set white light
    }

    // Update is called once per frame
    void Update()
    {
        if (UseSnuffer.flame == false)  //If snuffer used then turn on the lights
        {
            lightSwitches = true;
        }

        // multipule lights inital code to set multiple lights on (not used now)
        /*if ((lightSwitches == true) && (CameraSetup.OpenTwoLights == true))
        {
            GameObject.Find("lightSwitch_Red").GetComponent<RedLightController>().enabled = false;
            GameObject.Find("lightSwitch_Red").GetComponent<MultiLightController>().enabled = true;

            GameObject.Find("lightSwitch_Blue").GetComponent<BlueLightController>().enabled = false;
            GameObject.Find("lightSwitch_Blue").GetComponent<MultiLightController>().enabled = true;

            GameObject.Find("lightSwitch_Yellow").GetComponent<YellowLightController>().enabled = false;
            GameObject.Find("lightSwitch_Yellow").GetComponent<MultiLightController>().enabled = true;

            GameObject.Find("lightSwitch_Green").GetComponent<GreenLightController>().enabled = false;
            GameObject.Find("lightSwitch_Green").GetComponent<MultiLightController>().enabled = true;
        }*/

        if (updateLights)   //If lights updated
        {
            
            ToggleLights(nextLight);    //Toggle lights with next light value

            updateLights = false;       //Reset update lights
            //if((GameObject.Find("Red Light") == true) && (GameObject.Find("Green Light") == true) && (GameObject.Find("Blue Light") == false) && (GameObject.Find("Yellow Light") == false))
            if ((GameObject.Find("Red Light") == true) || (GameObject.Find("Green Light") == true)) //Make door visible for red or green light
            {

                room1door.SetActive(true);
                room1fakewall.SetActive(false);

            }
            else  //Otherwise make door invisible
            {

                room1door.SetActive(false);
                room1fakewall.SetActive(true);

            }
        }
        if(Usekeycard.playani ==true)   //If keycard used and animation playing make door visible
        {
            room1door.SetActive(false);
            room1fakewall.SetActive(false);

        }
    }


    private void ToggleLights(GameObject newActiveLight)    //Method to toggle lights by JC
    {
        if (GameObject.ReferenceEquals(activeLight,newActiveLight))   //If toggling the same light as previously turn off the light
        {
            activeLight.SetActive(false);
            room1WhiteLight.SetActive(true);
            activeLight = room1WhiteLight;
        }
        else    //If toggling a different light turn that on and the other off
        {
            activeLight.SetActive(false);
            newActiveLight.SetActive(true);
            activeLight = newActiveLight;
        }
    }
}
