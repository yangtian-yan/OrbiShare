using System;
using UnityEngine;
using Oculus.Interaction;

public class ColorChangeHandler : MonoBehaviour
{
    [SerializeField]
    private InteractableColorVisual _colorVisual;

    [SerializeField]
    private GameObject _prefabToDeactivate;

    [SerializeField]
    private GameObject _prefabToActivate;

    private ParentPrefabController _parentPrefabController;

    private void OnEnable()
    {
        if (_colorVisual != null)
        {
            _colorVisual.ColorChanged += OnColorChanged;
        }
        
        // Get the ParentPrefabController component from the prefab to activate
        if (_prefabToActivate != null)
        {
            _parentPrefabController = _prefabToActivate.GetComponentInParent<ParentPrefabController>();
            if (_parentPrefabController == null)
            {
                Debug.LogError("ParentPrefabController component is missing on the parent of the prefab to activate.");
            }
        }
    }

    private void OnDisable()
    {
        if (_colorVisual != null)
        {
            _colorVisual.ColorChanged -= OnColorChanged;
        }
    }

    private void OnColorChanged(Color color)
    {
        if (color == Color.green)
        {
            if (_prefabToDeactivate != null)
            {
                _prefabToDeactivate.SetActive(false);
            }
            if (_prefabToActivate != null && _parentPrefabController != null)
            {
                _parentPrefabController.ActivatePrefabB();
            }
        }
    }

    public void InjectDependencies(InteractableColorVisual colorVisual, GameObject prefabToDeactivate, GameObject prefabToActivate)
    {
        _colorVisual = colorVisual;
        _prefabToDeactivate = prefabToDeactivate;
        _prefabToActivate = prefabToActivate;
    }
}

