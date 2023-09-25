using System.Collections;
using UnityEngine;

public class OpenDoorWithKey : MonoBehaviour
{
    [SerializeField] private float maxOpenAngle = 140f;
    private bool isDoorOpened;

    public void OpenDoor()
    {
        if (!GameManager.Instance.KeyPickedUp || isDoorOpened) return;
        isDoorOpened = true;
        AudioPlayer.StopAll();

        StartCoroutine(RotateDoor(maxOpenAngle));
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
