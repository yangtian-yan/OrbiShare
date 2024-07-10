using UnityEngine;

public class ParentPrefabController : MonoBehaviour
{
    public GameObject prefabA;
    public GameObject prefabB;
    private static int prefabBCount = 0; // Static counter to give unique names to prefabB instances
    private static int prefabACount = 0; // Static counter to give unique names to prefabA instances

    void Start()
    {
        // Ensure initial state is correct
        ActivatePrefabB();

        // Append unique identifier to prefab B name
        prefabB.name += "_" + prefabBCount;
        prefabBCount++;

        // Append unique identifier to prefab B name
        prefabA.name += "_" + prefabACount;
        prefabACount++;
    }

    public void ActivatePrefabB()
    {
        Debug.Log("Activating prefab B: " + prefabB.name + " in " + gameObject.name);
        prefabB.SetActive(true);
        prefabA.SetActive(false);
        PrefabManager.RegisterPrefabB(prefabB);
    }

    public void ActivatePrefabA()
    {
        Debug.Log("Activating prefab A: " + prefabA.name + " in " + gameObject.name);
        prefabA.SetActive(true);
        prefabB.SetActive(false);
    }
}