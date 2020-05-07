//ResetAudio.cs
//A class to reset the audio to overcome problem in chrome of FMOD not working
//Adapted for this program from https://alessandrofama.com/tutorials/fmod-unity/fix-blocked-audio-browsers/ by Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAudio : MonoBehaviour
{

    public void ResumeAudio() //Method to reset the mixer
    {
        var result = FMODUnity.RuntimeManager.CoreSystem.mixerSuspend();
        Debug.Log(result);
        result = FMODUnity.RuntimeManager.CoreSystem.mixerResume();

    }
}
