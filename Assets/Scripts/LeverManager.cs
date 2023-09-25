using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverManager : MonoBehaviour
{
    public bool[] Levers = new bool[6];
    [SerializeField] public bool[] RightLeverPattern = new bool[6];
    [SerializeField] private UnityEvent onRightLeverPatternEvent;

    public void FlipLever(int index)
    {
        Levers[index] = !Levers[index];

        for (int i = 0; i < RightLeverPattern.Length; i++)
        {
            if (RightLeverPattern[i] != Levers[i])
            {
                return;
            }
        }

        onRightLeverPatternEvent?.Invoke();
    }
}
