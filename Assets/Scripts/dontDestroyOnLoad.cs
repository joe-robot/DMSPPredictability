//dontDestroyOnLoad.cs
//Class to make a object indstructable bettween loads
//By Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyOnLoad : MonoBehaviour
{
    void Awake() //On awake set object to non destructable
    {
        //GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        DontDestroyOnLoad(this.gameObject);
    }
}
