//AtmosController.cs
//A singleton to control all ambient sounds
//By Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AtmosController : Singleton<AtmosController>
{

    //Fmod Events
    private FMOD.Studio.EventInstance room1a;
    private FMOD.Studio.EventInstance room2;
    private FMOD.Studio.EventInstance room3;

    //Room 1 and room 2 emitter positons
    public Transform room1Emitter;
    public Transform room2Emitter;

    //Current active room
    private int roomActive = 1;

    //Intially set sound a not active
    private bool soundActive = false;

    private void Start()    //Intialise array
    {
        //Intialising atmosphere sounds and their positions isf required
        room1a = FMODUnity.RuntimeManager.CreateInstance("event:/Room1/Atmos/RoomAtmos");
        room2 = FMODUnity.RuntimeManager.CreateInstance("event:/Room2/Atmos/CombinedRoomSound");
        room3 = FMODUnity.RuntimeManager.CreateInstance("event:/Room3/Atmos/Atmos");

        room1a.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(room1Emitter));
        room2.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(room2Emitter));
    }

    //Mehtod to start the room sounds
    public void startRoomSound(int roomNum)
    {
        if (roomNum != roomActive || !soundActive) //If room sounds or just activated
        {
            if(soundActive)   //If sound already active then stop previous ambience
                stopRoomSound(roomActive);

            soundActive = true; //Set sound active
            roomActive = roomNum;  //Set new room active

            switch (roomActive) //Switch to change room ambiences based on set values
            {
                case 1:    //Have room 1 and room 2 playing at same time as there is a 3D crossover region
                    room1a.start();
                    room2.start();
                    break;
                /*case 2:
                    room2.start();
                    break;*/
                case 2:   //Have room 3 playing on it's own
                    room3.start();
                    break;
                default:   //Defailt to room 1 and room 2
                    room1a.start();
                    room2.start();
                    break;
            }
        }
    }

    public void stopRoomSound(int roomNum)  //method to stop room sound
    {
        switch (roomNum) //Stop room 1 and room 2 sound but allow fade out
        {
            case 1:
                room1a.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                room2.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                break;
            /*case 2:
                room2.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                break;*/
            case 2: //Stopr room 3 sound but allow fade out
                room3.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                break;
            default:
                break;
        }
    }



}
