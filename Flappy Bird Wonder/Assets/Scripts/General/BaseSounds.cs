using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSounds : MonoBehaviour
{
    protected IEnumerator PlaySound(AudioSource source)
    {
        AudioSource instance = Instantiate(source);
        instance.Play();
        yield return new WaitForSeconds(source.clip.length);
        Destroy(instance.gameObject);
    }

    protected IEnumerator PlaySound(List<AudioSource> sources)
    {
        foreach (AudioSource source in sources)
        {
            yield return StartCoroutine(PlaySound(source));
        }
    }
}
