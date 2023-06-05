using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    public static GameMgr singletonInstance;
    public readonly static List<Character> characters = new List<Character>();

    private static Selectable hovering;
    public static Selectable Hovering { get => hovering; internal set => hovering = value; }


    private static Selectable selected;
    public static Selectable Selected { get => selected; internal set => selected = value; }

    private void Awake()
    {
        //If unique instance ref (Singleton) is empty, then fill it with me (this),
        if (!singletonInstance) singletonInstance = this;
        //or else leave previous delete me.
        else if (singletonInstance != this) Destroy(this);
    }

    private void Start()
    {
        List<GameObject> rootObjectsInScene = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjectsInScene);

        for (int i = 0; i < rootObjectsInScene.Count; i++)
        {
            Component[] allComponents = rootObjectsInScene[i].GetComponentsInChildren<Component>(true);
            for (int j = 0; j < allComponents.Length; j++)
            {
                //if (allComponents[j].GetType() == typeof(Character)) characters.Add((Character)allComponents[j]);
            }
        }
    }

    public void Save(SaveFile_Format saveInfo)
    {
        SaveUtility.Save(saveInfo);
    }
}
