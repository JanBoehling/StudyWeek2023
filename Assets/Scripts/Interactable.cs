using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent onInteractEvent;

    private void Awake()
    {
         onInteractEvent = new();
    }

    public void Interact()
    {
        onInteractEvent?.Invoke();
    }
}
