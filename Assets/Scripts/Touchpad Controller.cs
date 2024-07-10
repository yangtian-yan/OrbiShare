using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchpadController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Camera cameraToControl;
    public float sensitivity = 0.1f;
    public RectTransform stickCircle;
    public float maxStickMovement = 50f; // Maximum distance the stick can be dragged

    private Vector2 startTouchPosition;
    private bool isDragging = false;
    private Vector3 initialCameraPosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        startTouchPosition = eventData.position;
        initialCameraPosition = cameraToControl.transform.position;
        UpdateStickPosition(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        ResetStickPosition();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector2 touchCurrentPosition = eventData.position;
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)transform, touchCurrentPosition, null, out localPoint);

            // Clamp the stick circle's movement within the maxStickMovement radius
            localPoint = Vector2.ClampMagnitude(localPoint, maxStickMovement);
            stickCircle.localPosition = localPoint;

            // Calculate the delta positions based on the stick circle's movement
            float deltaX = (localPoint.x / maxStickMovement) * sensitivity;
            float deltaZ = (localPoint.y / maxStickMovement) * sensitivity;

            // Update the camera position
            Vector3 newPosition = initialCameraPosition + new Vector3(deltaX, 0, deltaZ);
            cameraToControl.transform.position = newPosition;
        }
    }

    private void UpdateStickPosition(Vector2 position)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)transform, position, null, out localPoint);
        localPoint = Vector2.ClampMagnitude(localPoint, maxStickMovement);
        stickCircle.localPosition = localPoint;
    }

    private void ResetStickPosition()
    {
        stickCircle.localPosition = Vector2.zero;
    }
}



