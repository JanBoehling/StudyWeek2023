using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] LeverManager managerLever;
    [SerializeField] GameObject leverStick;
    [SerializeField] int leverIndexer;
    [SerializeField] private bool[] RightLeverPattern = new bool[4];
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

        if (RightSwitchPattern())
        {
            //Open Door
        }
    }

    private bool RightSwitchPattern()
    {
        for (int i = 0; i < RightLeverPattern.Length; i++)
        {
            if (RightLeverPattern[i] != managerLever.levers[i])
            {
                return false;
            }
        }
        return true;
    }
}
