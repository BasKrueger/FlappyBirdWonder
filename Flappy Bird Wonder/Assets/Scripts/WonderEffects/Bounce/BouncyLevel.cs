using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyLevel : WonderLevel
{
    protected override void OnAwake()
    {
        FindObjectOfType<WonderPipe>().BirdLocked.AddListener(base.LaodWonderLevel);
    }
}
