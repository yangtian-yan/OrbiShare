using UnityEngine;
using UnityEngine.UI; // Add this to handle UI elements like buttons

public class ToggleObjects : MonoBehaviour
{
    // References to the GameObjects you want to toggle
    public GameObject objectToActivate;

    void Start()
    {
        // Optional: Initialization code if needed
    }
    
    void OnEnable()
    {
        // Get the Button component attached to this GameObject
        Button button = GetComponent<Button>();
        if (button != null)
        {
            // Add a listener to call the Toggle method when the button is clicked
            button.onClick.AddListener(Toggle);
        }
        else
        {
            Debug.LogError("No Button component found on this GameObject.");
        }
    }
    
    void OnDisable()
    {
        // Remove the listener to prevent multiple calls
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.RemoveListener(Toggle);
        }
    }
    
    // Method to be called when the button is clicked
    public void Toggle()
    {
        // Check if the objects are set
        if (objectToActivate != null)
        {
            // Activate the first object and deactivate the second one
            objectToActivate.SetActive(!objectToActivate.activeSelf);
        }
        else
        {
            // Find the GameObject named "Body Backdrop"
            GameObject objectToDeactivate = GameObject.Find("Body Backdrop");
            if (objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(false);
            }
            else
            {
                Debug.LogError("GameObject 'Body Backdrop' not found.");
            }
        }
    }
}


