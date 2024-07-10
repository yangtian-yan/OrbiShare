using UnityEngine;

public class ActivateOnDeactivate : MonoBehaviour
{
    public GameObject targetGameObject; // The GameObject to activate

    void OnDisable()
    {
        if (targetGameObject != null)
        {
            targetGameObject.SetActive(true);
        }
    }
}

