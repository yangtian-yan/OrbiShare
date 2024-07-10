using UnityEngine;

public class TrackPrefabMovement : MonoBehaviour
{
    public OnboardingManager onboardingManager; // Reference to the OnboardingManager

    private GameObject trackedPrefab; // Reference to the tracked prefab
    private Vector3 initialPosition; // Initial position of the tracked prefab
    private bool isPrefabMoved = false; // Flag to check if the prefab has been moved

    void Start()
    {
        // Find the instantiated prefab by name
        string prefabName = "SphereVessel_0";
        trackedPrefab = GameObject.Find(prefabName);

        if (trackedPrefab != null)
        {
            // Store the initial position of the tracked prefab
            initialPosition = trackedPrefab.transform.position;
        }
        else
        {
            Debug.LogError("Instantiated prefab not found.");
        }
    }

    void Update()
    {
        // Check if the tracked prefab has been moved
        if (trackedPrefab != null && !isPrefabMoved)
        {
            if (Vector3.Distance(trackedPrefab.transform.position, initialPosition) > 0.01f) // Check for significant movement
            {
                isPrefabMoved = true;
                onboardingManager?.CompleteTask(6, 1); // Assuming task index 1 is for moving the instantiated prefab
                Debug.Log("Prefab has been moved.");
            }
        }
    }
}

