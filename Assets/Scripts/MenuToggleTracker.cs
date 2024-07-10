using UnityEngine;
using Oculus.Interaction.Samples.PalmMenu;

public class MenuToggleTracker : MonoBehaviour
{
    [SerializeField]
    private PalmMenuExample _palmMenuExample; // Reference to PalmMenuExample 

    [SerializeField]
    private OnboardingManager _onboardingManager; // Reference to OnboardingManager

    private int _menuToggleCount = 0; // Count the number of menu toggles

    private void Start()
    {
        if (_palmMenuExample != null)
        {
            _palmMenuExample.OnToggleMenu += TrackMenuToggle;
        }
    }

    private void OnDestroy()
    {
        if (_palmMenuExample != null)
        {
            _palmMenuExample.OnToggleMenu -= TrackMenuToggle;
        }
    }

    private void TrackMenuToggle()
    {
        // Increment the menu toggle count and check for task completion
        _menuToggleCount++;
        if (_menuToggleCount >= 4)
        {
            _onboardingManager.CompleteTask(4, 0); // Assuming screen 5, task 0
        }
    }
}




