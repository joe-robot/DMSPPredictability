//RoomSoundTrigger.cs
//Class to trigger a room sound on a trigger
//By Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSoundTrigger : MonoBehaviour
{
    public int roomNumber;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))  //On trigger enter change room sound to set room number
        {
            AtmosController.Instance.startRoomSound(roomNumber);
        }
    }
}
