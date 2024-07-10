using UnityEngine;

public class EnableScripts : MonoBehaviour
{
    // Array of references to the scripts on GameObject B
    public MonoBehaviour[] scriptsToEnable;

    void OnEnable()
    {
        // Enable all the scripts in the array
        foreach (var script in scriptsToEnable)
        {
            if (script != null)
            {
                script.enabled = true;
            }
        }
    }

    void OnDisable()
    {
        // Optional: Disable all the scripts in the array when this GameObject is deactivated
        foreach (var script in scriptsToEnable)
        {
            if (script != null)
            {
                script.enabled = false;
            }
        }
    }
}


