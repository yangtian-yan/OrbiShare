using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Oculus.Interaction;
using UnityEngine.Assertions;

public class Like : MonoBehaviour
{
    public Text likeCounterText;
    private int likeCounter = 0;
    private bool debounce = false;

    private ActiveStateSelector _activeStateSelector;

    public ActiveStateSelector activeStateSelector
    {
        get { return _activeStateSelector; }
        set
        {
            if (_activeStateSelector != null)
            {
                // Unsubscribe from the previous ActiveStateSelector
                _activeStateSelector.WhenSelected -= ThumbUpPoseActivated;
            }

            _activeStateSelector = value;

            if (_activeStateSelector != null)
            {
                // Subscribe to the new ActiveStateSelector
                _activeStateSelector.WhenSelected += ThumbUpPoseActivated;
            }
        }
    }

    private void Start()
    {
        // Ensure that the ActiveStateSelector reference is assigned
        if (activeStateSelector == null)
        {
            Debug.LogError("ActiveStateSelector reference is not assigned in the LikeButton script.");
        }
    }

    private void ThumbUpPoseActivated()
    {
        // Example: Increment the like counter when thumb-up pose is activated
        LikeCounter();
    }

    public void LikeCounter()
    {
        if (debounce) return;
        StartCoroutine(DebounceCoroutine());
        // Increment the like counter
        likeCounter++;
        // Update the text to display the new like count
        likeCounterText.text = likeCounter.ToString();
    }

    private IEnumerator DebounceCoroutine()
    {
        debounce = true;
        yield return new WaitForSeconds(0.5f); // Adjust the debounce time as needed
        debounce = false;
    }
}

