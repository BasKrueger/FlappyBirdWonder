using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonderTrail : MonoBehaviour
{
    [SerializeField]
    private WonderTrailRenderer trailTemplate;

    [SerializeField]
    private float trailDelay = 0.01f;
    [SerializeField]
    private float trailDuration = 2f;

    private SpriteRenderer rendererTemplate;
    private Level level;

    private void Awake()
    {
        rendererTemplate = GetComponent<SpriteRenderer>();
        level = FindObjectOfType<Level>();
    }

    private void Start()
    {
        StartCoroutine(GenerateTrail());
    }

    private IEnumerator GenerateTrail()
    {
        while (true)
        {
            yield return new WaitForSeconds(trailDelay);

            WonderTrailRenderer trail = Instantiate(trailTemplate);
            if (level != null) trail.transform.SetParent(level.transform);

            trail.SetUp(rendererTemplate, trailDuration);
        }
    }
}
