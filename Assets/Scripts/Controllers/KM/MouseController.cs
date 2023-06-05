using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class MouseController : MonoBehaviour
{

    public PlayerInput playerInput;

    public bool
        debugPosition,
        debugRay;
    public float
        debugRayLenght,
        debugRayDuration;


    public Vector2 MousePosition { get => Mouse.current.position.ReadValue(); }


    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

    }

    public void Hover(InputAction.CallbackContext context)
    {
        Ray ray;
        RaycastHit hit;

        if (context.phase == InputActionPhase.Performed)
        {
            ray = Camera.main.ScreenPointToRay(MousePosition);

            //**Move to debug independent methood
            if (debugPosition)
            {
            //    EzDebug.Live(this, "Mouse Hover Position = " + MousePosition, 0);
            //    EzDebug.Live(this, "Screen Point To Ray (MousePosition) = " + Camera.main.ScreenPointToRay(MousePosition), 1);
            }
            if (debugRay)
            {
                Debug.DrawRay(ray.origin, ray.direction * debugRayLenght, Color.red);
            }
            //MISSING: Hover Method has to grab the Selectable Component out of a raycast hit and register it on GameMgr Hovering field

            Physics.Raycast(ray, out hit);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Selectable>() != null)
            {
                GameMgr.Hovering = hit.collider.gameObject.GetComponent<Selectable>();
            }

        }
    }

}