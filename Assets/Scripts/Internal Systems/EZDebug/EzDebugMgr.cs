using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EzDebugMgr : MonoBehaviour
{
    public static EzDebugMgr singleton;
    public GameObject linePrefab;

    private Dictionary<Component, List<GameObject>> callers = new();
    private List<GameObject> showing = new();

    private void Start()
    {
        if (singleton != this) singleton = this;
    }
    internal void Live(string text, int index)
    {
        throw new NotImplementedException();
    }
    internal void Live(string text)
    {
        Live(text, 0);
        throw new NotImplementedException();
    }

    internal void Live(Component caller, string text, int index)
    {
        throw new NotImplementedException();
    }
    
    private GameObject SpawnLine(string text)
    {
        var line = Instantiate(linePrefab);
        line.transform.SetParent(transform);

        var textComp = line.GetComponent<TextMeshProUGUI>();
        textComp.text = text;

        

        return line;
    }


    


}
