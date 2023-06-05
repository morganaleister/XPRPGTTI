using UnityEngine;

/// <summary>
/// Inherit from this class to create your CustomFileFormat to use with SaveUtility class.
/// Make sure is [System.Serializable] tagged too, as well as to use any [SerializeField] tags on any private fields that you need.
/// </summary>
[System.Serializable]
public abstract class SaveFile_Format
{
    public string _fileName;
    
    protected string _ext = ".";


    public string FileExtension { get => _ext; }

    public string FullFileName => _fileName + _ext;

    public void SetExtension(ValidSaveExtensions _validExt) => _ext += _validExt.ToString();
}
