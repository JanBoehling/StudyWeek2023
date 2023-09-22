using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] LeverManager managerLever;
    [SerializeField] GameObject leverStick;
    [SerializeField] int leverIndexer;
    private const float leverRotation = 12f;
    private Bounds bounds;

    private void Awake()
    {
        bounds = leverStick.GetComponent<Collider>().bounds;
    }

    public void Interact(Object ctx)
    {
        Vector3 pivot = transform.position;
        pivot.y -= bounds.extents.y;
        Debug.Log(pivot);
        managerLever.FlipLever(leverIndexer);
        leverStick.transform.RotateAround(pivot, Vector3.forward, managerLever.levers[leverIndexer] ? -leverRotation : leverRotation);
    }
}
