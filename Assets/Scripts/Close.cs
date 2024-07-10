using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Oculus.Interaction;
using UnityEngine.Assertions;

public class Close : MonoBehaviour
{
    public GameObject canvasToClose;
    public GameObject gameObjectToActivate; // Reference to the GameObject to be activated

    private GameObject virtualKeyboard;

    private ActiveStateSelector _activeStateSelector;

    public ActiveStateSelector activeStateSelector
    {
        get { return _activeStateSelector; }
        set
        {
            if (_activeStateSelector != null)
            {
                // Unsubscribe from the previous ActiveStateSelector
                _activeStateSelector.WhenSelected -= CloseObject;
            }

            _activeStateSelector = value;

            if (_activeStateSelector != null)
            {
                // Subscribe to the new ActiveStateSelector
                _activeStateSelector.WhenSelected += CloseObject;
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

    public void CloseObject()
    {
        // Ensure we have the latest reference to the virtual keyboard
        if (virtualKeyboard == null)
        {
            virtualKeyboard = FindObjectOfType<OVRVirtualKeyboard>(true)?.gameObject;
        }

        // Deactivate the canvas when the close button is clicked
        if (canvasToClose != null)
        {
            canvasToClose.SetActive(false);
        }
        else
        {
            Debug.LogError("Canvas to close is not assigned.");
        }

        // Activate the specified GameObject
        if (gameObjectToActivate != null)
        {
            gameObjectToActivate.SetActive(true);
        }
        else
        {
            Debug.LogError("GameObject to activate is not assigned.");
        }

        // Deactivate the virtual keyboard
        if (virtualKeyboard != null)
        {
            virtualKeyboard.SetActive(false);
        }
        else
        {
            Debug.LogError("Virtual Keyboard is not found.");
        }
    }

    public void CloseKeyboard()
    {
        // Ensure we have the latest reference to the virtual keyboard
        if (virtualKeyboard == null)
        {
            virtualKeyboard = FindObjectOfType<OVRVirtualKeyboard>(true)?.gameObject;
        }
        // Deactivate the virtual keyboard
        if (virtualKeyboard != null)
        {
            virtualKeyboard.SetActive(false);
        }
        else
        {
            Debug.LogError("Virtual Keyboard is not found.");
        }
    }
}


