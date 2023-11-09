using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroUFO : MonoBehaviour
{
    const float lerpDuration = 1.5f;

    private void OnEnable()
    {
        StartCoroutine(FreeBird());
    }

    private IEnumerator FreeBird()
    {
        Bird bird = FindObjectOfType<Bird>();
        Level level = FindObjectOfType<Level>();

        bird.Lock();
        level.speedModifier = 0;

        float time = 0;
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = new Vector2(bird.transform.position.x, 0);
        while (time < lerpDuration)
        {
            time += Time.deltaTime;
            bird.transform.position = Vector2.Lerp(startPosition, targetPosition, time / lerpDuration);
            yield return new WaitForEndOfFrame();
        }

        level.speedModifier = 1;
        bird.UnLock();
    }
}
