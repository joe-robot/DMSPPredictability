//checkBanksLoaded.cs
//A class to check banks are loaded before loading the game as required by FMOD in open GL
//By Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkBanksLoaded : MonoBehaviour
{
    private bool loaded = false;
    // Update is called once per frame

    void Update()
    {
        if (FMODUnity.RuntimeManager.HasBankLoaded("UI") && FMODUnity.RuntimeManager.HasBankLoaded("Master") && !loaded) //Check banks loaded and not already run this statement successfully
        {
            loaded = true; //Set loaded
            Debug.Log("Bank Loaded"); //Display loaded
            SceneManager.LoadScene("Game", LoadSceneMode.Single); //Load the game
        }
    }
}
