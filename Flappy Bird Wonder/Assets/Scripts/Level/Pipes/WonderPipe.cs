using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WonderPipe : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent Entered;
    [HideInInspector]
    public UnityEvent BirdLocked;

    private void Awake()
    {
        GetComponentInChildren<TriggerZone>().triggered.AddListener(OnAboutToEnter);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bird>() == null) return;
        Entered?.Invoke();
        Destroy(GetComponent<Collider>());
    }

    private void OnAboutToEnter(Collider2D collision)
    {
        Bird bird = collision.GetComponent<Bird>();
        if(bird != null)
        {
            bird.Lock();
            LevelDTO.ExitHeight = transform.position.y;
            LevelDTO.ExitMethod = ExitMethod.Pipe;
            BirdLocked?.Invoke();
        }
    }
}
