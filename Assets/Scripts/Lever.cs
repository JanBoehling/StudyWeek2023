using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] LeverManager managerLever;
    private float leverRotation = 12f;
    private bool leverIsTurned = true;

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && leverIsTurned == true)
        {
            this.transform.Rotate(new Vector3(0f,0f,-leverRotation));
            leverIsTurned = false;

        }
        else if(collision.collider.CompareTag("Player") && leverIsTurned == false)
        {
            this.transform.Rotate(new Vector3(0f, 0f, leverRotation));
            leverIsTurned = true;
        }
    }
}
