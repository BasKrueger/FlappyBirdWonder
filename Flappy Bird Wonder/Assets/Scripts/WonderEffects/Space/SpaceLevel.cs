using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceLevel : WonderLevel
{
    [Header("Spacelevel Settings")]
    [SerializeField]
    private float asteroidSpawnRate;
    [SerializeField]
    private float coinSpawnRate;
    [SerializeField]
    private float duration;
    [SerializeField]
    private float durationVariance;

    private SpaceFactory spaceSpawner;

    protected override void OnAwake()
    {
        spaceSpawner = GetComponentInChildren<SpaceFactory>();
        StartCoroutine(CoinSpawnLoop());
        StartCoroutine(DelayedExitSpawn());
    }

    protected override IEnumerator PipeSpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / asteroidSpawnRate);
            spaceSpawner.SpawnAsteroid();
        }
    }

    private IEnumerator CoinSpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / coinSpawnRate);
            spaceSpawner.SpawnCoin();
        }
    }

    private IEnumerator DelayedExitSpawn()
    {
        yield return new WaitForSeconds(duration);
        spaceSpawner.SpawnExit();
    }
}
