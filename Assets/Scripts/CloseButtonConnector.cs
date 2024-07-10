using UnityEngine;
using Oculus.Interaction; 

public class CloseButtonConnector : MonoBehaviour
{
    private void Start()
    {
        // Find the RockPoseRight GameObject in the scene
        GameObject RockPoseRight = GameObject.Find("RockPoseRight");

        // Get the Active State Selector component from StopPoseRight
        if (RockPoseRight != null)
        {
            ActiveStateSelector activeStateSelector = RockPoseRight.GetComponent<ActiveStateSelector>();

            // Connect the like button to the Active State Selector
            if (activeStateSelector != null)
            {
                Close closeButton = GetComponentInChildren<Close>();

                if (closeButton != null)
                {
                    closeButton.activeStateSelector = activeStateSelector;
                }
            }
            else
            {
                Debug.LogError("ActiveStateSelector component not found on ThumbsUpLeft.");
            }
        }
        else
        {
            Debug.LogError("ThumbsUpLeft GameObject not found in the scene.");
        }
    }
}
