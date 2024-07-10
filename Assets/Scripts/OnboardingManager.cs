using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class ScreenTaskIcons
{
    public GameObject[] taskIcons; // Array of task icon GameObjects for this screen
}

public class OnboardingManager : MonoBehaviour
{
    public GameObject[] screens; // Array to hold the screen prefabs
    public GameObject onboardingProcess; // The GameObject containing the entire onboarding process
    private int currentScreenIndex = 0;

    // Array to hold task icons for each screen
    public ScreenTaskIcons[] screenTaskIcons;

    private bool[][] taskCompletion; // Track completion of each task

    public Sprite checkedIcon; // Reference to the checked icon sprite

    void Start()
    {
        InitializeTaskCompletion();
        ShowScreen(currentScreenIndex);
    }

    void InitializeTaskCompletion()
    {
        taskCompletion = new bool[screens.Length][];
        for (int i = 0; i < screens.Length; i++)
        {
            if (i >= 4 && i < screenTaskIcons.Length && screenTaskIcons[i] != null && screenTaskIcons[i].taskIcons != null)
            {
                taskCompletion[i] = new bool[screenTaskIcons[i].taskIcons.Length];
                for (int j = 0; j < screenTaskIcons[i].taskIcons.Length; j++)
                {
                    taskCompletion[i][j] = false;
                }
            }
            else
            {
                taskCompletion[i] = new bool[0];
                Debug.LogWarning($"ScreenTaskIcons[{i}] is not properly initialized. Ensure you have set up the array correctly in the inspector.");
            }
        }
    }

    public void ShowScreen(int index)
    {
        // Deactivate all screens
        foreach (GameObject screen in screens)
        {
            screen.SetActive(false);
        }

        // Activate the selected screen
        if (index >= 0 && index < screens.Length)
        {
            screens[index].SetActive(true);
            currentScreenIndex = index;

            // Play the voice-over audio for the current screen
            AudioSource audioSource = screens[index].GetComponent<AudioSource>();
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
        }
    }

    public void NextScreen()
    {
        ShowScreen(currentScreenIndex + 1);
    }

    public void PreviousScreen()
    {
        ShowScreen(currentScreenIndex - 1);
    }

    public void CloseOnboarding()
    {
        // Deactivate the entire onboarding process
        onboardingProcess.SetActive(false);
        Debug.Log("Onboarding Closed");
    }

    public void SkipOnboarding()
    {
        // Deactivate the entire onboarding process
        onboardingProcess.SetActive(false);
        Debug.Log("Onboarding Skipped");
    }

    public void StartOnboarding()
    {
        // Reset and show the first screen
        currentScreenIndex = 0;
        onboardingProcess.SetActive(true);
        ShowScreen(currentScreenIndex);
        Debug.Log("Onboarding Started");
    }

    public void CompleteTask(int screenIndex, int taskIndex)
    {
        Debug.Log($"CompleteTask called for screenIndex: {screenIndex}, taskIndex: {taskIndex}");

        if (screenIndex >= 4 && screenIndex < screens.Length && screenTaskIcons[screenIndex] != null)
        {
            if (taskIndex >= 0 && taskIndex < screenTaskIcons[screenIndex].taskIcons.Length)
            {
                taskCompletion[screenIndex][taskIndex] = true;
                Debug.Log($"Task completion registered for screenIndex: {screenIndex}, taskIndex: {taskIndex}");

                GameObject taskIcon = screenTaskIcons[screenIndex].taskIcons[taskIndex];
                Image imageComponent = taskIcon.GetComponent<Image>();

                if (imageComponent != null)
                {
                    Debug.Log($"Updating icon for screenIndex: {screenIndex}, taskIndex: {taskIndex}");
                    imageComponent.sprite = checkedIcon;
                    Debug.Log($"Icon updated to checkedIcon for screenIndex: {screenIndex}, taskIndex: {taskIndex}");
                }
                else
                {
                    Debug.LogWarning($"Image component not found for taskIcon in screenIndex: {screenIndex}, taskIndex: {taskIndex}");
                }
            }
            else
            {
                Debug.LogWarning($"Invalid taskIndex in CompleteTask: screenIndex: {screenIndex}, taskIndex: {taskIndex}");
            }
        }
        else
        {
            Debug.LogWarning($"Invalid screenIndex or uninitialized screenTaskIcons in CompleteTask: screenIndex: {screenIndex}, taskIndex: {taskIndex}");
        }
    }
}



