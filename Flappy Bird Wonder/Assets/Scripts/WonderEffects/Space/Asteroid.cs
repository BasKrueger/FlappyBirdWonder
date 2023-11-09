using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : PipePair
{
    [Header("Asteroid Settings")]
    [SerializeField]
    private float scaleVariance;

    private void Awake()
    {
        transform.localScale *= 1 + Random.Range(-scaleVariance, scaleVariance);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Bird>() != null) BirdCollided?.Invoke(scoreValue);
    }
}
