using UnityEngine;
using UnityEngine.UI;
using System;

public class TextSaver : MonoBehaviour
{
    public InputField inputField;
    public Text displayText;
    public Text timestampText;  // Text UI element to display the timestamp
    public Button saveButton;
    public Button closeButton;  // This seems to be used as the 'close' button based on your description
    public Button likesButton;  // Reference to the Likes Button
    public Button deleteButton;
    public GameObject additionalText; // Reference to the additional text field
    public GameObject parentGameObject; // Reference to the parent GameObject containing the timestamp text and another text
    public GameObject imageToDeactivate; // Reference to the image that should be set inactive
    public GameObject imageToActivate; // Reference to the image that should be set active
    public string saveKey = "SavedText";
    public string timestampKey = "SavedTimestamp";

    void Start()
    {
        // Clear saved text when the scene starts
        PlayerPrefs.DeleteKey(saveKey);
        PlayerPrefs.DeleteKey(timestampKey);

        // Load the saved text if available
        if (PlayerPrefs.HasKey(saveKey))
        {
            string savedText = PlayerPrefs.GetString(saveKey);
            string savedTimestamp = PlayerPrefs.GetString(timestampKey);
            inputField.text = savedText;
            displayText.text = savedText; // Display the saved text
            timestampText.text = "Saved on: " + savedTimestamp; // Display the timestamp
            displayText.gameObject.SetActive(true); // Activate the Text UI element
            parentGameObject.SetActive(true); // Activate the parent GameObject containing timestamp text and another text
            inputField.gameObject.SetActive(false); // Deactivate the InputField
            saveButton.gameObject.SetActive(false); // Deactivate the Save Button
            deleteButton.gameObject.SetActive(false);
            likesButton.gameObject.SetActive(false); // Deactivate the Likes Button initially
            closeButton.gameObject.SetActive(false); // Activate the Cancel (Close) Button
            additionalText.SetActive(false); // Deactivate the additional text field
        }
        else
        {
            displayText.gameObject.SetActive(false); // Deactivate the Text UI element if there's no saved text
            parentGameObject.SetActive(false); // Deactivate the parent GameObject if there's no saved text
            inputField.gameObject.SetActive(true); // Activate the InputField
            saveButton.gameObject.SetActive(true); // Activate the Save Button
            deleteButton.gameObject.SetActive(true);
            likesButton.gameObject.SetActive(false); // Ensure Likes button starts deactivated
            closeButton.gameObject.SetActive(true); // Activate the Cancel (Close) Button
            additionalText.SetActive(true); // Activate the additional text field
        }
    }

    public void SaveText()
    {
        // Save the input text with quotes and timestamp when called
        string textToSave = "\"" + inputField.text + "\"";
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        PlayerPrefs.SetString(saveKey, textToSave);
        PlayerPrefs.SetString(timestampKey, timestamp);
        PlayerPrefs.Save(); // Make sure to call Save() after setting PlayerPrefs
        displayText.text = textToSave; // Display the saved text
        timestampText.text = timestamp; // Display the timestamp
        displayText.gameObject.SetActive(true); // Activate the Text UI element
        parentGameObject.SetActive(true); // Activate the parent GameObject containing timestamp text and another text
        inputField.gameObject.SetActive(false); // Deactivate the InputField
        saveButton.gameObject.SetActive(false); // Deactivate the Save Button
        likesButton.gameObject.SetActive(true); // Activate the Likes Button
        closeButton.gameObject.SetActive(true); // Keep the Cancel (Close) Button active
        deleteButton.gameObject.SetActive(false);
        additionalText.gameObject.SetActive(false); // Deactivate the additional text field

        // Set the specified images' active states
        imageToDeactivate.SetActive(false); // Deactivate the image
        imageToActivate.SetActive(true); // Activate the image

        Debug.Log("Text saved successfully at " + timestamp);
    }
}




