using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputFieldClickDetector : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (KeyboardManager.Instance != null)
        {
            KeyboardManager.Instance.ShowKeyboard();
            InputFieldConnect();
            Debug.Log("Input Field Clicked! Virtual Keyboard activated.");
        }
        else
        {
            Debug.LogWarning("KeyboardManager instance not found.");
        }
    }

    public void InputFieldConnect()
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
    }
}


