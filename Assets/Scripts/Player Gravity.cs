using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    private CharacterController characterController;
    public float gravity = -9.81f; // Gravity force
    public float groundCheckDistance = 0.1f; // Distance to check for ground
    public LayerMask groundMask; // Layer mask to define what is ground

    private Vector3 velocity;
    private bool isGrounded;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CheckGround();
        ApplyGravity();
    }

    private void CheckGround()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(transform.position + Vector3.down * (characterController.height / 2), groundCheckDistance, groundMask);

        // Reset velocity if grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small value to keep the player grounded
        }
    }

    private void ApplyGravity()
    {
        // Apply gravity to the velocity
        velocity.y += gravity * Time.deltaTime;
        
        // Move the character controller with the applied gravity
        characterController.Move(velocity * Time.deltaTime);
    }
}