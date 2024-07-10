using UnityEngine;
using UnityEngine.UI;

public class InputFieldConnector : MonoBehaviour
{
    private GameObject virtualKeyboard;

    private void Start()
    {
        // Find the virtual keyboard input field handler in the scene
        OVRVirtualKeyboardInputFieldTextHandler keyboardHandler = FindObjectOfType<OVRVirtualKeyboardInputFieldTextHandler>();
        
        // Get the InputField component in this prefab
        InputField inputField = GetComponentInChildren<InputField>();

        // Connect the input field to the virtual keyboard
        if (keyboardHandler != null && inputField != null)
        {
            keyboardHandler.InputField = inputField;
        }

        if (virtualKeyboard == null)
        {
            virtualKeyboard = GameObject.Find("[Building Block] Virtual Keyboard");
        }
    }

}
