//DisabelComponentOnTrig.cs
//Script disable a set game object when the player eneters the region
//By Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabelComponentOnTrig : MonoBehaviour
{
    public bool disableMode = true; //set to disable componet intially

    public GameObject objectToDisable;

    private void OnTriggerEnter(Collider other) //If trigger entered
    {
        if (disableMode) //and disable mode set then disable the component
        {
            objectToDisable.SetActive(false);
        }
        else  //Otherwise enable the component on trigger
        {
            objectToDisable.SetActive(true);
        }
    }
}
