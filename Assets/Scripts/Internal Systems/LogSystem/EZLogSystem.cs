using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EZLogSystem : MonoBehaviour
{
    //unique instance ref
    public static EZLogSystem _singletonInstance;

    private void Awake()
    {
        //If unique instance ref (Singleton) is empty, then fill it with me (this),
        if (!_singletonInstance) _singletonInstance = this;
        //or else leave previous delete me.
        else if (_singletonInstance != this) Destroy(this);
    }

    public UnityEvent LogEvent = new UnityEvent();

    //Search for a log by control
    private Dictionary<EZLogMB, List<string>> LogsByCtrl;
    

    public void Start()
    {

        LogsByCtrl = new Dictionary<EZLogMB, List<string>>();
        
    }

    public static void Log(EZLogMB caller, string text)
    {
        List<string> _strlist = new List<string>(); 

        //Check for caller in byCaller dictionary and add requested value
        if (!_singletonInstance.LogsByCtrl.TryGetValue(caller, out _strlist)) //if its found it will get saved on the out
        _strlist.Add(text); //the requested string is added to the by callers list
        
        _singletonInstance.LogsByCtrl.Add(caller, _strlist); //value is updated for public access
        

        if (!_singletonInstance.LogsByCtrl.TryGetValue(caller, out _strlist))//if its found will get saved
            _strlist = new List<string>(); //create one if there is not one already

    }


}



