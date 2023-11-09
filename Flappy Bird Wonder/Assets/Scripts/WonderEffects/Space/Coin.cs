using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private Transform endPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Level>().IncreaseScore(1);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(endPoint.position);

        if (Camera.main.WorldToScreenPoint(endPoint.position).x < 0) Destroy(this.gameObject);
    }
}
