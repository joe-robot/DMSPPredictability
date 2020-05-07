//RandomCommand.cs
//A class to give a random task to the player out of 4 possible
//By Jaiqi Fan
//Sound and adjustments by Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCommand : MonoBehaviour
{
    public GameObject[] Commands;
    private GameObject currentCommand;
    private GameObject tempCommand;
    public GameObject roomcodepanel;
    public GameObject room3password;
    public GameObject timer;
    int index;
    bool iscorrect = true;
    int numberButtonClicks = 0;

    //Fmod events
    private FMOD.Studio.EventInstance redInstruction;
    private FMOD.Studio.EventInstance blueInstruction;
    private FMOD.Studio.EventInstance leverLeftInstruction;
    private FMOD.Studio.EventInstance leverRightInstruction;

    private FMOD.Studio.EventInstance buttonClickSoundGood;
    private FMOD.Studio.EventInstance buttonClickSoundBad;

    private FMOD.Studio.EventInstance leverClickSoundGood;
    private FMOD.Studio.EventInstance leverClickSoundBad;

    private FMOD.Studio.EventInstance correctSound;

    private bool newPrompt = false;

    Transform soundEmitter;

    // Start is called before the first frame update
    void Start()
    {
        //Intialising FMOD instruciton sounds
        redInstruction = FMODUnity.RuntimeManager.CreateInstance("event:/Voiceover/Room3/Room3_RedButton");
        blueInstruction = FMODUnity.RuntimeManager.CreateInstance("event:/Voiceover/Room3/Room3_BlueButton");
        leverLeftInstruction = FMODUnity.RuntimeManager.CreateInstance("event:/Voiceover/Room3/Room3_LeverLeft");
        leverRightInstruction = FMODUnity.RuntimeManager.CreateInstance("event:/Voiceover/Room3/Room3_LeverRight");

        //Intialsing button clicked feedback sounds
        buttonClickSoundGood = FMODUnity.RuntimeManager.CreateInstance("event:/Room3/SFX/ButtonGood");
        buttonClickSoundBad = FMODUnity.RuntimeManager.CreateInstance("event:/Room3/SFX/ButtonBad");

        //Intialisng lever clicker feedback sounds
        leverClickSoundGood = FMODUnity.RuntimeManager.CreateInstance("event:/Room3/SFX/LeverGood");
        leverClickSoundBad = FMODUnity.RuntimeManager.CreateInstance("event:/Room3/SFX/LeverBad");

        //intialising wind sound
        correctSound = FMODUnity.RuntimeManager.CreateInstance("event:/Room3/SFX/ZeroPercentWin");

        //Setting emmiter for all sounds to centre of podium
        soundEmitter = transform.Find("SoundEmitter");

        buttonClickSoundGood.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundEmitter));
        buttonClickSoundBad.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundEmitter));
        leverClickSoundGood.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundEmitter));
        leverClickSoundBad.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundEmitter));
        correctSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundEmitter));

        //Set voice crossover to 0 (how much the voice sounds like the A.I.
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("VoiceCrossover", 0);

       

    }

    // Update is called once per frame
    void Update()
    {
       
        if (iscorrect) //If player finished a command get a new random command and set that cmmand
        {
            newPrompt = true;
            iscorrect = false;
            index = Random.Range(0, Commands.Length);
            playPrompt(index);
            currentCommand = Commands[index];
            currentCommand.SetActive(true);
            tempCommand = currentCommand;
            //Debug.Log(index);
        }

        if (newPrompt) //If new prompt then check button presses
        {
            RandCommands();
        }

        if (processbar.process <= 0) //If process bar 0 or smaller then run win condition
        {
            correctSound.start();    //Play win sound
            room3password.SetActive(true); //Display password to access shutdown code
            timer.SetActive(false);  //Stop timer
            for (int i = 0; i < Commands.Length; i++) //Remove commands
            {
                Commands[i].SetActive(false);

            }
            gameObject.GetComponent<RandomCommand>().enabled = false; //Disable getting new commands
        }

        /*if (processbar.process >= 100)
        {
            this.gameObject.GetComponent<CommandReverse>().enabled = true;
            this.gameObject.GetComponent<RandomCommand>().enabled = false;
            roomcodepanel.SetActive(true);
        }*/


    }

    public void RandCommands() //Check command progression
    {
    
        if (index == 0) //If red button asked for
        {

            if(PushBlueButton.pushbluebutton == true) //If blue pressed decrement progress and reset blue button
            {
                incrementProgress(false);
                PushBlueButton.pushbluebutton = false;
                playButtonSound(false);   //Play incorrect sound
            }
            if (PushRedButton.pushredbutton == true) //If red pressed increment progress and reset red button
            {
                incrementProgress(true);
                PushRedButton.pushredbutton = false;
                playButtonSound(true); //Play correct sound
            }
        }
        else if (index == 1)  //If blue button asked for
        {

            if (PushRedButton.pushredbutton == true) //If red pressed decrement progress and reset red button
            {
                playButtonSound(false); //Play incorrect sound
                incrementProgress(false);
                PushRedButton.pushredbutton = false;
            }
            if (PushBlueButton.pushbluebutton == true) //If blue pressed increment progress and reset blue button
            {
                playButtonSound(true); //Play correct sound
                incrementProgress(true);
                PushBlueButton.pushbluebutton = false;
            }
        }
        else if (index == 2) //If left lever press asked for
        {

            if (ClickLever.leverright == true) //Play incorrect if right lever pressed and decrement progress
            {
                playLeverSound(false);
                incrementProgress(false);
            }
            if (ClickLever.leverleft == true) //Play correct if left lever pressed and increment progress
            {
                playLeverSound(true);
                incrementProgress(true);
            }
        }

        else if (index == 3) //If right lever press asked for
        {
            if (ClickLever.leverright == true) //Play correct if right lever pressed and increment progress
            {
                playLeverSound(true);
                incrementProgress(true);
            }
            if (ClickLever.leverleft == true) //Play incorrect if left lever pressed and decrement progress
            {
                playLeverSound(false);
                incrementProgress(false);
            }
        }

        /*if(iscorrect)
        {
            tempCommand.SetActive(false);
        }*/
            

    }

   private void incrementProgress(bool up) //Method to increment or decrement progress by JC
   {
        StartCoroutine(waitTillNext()); //Start coroutine to wait for command and feedback before issuing a new command
        numberButtonClicks++;           //Increase number of button clicks
        updateVoiceCrossover(numberButtonClicks / 5.0f); //Set voice crossover based on the number of button clicks
        if (up)  //If increment then increase progress bar by 10
        {
            processbar.process += 10;
        }
        else //If decrease then decrement progress
        {
            if (processbar.process > 100) //If progress above 100% decrease by 25%
            {
                processbar.process -= (int)(0.25f * processbar.process);
            } 
            else  //Otherwise decrease by 20
            {
                processbar.process -= 20;
            }
        }
    }


    void playButtonSound(bool correctSound) //Method to play button sounds
    {
        if(correctSound) //If correct sound play correct sound
        {
            buttonClickSoundGood.start();
        }
        else  //Otherwise play incorrect sound
        {
            buttonClickSoundBad.start();
        }
    }

    void playLeverSound(bool correctSound) //Method to play lever sounds
    {
        if (correctSound)   //If correct sound play correct sound
        {
            leverClickSoundGood.start();
        }
        else  //Otherwise play incorrect sound
        {
            leverClickSoundBad.start();
        }
    }

    private void playPrompt(int promptNum)  //Method to play prompt for what user should do
    {
        switch(promptNum)
        {
            case 0:
                redInstruction.start(); //Play red button prompt
                break;
            case 1:
                blueInstruction.start(); //Play blue button prompt
                break;
            case 2:
                leverLeftInstruction.start(); //play left lever prompt
                break;
            case 3:
                leverRightInstruction.start(); //play right lever prompt
                break;
            default:
                break;
        }
    }


    private void updateVoiceCrossover(float val) //Method for updatinf the voice crossover
    {
        if (val > 1) //If voice crossover biffer than 1 then set to 1
        {
            val = 1;
        }
        if(val < 0) //If voice crossover less than 0 then set to 0
        {
            val = 0;
        }

        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("VoiceCrossover", val); //Set voice crossover parameter value
    }

    IEnumerator waitTillNext() //Couroutine to wait for 2.5s befor allowing another command
    {
        newPrompt = false;
        tempCommand.SetActive(false);

        //yield on for 2.5s second.
        yield return new WaitForSeconds(2.5f);

        iscorrect = true;
    }

}


