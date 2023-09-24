using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Numpad : MonoBehaviour
{
    [SerializeField] NumberVisualizer visualizer;
    [SerializeField] private List<int> correctCode = new List<int>();
    [SerializeField] private List<int> typedCode = new List<int>();
    [SerializeField] private GameObject NumpadContainer;
    [SerializeField] private GameObject lockerClosed;
    [SerializeField] private GameObject lockerOpen;
    private int correctCodeIsTyped;


    public void KeyWasPressed(int Number)
    {
        int pressedNumber = Number;
        visualizer.NumberPressed(pressedNumber);
        typedCode.Add(pressedNumber);
            
    }

    public void DeletePresses()
    {
        if (typedCode.Count == 0)
        {
            NumpadContainer.SetActive(false);
            GameManager.Instance.TogglePause();
        }
        visualizer.DeleteWrittenText();
        typedCode.Clear();
    }

    public void RightCodeSequenze()
    {
        for (int i = 0; i < correctCode.Count; i++)
        {
            if (typedCode.Count == 0)
            {
                break;
            }
            int correctCodeInv = correctCode[i];
            int typedCodeInv = typedCode[i];

            if (correctCodeInv == typedCodeInv)
            {
                correctCodeIsTyped++;
                continue;
            }
            else
            {
                correctCodeIsTyped = 0;
                break;
            }
        }

        if (correctCodeIsTyped == 4)
        {
            Debug.Log("Open Locker");
            NumpadContainer.SetActive(false);
            GameManager.Instance.TogglePause();

            lockerClosed.SetActive(false);
            lockerOpen.SetActive(true);
        }
    }
}
