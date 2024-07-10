using UnityEngine;

public class EnableTrackPrefabMovement : MonoBehaviour
{
    // Reference to the GameObject that has the TrackPrefabMovement script
    public GameObject targetGameObject;

    // This method will be called when the button is clicked
    public void EnableScript()
    {
        targetGameObject = GameObject.Find("OnboardingManager");
        // Check if the target GameObject is set
        if (targetGameObject != null)
        {
            // Get the TrackPrefabMovement component from the target GameObject
            TrackPrefabMovement trackPrefabMovement = targetGameObject.GetComponent<TrackPrefabMovement>();

            // If the component is found, enable it
            if (trackPrefabMovement != null)
            {
                trackPrefabMovement.enabled = true;
            }
            else
            {
                Debug.LogWarning("TrackPrefabMovement script not found on the target GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("Target GameObject is not assigned.");
        }
    }
}

