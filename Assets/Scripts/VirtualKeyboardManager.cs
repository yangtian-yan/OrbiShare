using UnityEngine;

public class VirtualKeyboardManager : MonoBehaviour
{
    private GameObject virtualKeyboard;

    private void Awake()
    {
        // Find the virtual keyboard in the scene, including inactive objects
        virtualKeyboard = FindObjectOfType<OVRVirtualKeyboard>(true)?.gameObject;
        if (virtualKeyboard == null)
        {
            Debug.LogError("Virtual Keyboard is not found in the scene.");
        }
    }

    public void ActivateKeyboard()
    {
        if (virtualKeyboard != null)
        {
            virtualKeyboard.SetActive(true);
            Debug.Log("Virtual Keyboard activated.");
        }
    }

    public void DeactivateKeyboard()
    {
        if (virtualKeyboard != null)
        {
            virtualKeyboard.SetActive(false);
            Debug.Log("Virtual Keyboard deactivated.");
        }
    }
}
