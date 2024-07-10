using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualKeyboardActivator : MonoBehaviour
{
    public ActivateOnEnable activateOnEnable; // Reference to the ActivateOnEnable script

    // This method is called when the input field is selected
    public void OnSelect()
    {
        if (activateOnEnable != null)
        {
            activateOnEnable.Open();
        }
    }
}
