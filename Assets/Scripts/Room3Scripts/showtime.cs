//showtime.cs
//Class to show the time
//By Jaiqi Fan
//Sound implementaiton by Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showtime : MonoBehaviour
{
    private Text timeShowText;
    public static float spendTime = 180f;
    private int hour;
    private int minute;
    private int second;
    public GameObject[] turnred;
    public GameObject restartpanel;
    public Color OrigColor;

    private FMOD.Studio.EventInstance wrongSound;
    Transform soundEmitter;

    private FMOD.Studio.EventInstance TimerSound;

    

    // Start is called before the first frame update
    void Start()
    {
        //Initalise intal colours and text component
        OrigColor = this.gameObject.GetComponent<Text>().color;
        timeShowText = GetComponent<Text>();

        //Intialising events for timer
        wrongSound = FMODUnity.RuntimeManager.CreateInstance("event:/Room3/SFX/LoseGame");
        TimerSound = FMODUnity.RuntimeManager.CreateInstance("event:/Room3/Atmos/IntensifyingMusic");
    }

    // Update is called once per frame
    void Update()
    {
        if (spendTime > 0.1f) //If not ended
        {
            Setcolorback(); //Reset color
            spendTime -= Time.deltaTime; //Reduce time by delta time
            UpdateLevelTimer(spendTime); //Update time
            if (spendTime < 30f) //If tim less than 30s then set timer red
            {
                for (int i = 0; i < turnred.Length; i++)
                {
                    turnred[i].gameObject.GetComponent<Image>().color = Color.red;
                }
                this.gameObject.GetComponent<Text>().color = Color.red;
            }
        }
        else  //If timer done then stop timer sound, play wrong sound and place restart panel up as player failed
        {
            TimerSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            wrongSound.start();
            restartpanel.SetActive(true);
        }
            
      

    }


    public void UpdateLevelTimer(float totalSeconds) //Method to update the timer time using minutes and seconds
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        //string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timeShowText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
 
    }

    public void Setcolorback() //Method to reset the colour of the timer
    {
        for (int i = 0; i < turnred.Length; i++)
        {
            turnred[i].gameObject.GetComponent<Image>().color = Color.white;
        }
        this.gameObject.GetComponent<Text>().color = OrigColor;
    }

    private void OnDisable() //Method on disable of timer to stop the sound
    {
        TimerSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    private void OnEnable() //method on enable of timer to enable time sound
    {
        TimerSound.start();
    }
}
