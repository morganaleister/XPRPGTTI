using UnityEngine;

public class EZLogMB : MonoBehaviour
{
    public void Log(string _message)
    {
        EZLogSystem.Log(this, _message);
    }

}



