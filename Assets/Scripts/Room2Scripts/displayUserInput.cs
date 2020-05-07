//displayUserInput.cs
//A class to display user input by lighting up panels for the input they enter
//By Jaiqi Fan and Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayUserInput : MonoBehaviour
{
    [SerializeField] GameObject checkUIObject;

    [SerializeField] Material offColour;
    [SerializeField] Material onColour;

    [SerializeField] GameObject disp1;
    [SerializeField] GameObject disp2;
    [SerializeField] GameObject disp3;
    [SerializeField] GameObject disp4;

    private GameObject[] displays;
    private float[] displayTimes;

    private checkCodeInput thisChecker;
    private float lightUpTime;

    // Start is called before the first frame update
    void Start()
    {
        displays = new GameObject[4] {disp1, disp2, disp3, disp4 };
        displayTimes = new float[4] { 0, 0, 0, 0 };
        lightUpTime = 1;
        thisChecker = checkUIObject.GetComponent<checkCodeInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thisChecker.checkNewVal())   //Checking user input value has changed
        {
            // int noteVal = thisChecker.getRawNoteVal();
            int noteVal = thisChecker.getNoteVal(); //Get note value from checker

            if(noteVal>-1 &&noteVal <4) //change display on if active
            {
                switchDisp(noteVal, true);
            }

        }

        for(int i=0; i<4; i++) //Iterate through displays and turn them off in a certain amoun to of time to being turned on
        {
            if(displayTimes[i]>0)
            {
                if((displayTimes[i]-=Time.deltaTime)<=0)
                {
                    switchDisp(i, false);
                    displayTimes[i] = 0;
                }
            }
        }

    }

    private void switchDisp(int dispNum, bool onOff) //Switch displays on and off by setting the colours
    {
        if(onOff)
        {
            displays[dispNum].GetComponent<MeshRenderer>().material = onColour;
            displayTimes[dispNum] = lightUpTime;
        }
        else
        {
            displays[dispNum].GetComponent<MeshRenderer>().material = offColour;
        }
    }
}
