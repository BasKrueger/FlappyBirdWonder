using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesGaloreLevel : WonderLevel
{
    [Header("Pipes Galore Settings")]
    [SerializeField]
    private float spawnSpeed;
    [SerializeField]
    private float pipeDeltaSpeed;
    [SerializeField]
    private float levelDuration;
    [SerializeField]
    private float levelDurationVariance;

    [Header("Pipes Galore References")]
    [SerializeField]
    private PipesGaloreSpawnManager defaultPipeSpawnManager;
    [SerializeField]
    private PipesGaloreSpawnManager coinPipeSpawnManager;

    protected override void OnAwake()
    {
        levelDuration += Random.Range(-1, 1) * levelDurationVariance;
    }

    protected override IEnumerator PipeSpawnLoop()
    {
        float heightPercent = 0.5f;
        float timer = 0;
        float coinCounter = 0;
        float directionWeight = 1;

        yield return new WaitForSeconds(2);

        while (timer < levelDuration)
        {
            if (!TrySpawnCoinPipe())
            {
                SpawnNormalPipe();
            }

            yield return new WaitForSeconds(1 / spawnSpeed);

            UpdateHeightPercent();
            UpdateDirectionWeight();
        }

        coinPipeSpawnManager.SpawnPipePair(heightPercent, true);

        #region internal functions
        bool TrySpawnCoinPipe()
        {
            coinCounter++;

            if (coinCounter % 3 == 0)
            {
                coinPipeSpawnManager.SpawnPipePair(heightPercent);
                return true;
            }
            return false;
        }

        void SpawnNormalPipe()
        {
            timer += 1 / spawnSpeed;
            defaultPipeSpawnManager.SpawnPipePair(heightPercent);
        }

        void UpdateHeightPercent()
        {
            int heightDeltaDirection = Random.Range(0f, 1f) * directionWeight > 0.5f ? 1 : -1;
            if (heightPercent == 0) heightDeltaDirection = 2;
            else if (heightPercent == 1) heightDeltaDirection = -2;

            heightPercent += pipeDeltaSpeed * heightDeltaDirection;
            heightPercent = Mathf.Clamp(heightPercent, 0, 1);
        }

        void UpdateDirectionWeight()
        {
            directionWeight += heightPercent < 0.5f ? 0.05f : -0.05f;
            directionWeight = Mathf.Clamp(directionWeight, 0.75f, 1.25f);
        }
        #endregion
    }
}
