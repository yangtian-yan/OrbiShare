using UnityEngine;
using UnityEngine.Events;
using Oculus.Interaction;
using Oculus.Interaction.Input;

public class PlayerMovement : MonoBehaviour
{
    // Active state selectors for movement controls
    public ActiveStateSelector moveForwardStateSelector;
    public ActiveStateSelector additionalMoveForwardStateSelector;
    public ActiveStateSelector moveBackwardStateSelector;
    public ActiveStateSelector additionalMoveBackwardStateSelector;

    [SerializeField, Interface(typeof(IHand))]
    private Object _leftHand;

    [SerializeField, Interface(typeof(IHand))]
    private Object _rightHand;

    public OnboardingManager onboardingManager; // Reference to the OnboardingManager

    // Hand anchor and aim points
    [SerializeField]
    private Vector3 _leftAnchorPoint = new Vector3(-0.0608603321f, 0.00953984447f, 0.000258127693f);

    [SerializeField]
    private Vector3 _leftAimPoint = new Vector3(-0.0749258399f, 0.0893092677f, 0.000258127693f);

    [SerializeField]
    private Vector3 _rightAnchorPoint = new Vector3(0.0652603358f, -0.011439844f, -0.00455812784f);

    [SerializeField]
    private Vector3 _rightAimPoint = new Vector3(0.0793258473f, -0.0912092775f, -0.00455812784f);

    public float moveSpeed = 1.0f; // Speed to move the player forward or backward
    public float smoothingFactor = 0.1f; // Smoothing factor for the low-pass filter
    public float speedMultiplier = 2.0f; // Multiplier for speed when both hands are up

    public GameObject gameObjectToDeactivate; // The GameObject to deactivate when movement starts

    private IHand LeftHand { get; set; }
    private IHand RightHand { get; set; }
    private CharacterController characterController;

    private bool isMovingForwardLeft = false;
    private bool isMovingForwardRight = false;
    private bool isMovingBackwardLeft = false;
    private bool isMovingBackwardRight = false;
    private bool hasStartedMoving = false; // Track if the player has started moving

    private Vector3 smoothedDirection = Vector3.zero;

    public UnityEvent onPlayerMove; // Event to trigger when the player moves

    protected virtual void Awake()
    {
        LeftHand = _leftHand as IHand;
        RightHand = _rightHand as IHand;
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        // Subscribe to state selectors for movement detection
        SubscribeToActiveStateSelector(moveForwardStateSelector, () => isMovingForwardLeft = true, "moveForwardStateSelector");
        SubscribeToActiveStateSelector(additionalMoveForwardStateSelector, () => isMovingForwardRight = true, "additionalMoveForwardStateSelector");
        SubscribeToActiveStateSelector(moveBackwardStateSelector, () => isMovingBackwardLeft = true, "moveBackwardStateSelector");
        SubscribeToActiveStateSelector(additionalMoveBackwardStateSelector, () => isMovingBackwardRight = true, "additionalMoveBackwardStateSelector");

        // Unsubscribe from state selectors to stop movement
        UnsubscribeFromActiveStateSelector(moveForwardStateSelector, () => isMovingForwardLeft = false);
        UnsubscribeFromActiveStateSelector(additionalMoveForwardStateSelector, () => isMovingForwardRight = false);
        UnsubscribeFromActiveStateSelector(moveBackwardStateSelector, () => isMovingBackwardLeft = false);
        UnsubscribeFromActiveStateSelector(additionalMoveBackwardStateSelector, () => isMovingBackwardRight = false);
    }

    private void Update()
    {
        // Check if the player has started moving and deactivate the GameObject if not already done
        if ((isMovingForwardLeft || isMovingForwardRight || isMovingBackwardLeft || isMovingBackwardRight) && !hasStartedMoving)
        {
            hasStartedMoving = true;
            gameObjectToDeactivate.SetActive(false);
            onPlayerMove?.Invoke(); // Trigger the event when movement starts
            onboardingManager?.CompleteTask(5, 1); // Notify OnboardingManager about the movement task completion
        }

        // Reset hasStartedMoving when the GameObject is reactivated
        if (gameObjectToDeactivate.activeSelf && hasStartedMoving)
        {
            hasStartedMoving = false;
        }

        // Check for movement input and move the player accordingly
        if (isMovingForwardLeft || isMovingForwardRight)
        {
            MovePlayerForward();
        }

        if (isMovingBackwardLeft || isMovingBackwardRight)
        {
            MovePlayerBackward();
        }
    }

    private void MovePlayerForward()
    {
        Vector3? forwardDirection = null;
        float currentSpeed = moveSpeed;

        // Calculate forward direction based on hand positions
        if (isMovingForwardLeft)
        {
            forwardDirection = CalculateHandForwardDirection(LeftHand, _leftAnchorPoint, _leftAimPoint, forwardDirection);
        }

        if (isMovingForwardRight)
        {
            forwardDirection = CalculateHandForwardDirection(RightHand, _rightAnchorPoint, _rightAimPoint, forwardDirection);
        }

        // Move player forward with smoothing and speed adjustments
        if (forwardDirection.HasValue)
        {
            smoothedDirection = Vector3.Lerp(smoothedDirection, forwardDirection.Value, smoothingFactor);

            if (isMovingForwardLeft && isMovingForwardRight)
            {
                currentSpeed *= speedMultiplier; // Double the speed if both hands are up
            }

            MoveCharacter(smoothedDirection, currentSpeed);
        }
    }

    private void MovePlayerBackward()
    {
        float currentSpeed = moveSpeed;

        if (isMovingBackwardLeft && isMovingBackwardRight)
        {
            currentSpeed *= speedMultiplier; // Double the speed if both hands are up
        }

        // Move the player backward by the specified distance
        characterController.Move(-transform.forward * currentSpeed * Time.deltaTime);
    }

    private Vector3? CalculateHandForwardDirection(IHand hand, Vector3 anchorPoint, Vector3 aimPoint, Vector3? currentForwardDirection)
    {
        if (hand.GetJointPose(HandJointId.HandWristRoot, out Pose wristPose))
        {
            Vector3 anchor = wristPose.position + wristPose.rotation * anchorPoint;
            Vector3 aim = wristPose.position + wristPose.rotation * aimPoint;
            Vector3 forward = (aim - anchor).normalized;
            forward.y = 0;

            return currentForwardDirection.HasValue ? (currentForwardDirection.Value + forward).normalized : forward;
        }

        return currentForwardDirection;
    }

    private void MoveCharacter(Vector3 direction, float speed)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5.0f);
        characterController.Move(direction * speed * Time.deltaTime);
    }

    private void SubscribeToActiveStateSelector(ActiveStateSelector selector, System.Action action, string selectorName)
    {
        if (selector == null)
        {
            Debug.LogError($"{selectorName} reference is not assigned in the PlayerMovement script.");
        }
        else
        {
            selector.WhenSelected += action;
        }
    }

    private void UnsubscribeFromActiveStateSelector(ActiveStateSelector selector, System.Action action)
    {
        if (selector != null)
        {
            selector.WhenUnselected += action;
        }
    }
}

