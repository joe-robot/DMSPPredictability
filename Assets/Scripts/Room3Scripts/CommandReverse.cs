//CommandReverse.cs
//Class to reverse the commands, no longer used only Random Command used
//By Jaiqi Fan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandReverse : MonoBehaviour
{
    public GameObject[] Commands;
    private GameObject currentCommand;
    private GameObject tempCommand;
    public GameObject room3password;
    public GameObject timer;
    public GameObject[] commandtext;
    //public GameObject redbutton;
    int index;
    bool iscorrect = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (iscorrect)
        {
            iscorrect = false;
            index = Random.Range(0, Commands.Length);
            currentCommand = Commands[index];
            currentCommand.SetActive(true);
            tempCommand = currentCommand;
            Debug.Log(index);
        }

        RandCommandsReverse();


        if (processbar.process <= 0)
        {

            room3password.SetActive(true);
            this.gameObject.GetComponent<CommandReverse>().enabled = false;
            timer.SetActive(false);
            for(int i = 0; i < 4; i++)
            {
                commandtext[i].SetActive(false);

            }

        }

    }

    public void RandCommandsReverse()
    {

        if (index == 0 && PushBlueButton.pushbluebutton == true)
        {

            iscorrect = true;
            processbar.process -= 10;
            tempCommand.SetActive(false);

        }
        else if (index == 1 && PushRedButton.pushredbutton == true)
        {

            iscorrect = true;
            processbar.process -= 10;
            tempCommand.SetActive(false);
        }
        if (index == 2 && ClickLever.leverright == true)
        {

            iscorrect = true;
            processbar.process -= 10;
            tempCommand.SetActive(false);
        }

        if (index == 3 && ClickLever.leverleft == true)
        {

            iscorrect = true;
            processbar.process -= 10;
            tempCommand.SetActive(false);
        }



    }
}
