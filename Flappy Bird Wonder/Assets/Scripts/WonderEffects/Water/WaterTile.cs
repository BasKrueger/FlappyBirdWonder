using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile : GroundTile
{
    private Level level;
    private void Awake()
    {
        level = FindObjectOfType<Level>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Bird bird = collision.GetComponent<Bird>();

        if (bird == null || level.speedModifier <= 0) return;

        level.speedModifier = 0.75f;
        bird.jumpForce = 2.75f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Bird bird = collision.GetComponent<Bird>();
        if (bird == null || level.speedModifier <= 0) return;

        level.speedModifier = 1f;
        bird.jumpForce = 3.5f;
    }
}
