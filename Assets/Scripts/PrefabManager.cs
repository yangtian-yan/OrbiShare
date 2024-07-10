using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public static GameObject currentActivePrefabB;
    private static ParentPrefabController currentActiveController;

    public static void RegisterPrefabB(GameObject newPrefabB)
    {
        if (currentActivePrefabB != null && currentActivePrefabB != newPrefabB)
        {
            Debug.Log("Deactivating current active prefab B: " + currentActivePrefabB.name + " (InstanceID: " + currentActivePrefabB.GetInstanceID() + ")");
            currentActivePrefabB.SetActive(false);

            // Call ActivatePrefabA on the controller of the current active prefab B
            if (currentActiveController != null)
            {
                currentActiveController.ActivatePrefabA();
            }
        }

        currentActivePrefabB = newPrefabB;
        currentActiveController = newPrefabB.GetComponentInParent<ParentPrefabController>();

        Debug.Log("Current active prefab B is now: " + newPrefabB.name + " (InstanceID: " + newPrefabB.GetInstanceID() + ")");
    }
}
