using UnityEngine;
using UnityEngine.UI;

public class ToggleCameraMoverOnButtonClick : MonoBehaviour
{
    // Reference to the CameraMover script
    public PlayerMovement cameraMover;

    // Reference to the GameObject to deactivate
    // public GameObject objectToDeactivate;

    // Method to be called on button click
    public void ToggleCameraMover()
    {
        if (cameraMover != null)
        {
            cameraMover.enabled = !cameraMover.enabled;

            // Check if the camera mover is enabled and deactivate the specified GameObject
            // if (cameraMover.enabled && objectToDeactivate != null)
            // {
            //     objectToDeactivate.SetActive(false);
            // }

        }
        else
        {
            Debug.LogError("CameraMover script is not assigned.");
        }
    }
}

