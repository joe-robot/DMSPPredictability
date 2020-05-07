//processbar.cs
//Sets process bar text and bar size
//By Jaiqi Fan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class processbar : MonoBehaviour
{
    public static float process = 66; //Initialise process bar value to 66%
    public Image bar;
    public Text percent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //Update fill amount of process bar
    {
        bar.fillAmount = process / 100; //Update fill amount
        percent.text = process + "%"; //Update text

        if (process > 250) { //Don't update based 250%
            process = 250;
        }
        if(process < 0) //Don't update below 0%
        {
            process = 0;
        }

    }
}
