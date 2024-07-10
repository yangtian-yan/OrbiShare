using UnityEngine;

public class ActivateOnEnable : MonoBehaviour
{
    private GameObject objectToActivate;

    void Start()
    {
        objectToActivate = FindObjectOfType<OVRVirtualKeyboard>(true)?.gameObject;

        objectToActivate.SetActive(true);

        if (objectToActivate == null)
        {
            Debug.LogError("Virtual Keyboard GameObject not found in the scene.");
        }
    }

    void OnEnable()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }

    public void Open()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}