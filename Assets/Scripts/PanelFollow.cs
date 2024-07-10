using UnityEngine;

public class PanelFollow : MonoBehaviour
{
    private GameObject targetObject; // The GameObject that the panel will follow
    public Vector3 offset = new Vector3(0f, 0f, 0f); // Adjust the offset as needed
    private bool isInitialized = false;

    void OnEnable()
    {
        if (!isInitialized)
        {
            // Find the target object when the script is first enabled
            targetObject = GameObject.Find("[BuildingBlock] Camera Rig");
            if (targetObject == null)
            {
                Debug.LogError("[BuildingBlock] Camera Rig not found in the scene.");
                return;
            }
            isInitialized = true;
        }

        // Update the panel's position and rotation when the panel is enabled
        if (targetObject != null)
        {
            FollowTarget();
        }
        else
        {
            Debug.LogError("Target object is not assigned.");
        }
    }

    void LateUpdate()
    {
        // Continuously update the panel's position and rotation to follow the target
        if (targetObject != null)
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        // Update the panel's position
        transform.position = targetObject.transform.position + targetObject.transform.rotation * offset;

        // Update the panel's rotation to match the target's rotation
        transform.rotation = targetObject.transform.rotation;
    }
}







