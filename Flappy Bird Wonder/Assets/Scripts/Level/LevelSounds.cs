using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSounds : BaseSounds
{
    [SerializeField]
    private AudioSource scoreIncrease;
    [SerializeField]
    private AudioSource transition;

    public void Play(LevelSound sound)
    {
        switch (sound)
        {
            case LevelSound.ScoreIncrease:
                StartCoroutine(PlaySound(scoreIncrease));
                break;
            case LevelSound.Transition:
                StartCoroutine(PlaySound(transition));
                break;
        }
    }
}
