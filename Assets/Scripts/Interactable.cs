using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    [field: SerializeField] public UnityEvent<Object> OnInteractEvent { get; set; }

    private void Awake()
    {
        OnInteractEvent = new();
    }

    public void Interact(UnityEngine.Object ctx)
    {
        OnInteractEvent?.Invoke(ctx);
    }
}
