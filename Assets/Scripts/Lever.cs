using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] LeverManager managerLever;
    [SerializeField] GameObject leverStick;
    [SerializeField] GameObject doorOpener;
    [SerializeField] GameObject doorParent;
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
        leverStick.transform.RotateAround(pivot, Vector3.forward, managerLever.Levers[leverIndexer] ? -leverRotation : leverRotation);

        //if (RightSwitchPattern())
        //{
        //    doorParent.SetActive(false);
        //    doorOpener.SetActive(true);
        //    //Open Door
        //    Debug.Log("Door Opens");
        //}
    }

    private bool RightSwitchPattern()
    {
        for (int i = 0; i < managerLever.RightLeverPattern.Length; i++)
        {
            if (managerLever.RightLeverPattern[i] != managerLever.Levers[i])
            {
                return false;
            }
        }
        return true;
    }
}
