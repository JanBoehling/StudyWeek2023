using UnityEngine;

public class SplitscreenMPController : PlayerController
{
    [Header("MP camera settings")]
    [SerializeField] private Rect splitScreenViewport = new(0, 0, 1, 1);

    [Header("MP movement settings")]
    [SerializeField] private KeyCode forwardKey = KeyCode.W;
    [SerializeField] private KeyCode backwardKey = KeyCode.S;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;

    protected override void Awake()
    {
        base.Awake();

        cam.rect = splitScreenViewport;
    }

    protected override void CalculateMovementDirection(ref Vector3 movementDirection)
    {
        float xDirection;
        if (Input.GetKey(rightKey))
            xDirection = 1;
        else if (Input.GetKey(leftKey))
            xDirection = -1;
        else xDirection = 0;

        float yDirection;
        if (Input.GetKey(forwardKey))
            yDirection = 1;
        else if (Input.GetKey(backwardKey))
            yDirection = -1;
        else yDirection = 0;

        movementDirection = (xDirection * transform.right + yDirection * transform.forward).normalized;
    }
}
