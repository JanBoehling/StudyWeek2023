using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public bool[] levers = new bool[5];
    [SerializeField] public bool[] RightLeverPattern = new bool[5];


    public void FlipLever(int index)
    {
        levers[index] = !levers[index];
    }
}
