using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BounceExitPipe : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent bouncyCollision;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Open()
    {
        anim.SetBool("open", true);
    }

    public void Close()
    {
        anim.SetBool("open", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Bird>() != null) bouncyCollision?.Invoke();
    }
}
