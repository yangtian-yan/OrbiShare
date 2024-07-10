using UnityEngine;

public class MatchPosition : MonoBehaviour
{
    public GameObject referenceObject; // Assign the prefab with PanelFollow script in the Inspector

    void Start()
    {
        if (referenceObject != null)
        {
            // Set this object's position to match the reference object's position
            transform.position = referenceObject.transform.position;
        }
        else
        {
            Debug.LogError("Reference object is not assigned.");
        }
    }
}

