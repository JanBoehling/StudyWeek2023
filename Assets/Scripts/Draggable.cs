using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Draggable : MonoBehaviour, IInteractable
{
    [field: SerializeField] public UnityEvent<Object> OnInteractEvent { get; set; }

    [SerializeField] private float playerPositionOffset;

    private Transform carrier;
    private bool isDragged;


    private void Update()
    {
        if (!isDragged) return;

        // Player should be locked to obj pos

        // Player movement should be translated to obj
        transform.position = carrier.position;
    }

    public void Interact(Object ctx)
    {
        OnInteractEvent?.Invoke(ctx);
    }

    public void ToggleDrag(UnityEngine.Object ctx)
    {
        var player = ctx as GameObject;

        carrier = player.transform;
        isDragged = !isDragged;

        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Interactable"), isDragged);
    }
}
