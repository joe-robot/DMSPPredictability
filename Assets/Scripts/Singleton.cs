//Singleton.cs
//Singleton to be used by inherited from by other singletons
//By Joe Cresswell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if(_instance == null)       //Check if instance exists then get that
            {
                _instance = GameObject.FindObjectOfType<T>();

                if(_instance == null)   //If no instance exists create one
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    _instance = singleton.AddComponent<T>();
                }
            }

            return _instance;
        }
    }


    //Making singleton persist bettween scene changes
    public virtual void Awake()
    {
        if (_instance == null) //If not one, create one
        {
            _instance = this as T;
            DontDestroyOnLoad(_instance);
        }
        else     //Destroy any repeats
        {
            Destroy(gameObject);
        }
    }
}
