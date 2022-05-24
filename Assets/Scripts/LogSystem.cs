using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LogSystem : MonoBehaviour
{
    //unique instance ref
    public static LogSystem Singleton;

    private UnityEvent LogUEvent = new UnityEvent();

    private Dictionary<MonoBehaviour, List<string>> controls_list;
  
    

    public void Start()
    {
        //If unique instance ref is empty make it this one, else leave previous delete me.
        if (!Singleton) Singleton = this;
        else if (Singleton != this) Destroy(this);

        Initialize();
    }

    private void Initialize()
    {
        controls_list = new Dictionary<MonoBehaviour, List<string>>();
        
    }

    public static void Log(MonoBehaviour caller, string text)
    {
        //define string list
        List<string> caller_strlist;

        //Check for caller in dictionary
        if(!Singleton.controls_list.TryGetValue(caller, out caller_strlist))//if its found will get saved
            caller_strlist = new List<string>(); //create one if there is not one already

        caller_strlist.Add(text);//new string is added

        Singleton.controls_list.Add(caller, caller_strlist); //list is added to dictionary

    }

    
}

public class Character : MonoBehaviour
{
    public void Sub()
    {
        //do something and log it
        LogSystem.Log(this, "Activity Logged");
    }
}



