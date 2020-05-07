//changePlatforms.cs
//Class to open doors based on if player enters the correct code
//By Jaiqi Fan and Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePlatforms : MonoBehaviour
{
    [SerializeField] GameObject room2door1;
    [SerializeField] GameObject room2door2;
    [SerializeField] GameObject room2door3;
    [SerializeField] GameObject room2door4;

    //[SerializeField] Material passMaterial;

    [SerializeField] GameObject checkCorrectObj;

    private int currentPos;

    private checkCodeInput thisChecker;
    // Start is called before the first frame update
    void Start()
    {
        //Get correct input checker
        thisChecker = checkCorrectObj.GetComponent<checkCodeInput>();
        currentPos = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        //If correct input
        if(thisChecker.checkCorrect())
        {
            switch(currentPos)
            {
                case 0:
                    room2door1.gameObject.GetComponent<Animation>().Play("doormoveup"); //Open door 1

                    break;
                case 1:
                    room2door2.gameObject.GetComponent<Animation>().Play("R2D2moveup"); // open door 2

                    break;
                case 2:
                    room2door3.gameObject.GetComponent<Animation>().Play("R2D3moveup"); //open door 3

                    thisChecker.setReverse(); //Reverse the required input to open the door
                    break;
                case 3:
                    room2door4.gameObject.GetComponent<Animation>().Play("R2D4moveup"); //open final door

                    break;
                default:
                    break;
            }
            currentPos++; //Increment the number door
        }
    }
}
