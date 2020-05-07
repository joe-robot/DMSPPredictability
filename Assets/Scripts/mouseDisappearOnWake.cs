//mouseDisappearOnWake.cs
//Class to lock mouse on enable of an object
//By Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDisappearOnWake : MonoBehaviour
{
    [SerializeField] GameObject FPSControllerMouse;
    private void OnEnable() //On enable lock the mouse
    {
        FPSControllerMouse.GetComponent<FreeFPSMouse>().freeMouse = true;
    }
}
