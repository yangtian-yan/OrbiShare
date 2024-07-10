using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPositioner : MonoBehaviour
{
    public Transform targetObject; // The GameObject to position the keyboard under
    public Vector3 offset; // Offset from the target object’s position
    public OVRVirtualKeyboard virtualKeyboard; // Reference to the virtual keyboard component

    void Start()
    {
        PositionKeyboardOnce();
    }

    void PositionKeyboardOnce()
    {
        if (targetObject == null || virtualKeyboard == null)
            return;

        // Calculate the initial position
        Vector3 initialPosition = targetObject.position + offset;

        // Set the keyboard's position
        virtualKeyboard.transform.position = initialPosition;

        // Optionally, you might want to disable this component to ensure it doesn't run updates
        this.enabled = false; // Disable this script to prevent future updates
    }
}
