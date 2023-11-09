using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockGlobalPosition : MonoBehaviour
{
    private Vector3 position;

    private void Awake()
    {
        position = transform.localPosition;
    }

    private void LateUpdate()
    {
        transform.position = position;
    }
}
