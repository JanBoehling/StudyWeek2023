using UnityEngine;

public class NoNoZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) => GameManager.Instance.IsInterceptingTimeTravel = true;

    private void OnTriggerExit(Collider other) => GameManager.Instance.IsInterceptingTimeTravel = false;
}
