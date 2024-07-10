using UnityEngine;

public class ToggleGameObjects : MonoBehaviour
{
    public GameObject onImageGameObject;
    public GameObject offImageGameObject;
    private bool isOn = true;

    public OnboardingManager onboardingManager; // Reference to the OnboardingManager

    void Start()
    {
        if (onImageGameObject == null || offImageGameObject == null)
        {
            Debug.LogError("Please assign the GameObjects in the Inspector.");
            return;
        }

        // Initialize the state
        onImageGameObject.SetActive(isOn);
        offImageGameObject.SetActive(!isOn);
    }

    public void Toggle()
    {
        isOn = !isOn;
        onImageGameObject.SetActive(isOn);
        offImageGameObject.SetActive(!isOn);

        // Notify the OnboardingManager about the state change
        if (onboardingManager != null)
        {
            if (isOn)
            {
                onboardingManager.CompleteTask(5, 2); // Assuming task index 2 is for disabling movement
            }
            else
            {
                onboardingManager.CompleteTask(5, 0); // Assuming task index 0 is for enabling movement
            }
        }
    }
}



