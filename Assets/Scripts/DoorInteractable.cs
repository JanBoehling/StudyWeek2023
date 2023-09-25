using UnityEngine;
using UnityEngine.Events;

public class DoorInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent onDoorInteract;

    public void Interact(Object ctx) => onDoorInteract?.Invoke();
}
