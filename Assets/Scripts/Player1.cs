using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : SplitscreenMPController
{
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(interactKey))
        {
            Debug.Log("Do Something");
        }
    }
}
