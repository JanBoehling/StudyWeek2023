using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    public void Interact(Object ctx)
    {
        GameManager.Instance.PickUpKey();
        Debug.Log("Key picked up");
        Destroy(gameObject);
    }
}
