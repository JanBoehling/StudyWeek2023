using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject tutorialContainer;
    private float timer = 15f;

    private void Update()
    {
        Countdown();
    }

    private void Countdown()
    {
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q) || timer <= 0)
        {
            tutorialContainer.SetActive(false);
        }
    }
}
