using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Monobehaviour class that detects if the bounds of the RectTransform component are outside the camera view.
/// </summary>
[RequireComponent(typeof(RectTransform))]
[ExecuteAlways]
public class UIViewChecker : MonoBehaviour
{
    public bool debug = false;
    [SerializeField] private UnityEvent onOutOfBounds;

    private RectTransform rectTransform;
    private Camera mainCamera;

    private bool isOffLeft, isOffRight, isOffTop, isOffBottom, isOffView;

    /// <summary>
    /// The offset value of the left side of the RectTransform from the camera view.
    /// </summary>
    public float OffsetLeft { get; private set; }

    /// <summary>
    /// The offset value of the right side of the RectTransform from the camera view.
    /// </summary>
    public float OffsetRight { get; private set; }

    /// <summary>
    /// The offset value of the top side of the RectTransform from the camera view.
    /// </summary>
    public float OffsetTop { get; private set; }

    /// <summary>
    /// The offset value of the bottom side of the RectTransform from the camera view.
    /// </summary>
    public float OffsetBottom { get; private set; }

    /// <summary>
    /// Flag indicating if the left side of the RectTransform is off the camera view.
    /// </summary>
    public bool IsOffLeft => isOffLeft;

    /// <summary>
    /// Flag indicating if the right side of the RectTransform is off the camera view.
    /// </summary>
    public bool IsOffRight => isOffRight;

    /// <summary>
    /// Flag indicating if the top side of the RectTransform is off the camera view.
    /// </summary>
    public bool IsOffTop => isOffTop;

    /// <summary>
    /// Flag indicating if the bottom side of the RectTransform is off the camera view.
    /// </summary>
    public bool IsOffBottom => isOffBottom;

    /// <summary>
    /// Flag indicating if any side of the RectTransform is off the camera view.
    /// </summary>
    public bool IsOffView => isOffView;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Get the world space corners of the RectTransform
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        // Convert the corners to screen space using the main camera
        Vector3 minScreenPoint = mainCamera.WorldToScreenPoint(corners[0]);
        Vector3 maxScreenPoint = mainCamera.WorldToScreenPoint(corners[2]);

        // Check if each side of the RectTransform is off the camera view
        isOffLeft = minScreenPoint.x < 0f;
        isOffRight = maxScreenPoint.x > Screen.width;
        isOffTop = maxScreenPoint.y > Screen.height;
        isOffBottom = minScreenPoint.y < 0f;

        // Calculate the offset values for each side based on their distance from the camera view
        OffsetLeft = isOffLeft ? Mathf.Abs(minScreenPoint.x) : 0f;
        OffsetRight = isOffRight ? Mathf.Abs(maxScreenPoint.x - Screen.width) : 0f;
        OffsetTop = isOffTop ? Mathf.Abs(maxScreenPoint.y - Screen.height) : 0f;
        OffsetBottom = isOffBottom ? Mathf.Abs(minScreenPoint.y) : 0f;

        // Check if any side of the RectTransform is off the camera view
        isOffView = isOffLeft || isOffRight || isOffTop || isOffBottom;

        // Check if the UIView is off the view
        if (IsOffView)
        {
            onOutOfBounds?.Invoke();
            // Generate debug message for off-view sides
            if (debug) //if it is off the view
            {
                string debugMessage = "Off view: ";
                if (isOffLeft)
                    debugMessage += $"Left ({OffsetLeft}), ";
                if (isOffRight)
                    debugMessage += $"Right ({OffsetRight}), ";
                if (isOffTop)
                    debugMessage += $"Top ({OffsetTop}), ";
                if (isOffBottom)
                    debugMessage += $"Bottom ({OffsetBottom}), ";

                // Append side and offset information
                debugMessage = debugMessage.TrimEnd(',', ' ');

                // Unity Console Routine
                // Debug.Log(debugMessage);


                //ezDebug.Live(this, debugMessage);

            }
        }
    }
}
