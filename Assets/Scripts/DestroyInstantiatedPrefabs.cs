using UnityEngine;

public class DestroyInstantiatedPrefabs : MonoBehaviour
{
    // Tag to identify the prefabs to destroy
    public string prefabTag = "Destroyable";

    // Method to destroy all instantiated prefabs with the specified tag
    public void DestroyAllPrefabs()
    {
        GameObject[] prefabs = GameObject.FindGameObjectsWithTag(prefabTag);

        foreach (GameObject prefab in prefabs)
        {
            Destroy(prefab);
        }
    }
}

