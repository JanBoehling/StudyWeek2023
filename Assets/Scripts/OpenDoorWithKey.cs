using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorWithKey : MonoBehaviour
{
    [SerializeField] GameObject doorOpen;
    [SerializeField] GameObject doorParent;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && GameManager.Instance.KeyPickedUp == true)
        {
            doorParent.SetActive(false);
            doorOpen.SetActive(true);
        }
    }
}
