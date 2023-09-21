using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Numpad : MonoBehaviour
{
    [SerializeField] NumberVisualizer visualizer;



    public void KeyWasPressed(int Number)
    {
        int pressedNumber = Number;
        visualizer.NumberPressed(pressedNumber);
    }

    public void DeletePresses()
    {
        visualizer.DeleteWrittenText();
        
    }

    public void RightCodeSequenze()
    {

    }
}
