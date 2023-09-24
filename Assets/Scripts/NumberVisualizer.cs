using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class NumberVisualizer : MonoBehaviour
{
    private TextMeshProUGUI numberShower;
    private int maxNumbers = 7;
    public int CurrentNumber = -1;

    void Start()
    {
        numberShower = GetComponent<TextMeshProUGUI>(); 
    }

    public void NumberPressed(int number)
    {
        CurrentNumber++;
        if ( CurrentNumber <= maxNumbers)
        {
            numberShower.text += number.ToString();
        }
    }

    public void DeleteWrittenText()
    {
        numberShower.text = "";
        CurrentNumber = -1;
    }
}
