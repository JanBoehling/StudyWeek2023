using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public bool[] levers = new bool[4];
    

    public void FlipLever(int index)
    {
        levers[index] = !levers[index];
    }
}
