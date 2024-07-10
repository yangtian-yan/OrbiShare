using UnityEngine;
using UnityEngine.UI;

public class InputFieldCharacterCount : MonoBehaviour
{
    public Text characterCountText;

    private InputField inputField;

    void Awake()
    {
        inputField = GetComponent<InputField>();
        if (inputField != null)
        {
            inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
        }
    }

    void OnDestroy()
    {
        if (inputField != null)
        {
            inputField.onValueChanged.RemoveListener(OnInputFieldValueChanged);
        }
    }

    void OnInputFieldValueChanged(string text)
    {
        int characterCount = text.Length;
        characterCountText.text = "Character Count: " + characterCount.ToString();
    }
}


