using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PipePair : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent<int> BirdCollided;
    [HideInInspector]
    public UnityEvent WonderEntered;

    [Header("PipePair Settings")]
    [SerializeField, Range(0,1)]
    private float WonderChance;
    [SerializeField]
    protected int scoreValue = 1;

    [Header("PipePair References")]
    [SerializeField]
    private Transform top;
    [SerializeField]
    private Transform bottom;
    [SerializeField]
    private Transform endPoint;

    [SerializeField]
    protected WonderPipe wonderPipe;
    [SerializeField]
    private TriggerZone scoreTrigger;

    private void Awake()
    {
        scoreTrigger?.triggered.AddListener(OnTriggerEnter2D);
        wonderPipe?.Entered.AddListener(WonderEntered.Invoke);

        if (Random.Range(0f, 1f) < WonderChance) ActivateWonderPipe();

        OnAwake();
    }

    protected virtual void OnAwake()
    {

    }

    public void ClampHeight(float minY, float maxY)
    {
        Vector2 newPosition = transform.position;

        if (top.position.y > maxY) 
        {
            newPosition.y -= top.position.y - maxY;
        } 
        else if (bottom.position.y < minY) 
        { 
             newPosition.y -= bottom.position.y - minY;
        }

        transform.position = newPosition;
    }

    public void ActivateWonderPipe()
    {
        wonderPipe?.gameObject.SetActive(true);
    }

    private void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(endPoint.position);

        if (Camera.main.WorldToScreenPoint(endPoint.position).x < 0) Destroy(this.gameObject);

        OnUpdate();
    }

    protected virtual void OnUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bird>() != null) BirdCollided?.Invoke(scoreValue);
    }
}
