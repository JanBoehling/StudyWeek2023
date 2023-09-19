using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PlayerController : MonoBehaviour
{
    [Header("Fields for movement")]
    [SerializeField][Range(0, 1000)] private float baseMovementSpeed = 250f;
    [SerializeField][Range(0, 10)] private float runSpeedMultiplier = 2f;
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Fields for sneaking")]
    [SerializeField] private KeyCode sneakKey = KeyCode.LeftControl;
    [SerializeField] private float sneakSpeedMultiplier = .5f;

    [Header("Fields for jumping")]
    [SerializeField][Range(0, 100)] private float jumpPower = 5f;
    [SerializeField] private LayerMask groundCheckMask;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    [Header("Fields for looking")]
    [SerializeField] private float xSensitivity = 10f;
    [SerializeField] private float ySensitivity = 10f;
    [SerializeField] private float maxLookAngle = 80f;

    [Header("Fields for interacting")]
    [SerializeField] protected float interactDistance = 5f;
    [SerializeField] protected KeyCode interactKey = KeyCode.E;

    public bool IsSneaking { get; private set; }

    protected Camera cam;
    private Transform camTransform;

    private Rigidbody playerRigidbody;
    private Collider playerCollider;

    private float speed;
    protected Vector3 movementDirection;

    private float xRotation;
    private float yRotation;

    protected virtual void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();

        // Gets child cam
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out cam))
                break;
        }
        camTransform = cam.transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    protected virtual void Update()
    {
        CalculateMovementDirection(ref movementDirection);
        CalculateMovementSpeed();
        CalculateRotation();
        Rotate();
        if (Input.GetKeyDown(jumpKey)) Jump();
        IsSneaking = Input.GetKey(sneakKey);
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Calculates the movement direction based on the players input.
    /// </summary>
    protected virtual void CalculateMovementDirection(ref Vector3 movementDirection)
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        float yDirection = Input.GetAxisRaw("Vertical");

        movementDirection = (xDirection * transform.right + yDirection * transform.forward).normalized;
    }

    /// <summary>
    /// Sets the movement speed depending if the player presses the sprint key.
    /// </summary>
    private void CalculateMovementSpeed()
    {
        speed = Input.GetKey(sprintKey) ? baseMovementSpeed * runSpeedMultiplier : baseMovementSpeed;
        if (IsSneaking) speed *= sneakSpeedMultiplier;
    }

    /// <summary>
    /// Moves the player using the physics system.
    /// </summary>
    private void Move()
    {
        float xMovement = movementDirection.x * speed * Time.fixedDeltaTime;
        float zMovement = movementDirection.z * speed * Time.fixedDeltaTime;

        playerRigidbody.velocity = new Vector3(xMovement, playerRigidbody.velocity.y, zMovement);
    }

    /// <summary>
    /// Lets the player jump upwards when pressing the jump key.
    /// </summary>
    private void Jump()
    {
        if (!IsGrounded(playerCollider, groundCheckMask)) return;

        playerRigidbody.AddForce(jumpPower * Vector3.up, ForceMode.Impulse);
    }

    /// <summary>
    /// Checks if the player touches the ground.
    /// </summary>
    /// <returns>True, if the player touches the ground, otherwise false.</returns>
    private bool IsGrounded(Collider playerCollider, LayerMask mask)
    {
        var playerTransform = transform.position;
        var origin = new Vector3(playerTransform.x, playerTransform.y - playerCollider.bounds.extents.y, playerTransform.z);
        const float radius = .1f;

        int touchingCollidersAmount = Physics.OverlapSphereNonAlloc(origin, radius, new Collider[1], mask);

        return touchingCollidersAmount != 0;
    }

    /// <summary>
    /// Calculates the rotation for cam and player based on player input and sensitivity.
    /// </summary>
    private void CalculateRotation()
    {
        float xMouse = Input.GetAxisRaw("Mouse X");
        float yMouse = Input.GetAxisRaw("Mouse Y");

        yRotation += xMouse * xSensitivity;
        xRotation -= yMouse * ySensitivity;

        xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);
    }

    /// <summary>
    /// Rotates cam up and down and rotates player side to side.
    /// </summary>
    private void Rotate()
    {
        camTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    /// <summary>
    /// Shoots a ray infront of the player and returns the first object that was hit
    /// </summary>
    /// <typeparam name="T">The component to check for</typeparam>
    /// <param name="distance">The distance how long the ray should be shot</param>
    /// <returns>Information about the first hit object and the component that was testet for. Returns null, if nothing was found.</returns>
    protected (RaycastHit hit, T target)? LookAt<T>(float distance)
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        var hit = new RaycastHit[1];
        Physics.RaycastNonAlloc(ray, hit, distance);

        if (!hit[0].collider) return null;

        if (!hit[0].transform.TryGetComponent<T>(out var target)) return null;

        return (hit[0], target);
    }
}
