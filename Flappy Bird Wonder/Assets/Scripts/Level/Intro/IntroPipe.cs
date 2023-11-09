using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPipe : MonoBehaviour
{
    private void Awake()
    {
        GetComponentInChildren<TriggerZone>().triggered.AddListener(OnTrigger);
        FindObjectOfType<Bird>().transform.position = new Vector2(FindObjectOfType<Bird>().transform.position.x, LevelDTO.ExitHeight);

        transform.position = new Vector2(transform.position.x, LevelDTO.ExitHeight);

        Destroy(this.gameObject, 3);
    }

    private void OnTrigger(Collider2D collision)
    {
        Bird bird = collision.GetComponent<Bird>();
        if(bird != null)
        {
            bird.UnLock();
        }
    }
}
