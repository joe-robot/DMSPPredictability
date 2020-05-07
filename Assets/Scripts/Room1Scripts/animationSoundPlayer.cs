//animationSoundPlayer.cs
//simple script to play a sound to be called by a animation
//By Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationSoundPlayer : MonoBehaviour
{

    [FMODUnity.EventRef]                    //FMOD open sound reference
    public string animationEventOpen = "";
    FMOD.Studio.EventInstance animationOpenSound;

    [FMODUnity.EventRef]                    //FMOD close sound reference
    public string animationEventClose = "";
    FMOD.Studio.EventInstance animationCloseSound;

    private Transform soundEmitter;     //The sound emmiter position
    // Start is called before the first frame update
    void Start()
    {
        //Creating FMod event instances
        animationOpenSound = FMODUnity.RuntimeManager.CreateInstance(animationEventOpen);
        animationCloseSound = FMODUnity.RuntimeManager.CreateInstance(animationEventClose);

        soundEmitter = transform.Find("SoundEmitter");  //Get the sound emmiter

        //Setting 3D position of sound
        animationOpenSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundEmitter));
        animationCloseSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundEmitter));
    }

    public void open()  //Starting open sound
    {
        animationOpenSound.start();
    }

    public void close() //Starting close sound
    {
        animationCloseSound.start();
    }
}
