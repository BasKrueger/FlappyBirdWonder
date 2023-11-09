using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFactory : MonoBehaviour
{
    [SerializeField]
    private Asteroid asteroidTemplate;
    [SerializeField]
    private Coin coinTemplate;
    [SerializeField]
    private UFO ufoTemplate;

    [SerializeField]
    private Transform minSpawnPoint;
    [SerializeField]
    private Transform maxSpawnPoint;

    private Bird bird;

    private void Awake()
    {
        bird = FindObjectOfType<Bird>();
    }

    public void SpawnAsteroid()
    {
        Asteroid asteroid = Instantiate(asteroidTemplate);
        asteroid.transform.SetParent(this.transform);

        asteroid.transform.position = GetSpawnPosition();
    }

    public void SpawnCoin()
    {
        Coin coin = Instantiate(coinTemplate);
        coin.transform.SetParent(this.transform);

        coin.transform.position = GetSpawnPosition();
    }

    public void SpawnExit()
    {
        UFO ufo = Instantiate(ufoTemplate);
        ufo.transform.SetParent(this.transform);

        ufo.transform.position = new Vector3(minSpawnPoint.position.x, 12, 0) + bird.transform.position;
    }

    private Vector2 GetSpawnPosition()
    {
        return new Vector3(
            Random.Range(minSpawnPoint.position.x, maxSpawnPoint.position.x),
            Random.Range(minSpawnPoint.position.y, maxSpawnPoint.position.y)
            )
            +
            bird.transform.position;
    }
}
