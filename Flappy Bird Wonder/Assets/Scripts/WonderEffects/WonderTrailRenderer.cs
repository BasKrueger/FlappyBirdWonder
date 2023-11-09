using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WonderTrailRenderer : MonoBehaviour
{
    public void SetUp(SpriteRenderer ToCopy, float duration)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        renderer.sprite = ToCopy.sprite;
        renderer.flipX = ToCopy.flipX;
        renderer.flipY = ToCopy.flipY;

        transform.localScale = ToCopy.transform.localScale;
        transform.rotation = ToCopy.transform.rotation;
        transform.position = ToCopy.transform.position;

        GetComponent<Animator>().SetFloat("FadeSpeed", 1 / duration);
        Destroy(this.gameObject, duration);
    }
}
