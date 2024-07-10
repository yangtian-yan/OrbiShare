using UnityEngine;
using UnityEngine.UI;

public class ActivationCounter : MonoBehaviour
{
    public GameObject targetGameObject;
    private int activationCount = 0;
    private Text countText;

    void Awake()
    {
        countText = GetComponent<Text>();
        if (targetGameObject != null)
        {
            targetGameObject.AddComponent<ActivationTracker>().activationCounter = this;
        }
    }

    public void IncrementCount()
    {
        activationCount++;
        countText.text = activationCount.ToString() +  " Explorers have discovered this story.";
    }
}

public class ActivationTracker : MonoBehaviour
{
    public ActivationCounter activationCounter;

    void OnEnable()
    {
        if (activationCounter != null)
        {
            activationCounter.IncrementCount();
        }
    }
}

