using UnityEngine;
using Oculus.Interaction; 

public class LikeButtonConnector : MonoBehaviour
{
    private void Start()
    {
        // Find the ThumbsUpLeft GameObject in the scene
        GameObject thumbsUpLeft = GameObject.Find("ThumbsUpLeft");

        // Get the Active State Selector component from ThumbsUpLeft
        if (thumbsUpLeft != null)
        {
            ActiveStateSelector activeStateSelector = thumbsUpLeft.GetComponent<ActiveStateSelector>();

            // Connect the like button to the Active State Selector
            if (activeStateSelector != null)
            {
                Like likeButton = GetComponentInChildren<Like>();

                if (likeButton != null)
                {
                    likeButton.activeStateSelector = activeStateSelector;
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