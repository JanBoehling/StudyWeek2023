using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform movementAnchorA;
    [SerializeField] private Transform movementAnchorB;

    [SerializeField] private Axis axis;

    // Ping pong between two given anchor objects
    private void Update()
    {
        return;
        var pos = transform.position;

        switch (axis)
        {
            case Axis.X:
                pos.x += Mathf.PingPong(pos.x, Vector3.Distance(movementAnchorA.position, movementAnchorB.position));
                break;
            case Axis.Y:
                pos.y += Mathf.PingPong(pos.y, Vector3.Distance(movementAnchorA.position, movementAnchorB.position));
                break;
            case Axis.Z:
                pos.y += Mathf.PingPong(pos.z, Vector3.Distance(movementAnchorA.position, movementAnchorB.position));
                break;
        }

        transform.position = pos;
    }
}

public enum Axis
{
    X, Y, Z
}
