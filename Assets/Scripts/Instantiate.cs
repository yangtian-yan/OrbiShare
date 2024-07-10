using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject myPrefab; // Assign your parent prefab in the Inspector
    private int instanceCount = 0; // Counter for unique instance names
    public OnboardingManager onboardingManager; // Reference to the OnboardingManager

    public void SpawnPrefab()
    {
        if (myPrefab != null)
        {
            // Instantiate the prefab at the origin (or any default position)
            GameObject newParentInstance = Instantiate(myPrefab, Vector3.zero, Quaternion.identity);
            newParentInstance.name = myPrefab.name + "_" + instanceCount;
            instanceCount++;

            // Get the ParentPrefabController component from the instantiated prefab
            ParentPrefabController controller = newParentInstance.GetComponent<ParentPrefabController>();

            // Ensure prefab B is registered upon instantiation
            if (controller != null)
            {
                controller.ActivatePrefabB();
            }
            else
            {
                Debug.LogError("ParentPrefabController component is missing on the instantiated prefab.");
            }

            // Notify the OnboardingManager about the task completion
            onboardingManager?.CompleteTask(6, 0); // Assuming task index 0 is for instantiating the prefab
        }
        else
        {
            Debug.LogError("Prefab is not assigned.");
        }
    }
}



