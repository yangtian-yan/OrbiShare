using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import Unity's UI namespace for accessing UI components
using Oculus.Interaction;

public class WindowPopUp : MonoBehaviour
{
    public GameObject sphereToShow;
    public GameObject canvasToShow;
    public Button button; // Change to Button type for UI button
    public InteractableColorVisual colorVisual;

    private GameObject selectedObject;


    private void OnEnable()
    {
        // Subscribe to the ColorChanged event
        if (colorVisual != null)
        {
            colorVisual.ColorChanged += OnColorChanged;
        }
    }

    private void OnDisable()
    {
        // Unsubscribe from the ColorChanged event
        if (colorVisual != null)
        {
            colorVisual.ColorChanged -= OnColorChanged;
        }
    }

    private void OnColorChanged(Color newColor)
    {
        // Check if the color is green
        if (newColor == Color.green)
        {
            OnInterfaceSelected();
        }
    }

    private void OnInterfaceSelected()
    {
        Debug.Log("Interface selected and color is green.");
        ButtonClick();
    }

    public void ButtonClick()
    {
        Debug.Log("Button Clicked"); // Add debug log to check if button click event is registered
        // Set the selected object
        selectedObject = gameObject;
        Debug.Log("This is a" + selectedObject);
        // Start the coroutine to handle visibility change
        StartCoroutine(ChangeVisibilityAfterDelay(selectedObject));
    }

    private IEnumerator ChangeVisibilityAfterDelay(GameObject obj)
    {
        // Wait for 0.5 seconds
        yield return new WaitForSeconds(0.5f);

        // Check if the selected object matches with either sphereToShow or button
        if (obj == sphereToShow)
            ToggleVisibility(sphereToShow, false, canvasToShow);
        else if (obj == canvasToShow) // Compare with button's GameObject
            ToggleVisibility(canvasToShow, false, sphereToShow);
    }

    private void ToggleVisibility(GameObject obj, bool visible, GameObject otherObject)
    {
        obj.SetActive(visible);
        otherObject.SetActive(!visible);
    }
}

