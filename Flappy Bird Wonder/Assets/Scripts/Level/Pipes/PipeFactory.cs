using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PipeFactory : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent<int> BirdCollided;
    [HideInInspector]
    public UnityEvent WonderEntered;

    [Header("PipeFactory References")]
    [SerializeField]
    private PipePair pipePairTemplate;

    [SerializeField]
    private Transform minHeightPoint;
    [SerializeField]
    private Transform maxHeightPoint;
    [SerializeField]
    private Transform pipeSpawnPoint;

    protected float minHeight;
    protected float maxHeight;
    private Vector3 pipeSpawnPosition;

    private void Awake()
    {
        pipeSpawnPosition = pipeSpawnPoint.position;
        minHeight = minHeightPoint.position.y;
        maxHeight = maxHeightPoint.position.y;

        foreach(PipePair pair in GetComponentsInChildren<PipePair>())
        {
            ConnectPipePairEvent(pair);
        }
    }

    public void SpawnPipePair()
    {
        SpawnPipePairInternal(Random.Range(minHeight + 1, maxHeight - 1));
    }

    protected void SpawnPipePairInternal(float height, bool forceWonder = false)
    {
        Vector2 spawnPoint = pipeSpawnPosition;
        spawnPoint.y = height;

        PipePair pair = Instantiate(pipePairTemplate, spawnPoint, Quaternion.identity, transform);
        pair.ClampHeight(minHeight, maxHeight);

        if (forceWonder) pair.ActivateWonderPipe();

        ConnectPipePairEvent(pair);
    }

    private void ConnectPipePairEvent(PipePair pair)
    {
        pair.BirdCollided.AddListener(BirdCollided.Invoke);
        pair.WonderEntered.AddListener(WonderEntered.Invoke);
    }
}
