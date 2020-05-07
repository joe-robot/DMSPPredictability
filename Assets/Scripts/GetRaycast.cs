//GetRaycast.cs
//Class the raycast sets raycast variable true in if raycast enters the object
//by Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRaycast : MonoBehaviour
{
    public bool raycast = false;

    public void rayEnter() //if ray enter set ray entered
    {
        raycast = true;
    }

    public void rayExit() //If ray exit then set exit
    {
        raycast = false;
    }
}
