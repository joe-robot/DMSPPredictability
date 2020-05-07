//activeWhenObjsInactive.cs
//class to free the mouse or lock the mosue based on when specific Ui components are visibale

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activeWhenObjsInactive : MonoBehaviour
{
    [SerializeField] GameObject[] checkActiveObjects;
    private bool objectActive = false;

    public GameObject FPSController;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < checkActiveObjects.Length; ++i) //Iterate through all Ui components if one active then set object active to true
        {
            if(checkActiveObjects[i].activeInHierarchy)
            {
                objectActive = true;
                break;
            }
            objectActive = false;
        }

        if(objectActive && GetComponent<Button>().enabled) //If ui active then disable mouse lock button and free mouse
        {
            GetComponent<Button>().enabled = false;
            FPSController.GetComponent<FreeFPSMouse>().setMouseMode(true);
        }
        else if(!GetComponent<Button>().enabled && !objectActive) //If ui unactive then enable mouse lock button and lock mouse
        {
            FPSController.GetComponent<FreeFPSMouse>().setMouseMode(false);
            GetComponent<Button>().enabled = true;
        }
    }
}
