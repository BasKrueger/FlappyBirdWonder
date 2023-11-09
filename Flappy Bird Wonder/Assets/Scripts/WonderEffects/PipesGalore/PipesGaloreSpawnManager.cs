using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesGaloreSpawnManager : PipeFactory
{
    public void SpawnPipePair(float heightPercent, bool forceExit = false)
    {
        SpawnPipePairInternal((maxHeight - minHeight) * heightPercent + minHeight, forceExit);
    }
}
