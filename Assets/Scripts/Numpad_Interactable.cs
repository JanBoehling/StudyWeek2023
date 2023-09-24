using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numpad_Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject NumpadContainer;

    public void Interact(Object ctx)
    {
        NumpadContainer.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
