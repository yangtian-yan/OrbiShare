using UnityEngine;
using System.Collections;

public class KeyboardManager : MonoBehaviour
{
    public static KeyboardManager Instance { get; private set; }
    [SerializeField]
    private GameObject virtualKeyboardInstance; // Assign this in the editor

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (virtualKeyboardInstance != null)
            {
                StartCoroutine(PreloadKeyboard());
            }
            else
            {
                Debug.LogWarning("Virtual Keyboard GameObject is not assigned.");
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator PreloadKeyboard()
    {
        // Activate the virtual keyboard to preload it
        virtualKeyboardInstance.SetActive(true);

        // Wait for a frame to ensure initialization
        yield return null;

        // Deactivate the keyboard after initialization
        virtualKeyboardInstance.SetActive(false);
        Debug.Log("Virtual keyboard preloaded.");
    }

    public void ShowKeyboard()
    {
        if (virtualKeyboardInstance != null)
        {
            virtualKeyboardInstance.SetActive(true);
        }
    }

    public void HideKeyboard()
    {
        if (virtualKeyboardInstance != null)
        {
            virtualKeyboardInstance.SetActive(false);
        }
    }
}



