using UnityEngine;
using UnityEngine.EventSystems;

public class MobileJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform joystickBackground;
    public RectTransform joystickHandle;
    private Vector2 inputVector = Vector2.zero;

    public float Horizontal => inputVector.x;
    public float Vertical => inputVector.y;

    public void OnPointerDown(PointerEventData eventData) => OnDrag(eventData);

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = RectTransformUtility.WorldToScreenPoint(null, joystickBackground.position);
        Vector2 radius = joystickBackground.sizeDelta / 2f;
        inputVector = (eventData.position - position) / radius;
        inputVector = (inputVector.magnitude > 1f) ? inputVector.normalized : inputVector;
        joystickHandle.anchoredPosition = inputVector * radius;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
    }
}

public class TouchLookField : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public float sensitivity = 0.2f;
    private Vector2 touchDelta;
    private Vector2 previousPosition;
    private bool isTouching;

    public Vector2 TouchDelta => touchDelta;

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouching = true;
        previousPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        touchDelta = (eventData.position - previousPosition) * sensitivity;
        previousPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouching = false;
        touchDelta = Vector2.zero;
    }
}
