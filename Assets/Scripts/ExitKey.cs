using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitKey : MonoBehaviour, IInteractable
{
    public void Interact(Object ctx)
    {
            GameManager.Instance.PickedUpExitKey();
            Destroy(gameObject);
    }
}
