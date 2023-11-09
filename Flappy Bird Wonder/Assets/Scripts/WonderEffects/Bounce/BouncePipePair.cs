using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BouncePipePair : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent SurvivedObstacle;

    private BounceObstaclePipe obstacle;
    private BounceExitPipe exit;
    private AudioSource bounceAudio;

    private void Awake()
    {
        obstacle = GetComponentInChildren<BounceObstaclePipe>();
        exit = GetComponentInChildren<BounceExitPipe>();
        bounceAudio = GetComponentInChildren<AudioSource>();

        obstacle.birdEntered.AddListener(SurvivedObstacle.Invoke);
        exit.bouncyCollision.AddListener(OnBounce);
    }

    public void Open()
    {
        exit.Open();
    }

    public void HideObstacle()
    {
        obstacle.Hide();
    }

    public void Close()
    {
        exit.Close();
    }

    private void OnBounce()
    {
        bounceAudio.Play();
        obstacle.Show();
    }
}
