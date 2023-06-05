using System.IO;
using UnityEngine;

public static class SaveUtility
{
    private const string _Z = "\\";
    public static readonly string _separatorCharacter = _Z;

    private static string _mainPath = Application.dataPath;

    public static void Save(SaveFile_Format _saveInfo)
    {
        string jsonRdyText_ = JsonUtility.ToJson(_saveInfo);
        Write(_mainPath, _saveInfo.FullFileName, jsonRdyText_);
    }

    /// <summary>
    /// This method was created as a way to organize files by folder
    /// </summary>
    /// <param name="path_"></param>
    /// <param name="fileName_"></param>
    /// <param name="jsonRdyText_"></param>
    private static void Write(string path_, string fileName_, string jsonRdyText_) 
        => File.WriteAllText(path_ + fileName_, jsonRdyText_);
    
}
