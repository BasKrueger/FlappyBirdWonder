using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent<Collider2D> triggered;

    public bool oneTime = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggered?.Invoke(collision);
        if (oneTime)
        {
            Destroy(this);
        }
    }
}
