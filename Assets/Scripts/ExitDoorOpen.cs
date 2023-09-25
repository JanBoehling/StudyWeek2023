using System.Collections;
using UnityEngine;

public class ExitDoorOpen : MonoBehaviour
{
    [SerializeField] private float maxOpenAngle = 140f;
    [SerializeField] private GameObject endGameTeleport;
    private bool isDoorOpened;

    public void OpenDoor()
    {
        if (!GameManager.Instance.ExitKeyPickedUp || isDoorOpened) return;
        isDoorOpened = true;
        AudioPlayer.StopAll();

        StartCoroutine(RotateDoor(maxOpenAngle));
        endGameTeleport.SetActive(true);
    }

    private IEnumerator RotateDoor(float maxAngle, float step = .1f)
    {
        var wait = new WaitForSeconds(step);
        
        while (true)
        {
            transform.RotateAroundLocal(Vector3.up, step);

            if (transform.rotation.eulerAngles.y > maxAngle) yield break;

            yield return wait;
        }
    }
}
