using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numpad_Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject NumpadContainer;

    public void Interact(Object ctx)
    {
        NumpadContainer.SetActive(true);
        GameManager.Instance.TogglePause();
    }
}
