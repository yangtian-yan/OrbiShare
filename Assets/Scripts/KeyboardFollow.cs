using UnityEngine;

public class KeyboardFollow : MonoBehaviour
{
    public GameObject targetObject; // The GameObject that the keyboard will follow
    public Vector3 offset = new Vector3(0f, 0f, 0f); // Adjust the offset as needed
    public Vector3 tilt = new Vector3(0f, 30f, 0f); // Adjust the tilt as needed (e.g., 30 degrees around the X-axis)

    void OnEnable()
    {
        // Ensure the targetObject is assigned
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
        // Continuously update the keyboard's position and rotation to follow the target
        if (targetObject != null)
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        // Update the keyboard's position
        transform.position = targetObject.transform.position + targetObject.transform.rotation * offset;

        // Update the keyboard's rotation to match the target's rotation with an additional tilt
        Quaternion targetRotation = targetObject.transform.rotation * Quaternion.Euler(tilt);
        transform.rotation = targetRotation;
    }
}


