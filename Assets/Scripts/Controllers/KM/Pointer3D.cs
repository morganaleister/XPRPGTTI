using UnityEngine;
using UnityEngine.InputSystem;

public class Pointer3D : MonoBehaviour
{
    public float zValue; 
    public void UpdatePos()
    {
        var mPos = Mouse.current.position.ReadValue();
        Vector3 pointerPos = new Vector3(mPos.x, mPos.y, zValue);
        transform.position = Camera.main.ScreenToWorldPoint(pointerPos);
        
    }



}