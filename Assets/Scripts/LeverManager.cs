using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    private bool[] levers = new bool[4];
    

    public void FlipLever(int index)
    {
        levers[index] = !levers[index];
    }
}
