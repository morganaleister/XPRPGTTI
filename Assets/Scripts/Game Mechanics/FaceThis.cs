using UnityEngine;

[DisallowMultipleComponent()]
[ExecuteAlways]
public class FaceThis : MonoBehaviour
{
    public Transform _faceThis;
    public bool debug;
    protected void Update()
    {
        if (_faceThis) { transform.LookAt(_faceThis); }
        if (debug) Debug.DrawLine(transform.position, _faceThis.position, Color.green);
    }
}
