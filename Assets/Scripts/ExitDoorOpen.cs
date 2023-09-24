using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorOpen : MonoBehaviour
{
    [SerializeField] GameObject doorOpen;
    [SerializeField] GameObject doorParent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && GameManager.Instance.ExitKeyPickedUp == true)
        {
            doorOpen.SetActive(true);
            Destroy(doorParent);
        }
    }
}
