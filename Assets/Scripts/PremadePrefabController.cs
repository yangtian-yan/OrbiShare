using UnityEngine;

public class PremadePrefabController : MonoBehaviour
{
    public GameObject prefabA;
    public GameObject prefabB;
    private static int prefabBCount = 0; // Static counter to give unique names to prefabB instances

    void Start()
    {
        // Ensure initial state is correct
        ActivatePrefabA();

        // Append unique identifier to prefab B name
        prefabB.name += "_" + prefabBCount;
        prefabBCount++;
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