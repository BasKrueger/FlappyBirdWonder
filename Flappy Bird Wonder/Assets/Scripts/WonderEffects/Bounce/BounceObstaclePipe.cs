using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BounceObstaclePipe : MonoBehaviour
{
    const float moveDuration = 0.5f;

    [HideInInspector]
    public UnityEvent birdEntered = new UnityEvent();
    [SerializeField]
    private Transform maxHeightPoint;
    [SerializeField]
    private Transform minHeightPoint;

    private bool active = false;

    private IEnumerator MoveToNextPosition()
    {
        yield return new WaitForSeconds(0.25f);

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector2(
            transform.position.x,
            Random.Range(minHeightPoint.position.y, maxHeightPoint.position.y) );

        float timer = 0;
        while(timer < moveDuration)
        {
            timer += Time.deltaTime;
            transform.position = Vector2.Lerp(startPosition, targetPosition, timer / moveDuration);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator DelayedHide()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector2(
            transform.position.x,
            0);

        float timer = 0;
        while (timer < moveDuration / 3)
        {
            timer += Time.deltaTime;
            transform.position = Vector2.Lerp(startPosition, targetPosition, timer / (moveDuration / 3));
            yield return new WaitForEndOfFrame();
        }
        GetComponent<Animator>().SetBool("visible", false);
    }

    public void Show()
    {
        active = true;
        GetComponent<Animator>().SetBool("visible", true);
    }

    public void Hide()
    {
        active = false;

        GetComponent<Collider2D>().enabled = false;
        foreach(Collider2D col in GetComponentsInChildren<Collider2D>()) { col.enabled = false; }

        StartCoroutine(DelayedHide());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!active) return;

        Bird bird = collision.transform.GetComponent<Bird>();
        if (bird != null) birdEntered?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!active) return;

        Bird bird = collision.transform.GetComponent<Bird>();
        if (bird != null) StartCoroutine(MoveToNextPosition());
    }
}
