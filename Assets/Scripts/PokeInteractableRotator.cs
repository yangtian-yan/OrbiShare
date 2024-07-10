using UnityEngine;

public class PokeInteractableRotator : MonoBehaviour
{
    public Transform pokeInteractable;  // Assign your poke interactable here

    private void OnTriggerEnter(Collider other)
    {
        // Rotate the poke interactable to face the entering object
        RotatePokeInteractable(other.transform);
    }

    private void RotatePokeInteractable(Transform targetTransform)
    {
        // Calculate direction to face
        Vector3 directionToFace = targetTransform.position - pokeInteractable.position;

        // Calculate the target rotation to directly face the target
        Quaternion targetRotation = Quaternion.LookRotation(directionToFace);

        // Apply the rotation, adjusting for the initial orientation of the poke interactable
        pokeInteractable.rotation = targetRotation;

        // Adjust the rotation to align correctly with the finger
        // You may need to tweak these values based on your specific setup
        pokeInteractable.Rotate(0, 180, 0);
    }
}



