//checkCodeInput.cs
//class that gets number key input and checks the input is correct
//By Joe Cresswell

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCodeInput : MonoBehaviour
{
    //The expected arrays
    private int[] expArray;
    //The actual array of what the user entered
    private int[] actArray;

    private string[] notesArray;

    //Fmod event reference to parameters also
    [FMODUnity.EventRef]
    public string keyPadEvent = "";
    FMOD.Studio.EventInstance keyPadSound;
    FMOD.Studio.PARAMETER_ID noteTypeParam;

    public bool oppositeMode;
   
    private bool checkVals;

    private int numPress = 0;
    private int lastRawInput;
    private int lastInput;
    private bool newVal;

    // Start is called before the first frame update
    void Start()
    {
        checkVals = false;
        oppositeMode = false;

        notesArray = new string[4] { "Play_A3", "Play_C4", "Play_E4", "Play_G4" };  //Array of notes to play

        //Expected array pattern
        expArray = new int[4] { 0, 1, 2, 3 };

        //Intially set actual array out of number bounds so inccorrect no matter what the expected is
        actArray = new int[4] { 5, 5, 5, 5 };
        lastInput = 5;

        //intilising the keypad sound event
        keyPadSound = FMODUnity.RuntimeManager.CreateInstance(keyPadEvent);

        //Intialising the keypad sound parameter
        FMOD.Studio.EventDescription keyPadNoteDescription;
        keyPadSound.getDescription(out keyPadNoteDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION keyPadNoteParameterDescription;
        keyPadNoteDescription.getParameterDescriptionByName("Parameter 1", out keyPadNoteParameterDescription);
        noteTypeParam = keyPadNoteParameterDescription.id;
    }

    // Update is called once per frame
    void Update() 
    {
        if (checkNumPresses()) //Check for number button presses
        {
            playNote(numPress); //PLay the note
        }
    }


    private bool checkNumPresses()  //Checking which number key is pressed down
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) //Check for buttton 1 press
        {
            numPress = 0;
            return true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) //Check for button 2 press
        {
            numPress = 1;
            return true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) //check for button 3 press
        {
            numPress = 2;
            return true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) //check for button 4 press
        {
            numPress = 3;
            return true;
        }

        return false; //Otherwise return false
    }


    private void playNote(int noteVal)  //Playing note and checking if correct pattern entered
    {
        if (noteVal < notesArray.GetLength(0) && noteVal > -1)  //Check input in range
        {
            lastRawInput = noteVal;
            if (oppositeMode)           //Reversing direction if in reverse mode
            {
                noteVal = 3 - noteVal;
            }
            //!!!!Post Sound Here!!!
            keyPadSound.setParameterByID(noteTypeParam, noteVal); // Set parameter for keypad note pressed

            keyPadSound.start();        //Starting the keypad event playing

            FMODUnity.RuntimeManager.AttachInstanceToGameObject(keyPadSound, this.transform, GetComponent<Rigidbody>()); //Attaching event to gameobject


            for (int i = 0; i < 3; i++) //Adding new value array
            {
                actArray[i] = actArray[i + 1];
            }
            actArray[3] = noteVal;

            checkArrays();  //Comparing actual and expexted array

            lastInput = noteVal;
            newVal = true;
        }
    }

    private void checkArrays()  //Comparing expected and actual array
    {
        for (int i = 0; i < 4; i++)
        {
            if (actArray[i] == expArray[i])
            {
                checkVals = true;
            }
            else
            {
                checkVals = false;
                break;
            }
        }
    }

    public bool checkCorrect()  //External system can check if code entered correctly
    {
        if (checkVals)
        {
            checkVals = false;
            return true;
        }
        return false;
    }

    public void setReverse()    //External system can set it to reverse the code
    {
        oppositeMode = true;
    }

    public bool checkNewVal()   //External system can get the most recent value
    {
        if (newVal)
        {
            newVal = false;
            return true;
        }
        return false;
    }

    public int getNoteVal()     //External system can get last note input
    {
        return lastInput;
    }

    public int getRawNoteVal()  //External system can get raw input
    {
        return lastRawInput;
    }

}
