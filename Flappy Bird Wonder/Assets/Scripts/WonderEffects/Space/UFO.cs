using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    const float lerpDuration = 1.5f;

    private void Awake()
    {
        GetComponentInChildren<TriggerZone>().triggered.AddListener(OnTrigger);
    }

    private void OnTrigger(Collider2D collision)
    {
        Bird bird = collision.GetComponent<Bird>();
        if(bird != null) StartCoroutine(CaptureBird(bird));
    }

    IEnumerator CaptureBird(Bird bird)
    {
        Level level = FindObjectOfType<Level>();

        bird.Lock();
        level.speedModifier = 0;

        Vector2 startPosition = bird.transform.position;
        float time = 0;
        while(time < lerpDuration)
        {
            time += Time.deltaTime;
            bird.transform.position = Vector2.Lerp(startPosition, transform.position, time / lerpDuration);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0.5f);
        LevelDTO.ExitHeight = 0;
        LevelDTO.ExitMethod = ExitMethod.UFO;
        level.LaodWonderLevel();
    }
}
