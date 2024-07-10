using UnityEngine;

public class ActivateSphereCollider : MonoBehaviour
{
    public GameObject targetObject;

    public void ActivateCollider()
    {
        if (targetObject != null)
        {
            SphereCollider sphereCollider = targetObject.GetComponent<SphereCollider>();
            if (sphereCollider != null)
            {
                sphereCollider.enabled = true;
            }
            else
            {
                Debug.LogWarning("No SphereCollider found on the target object.");
            }
        }
        else
        {
            Debug.LogWarning("Target object is not assigned.");
        }
    }
}

