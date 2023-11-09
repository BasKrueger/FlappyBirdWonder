using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCage : MonoBehaviour
{
    enum BounceCageState
    {
        waiting,
        started,
        ending,
        ended
    }

    [SerializeField]
    private BouncePipePair leftPair;
    [SerializeField]
    private BouncePipePair rightPair;
    [SerializeField]
    private int pointRequirement;
    [SerializeField]
    private int pointRequirementVariance;

    private int earnedPoints = 0;
    private BounceCageState state = BounceCageState.waiting;

    private void Awake()
    {
        GetComponentInChildren<TriggerZone>().triggered.AddListener(OnTriggerEnter2D);
        leftPair.SurvivedObstacle.AddListener(OnObstacleSurvived);
        rightPair.SurvivedObstacle.AddListener(OnObstacleSurvived);

        pointRequirement += Random.Range(-pointRequirementVariance, pointRequirementVariance);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (state)
        {
            case BounceCageState.waiting:
                {
                    BouncyBird bird = collision.GetComponent<BouncyBird>();
                    if (bird != null)
                    {
                        FindObjectOfType<Level>().speedModifier = 0;

                        leftPair.Close();
                        rightPair.Close();
                        bird.MakeBouncy(true);

                        state = BounceCageState.started;
                    }
                }
                break;
            case BounceCageState.ending:
                {
                    BouncyBird bird = collision.GetComponent<BouncyBird>();
                    if (bird != null)
                    {
                        FindObjectOfType<Level>().speedModifier = 1;
                        FindObjectOfType<BouncyBird>().MakeBouncy(false);

                        state = BounceCageState.ended;
                    }
                }
                break;
        }
    }

    private void OnObstacleSurvived()
    {
        if (state != BounceCageState.started) return;

        earnedPoints++;
        if(earnedPoints % 2 == 0)
        {
            FindObjectOfType<Level>().IncreaseScore(1);

            if (earnedPoints >= pointRequirement)
            {
                rightPair.Open();
                rightPair.HideObstacle();
                leftPair.HideObstacle();
                state = BounceCageState.ending;
            }
        }
    }
}
