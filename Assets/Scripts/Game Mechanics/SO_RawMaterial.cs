using UnityEngine;
using System.IO;


public abstract class SO_RawMaterial : ScriptableObject
{
    public string _name;
    public float _volumeIndex;
    public float _massIndex;    

    public void ToJson()
    {
        var jstr = JsonUtility.ToJson(this);
        WriteFileAsync("path","fileName","extension", jstr);

    }

    private void WriteFileAsync(string path, string fileName, string extension, string jsonStr)
    {
        File.AppendAllTextAsync(path, jsonStr);
    }
}
