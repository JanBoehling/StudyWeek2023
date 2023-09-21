using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NumberVisualizer : MonoBehaviour
{
    private TextMeshProUGUI numberShower;
    private int maxNumbers = 7;
    public int currentNumber;

    // Start is called before the first frame update
    void Start()
    {
        numberShower = GetComponent<TextMeshProUGUI>(); 
    }

    public void NumberPressed(int Number)
    {
        currentNumber++;
        if ( currentNumber <= maxNumbers)
        {
            numberShower.text += Number.ToString();
        }
    }

    public void DeleteWrittenText()
    {
        numberShower.text = "";
        currentNumber = 0;
    }
}
