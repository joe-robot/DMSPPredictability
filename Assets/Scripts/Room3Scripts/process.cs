//process.cs
//process sets component colours based on i
//By Jaiqi Fan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class process : MonoBehaviour
{
    public int i=1;
    //public GameObject first;
    public GameObject second;
    public GameObject third;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 1)
        {
            //first.GetComponent<Image>().color = new Color((255 / 255f), (255 / 255f), (255 / 255f), (255 / 255f));
            second.GetComponent<Image>().color = new Color((255 / 255f), (255 / 255f), (255 / 255f), (100 / 255f));
            third.GetComponent<Image>().color = new Color((255 / 255f), (255 / 255f), (255 / 255f), (100 / 255f));

        }
        else if (i == 2)
        {
            //first.GetComponent<Image>().color = new Color((255 / 255f), (255 / 255f), (255 / 255f), (255 / 255f));
            second.GetComponent<Image>().color = new Color((255 / 255f), (255 / 255f), (255 / 255f), (255 / 255f));
            third.GetComponent<Image>().color = new Color((255 / 255f), (255 / 255f), (255 / 255f), (100 / 255f));
        }
        else if(i==3)
        {
            second.GetComponent<Image>().color = new Color((255 / 255f), (255 / 255f), (255 / 255f), (255 / 255f));
            third.GetComponent<Image>().color = new Color((255 / 255f), (255 / 255f), (255 / 255f), (255 / 255f));
        }
    }
}
