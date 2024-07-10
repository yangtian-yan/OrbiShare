using UnityEngine;

public class DeleteObjectOnClick : MonoBehaviour
{
    // The GameObject to be deleted
    public GameObject targetObject;

    // Method to delete the target object
    public void DeleteGameObject()
    {
        if (targetObject != null)
        {
            Destroy(targetObject);
            Debug.Log("GameObject deleted: " + targetObject.name);
        }
        else
        {
            Debug.LogError("No target object assigned.");
        }
    }
}

