//WindRegion.cs
//Class to trigger wind effect when player in wind region
//By Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindRegion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //If player in wind region then set windeffect component on
    {
        if(other.name == "FPS")
        {
            other.GetComponent<WindPlayerEffect>().enabled = true;
        }

    }

    private void OnTriggerExit(Collider other) //If player exits wind region then set windeffect component off
    {
        if (other.name == "FPS")
        {
            other.GetComponent<WindPlayerEffect>().enabled = false;
        }
    }
}
