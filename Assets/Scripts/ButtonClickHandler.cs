using UnityEngine;
using Oculus.Interaction.HandGrab;

public class ButtonClickHandler : MonoBehaviour
{
    // Reference to the GameObject that has the HandGrabInteractable script
    public GameObject targetGameObject;

    // Reference to the GameObject to deactivate
    public GameObject gameObjectToDeactivate;

    // Method to be called on button click
    public void Lock()
    {
        // Deactivate the HandGrabInteractable script
        if (targetGameObject != null)
        {
            var handGrabInteractable = targetGameObject.GetComponent<HandGrabInteractable>();
            if (handGrabInteractable != null)
            {
                handGrabInteractable.enabled = false;
            }
        }

        // Deactivate the specified GameObject
        if (gameObjectToDeactivate != null)
        {
            gameObjectToDeactivate.SetActive(false);
        }
    }
}


