using UnityEngine;

public class DeactivateOnActivate : MonoBehaviour
{
    public GameObject targetGameObject; // The GameObject to deactivate

    void OnEnable()
    {
        if (targetGameObject != null)
        {
            targetGameObject.SetActive(false);
        }
    }
}

