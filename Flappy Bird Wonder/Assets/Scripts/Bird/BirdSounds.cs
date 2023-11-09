using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSounds : BaseSounds
{
    [SerializeField]
    private AudioSource flapSound;
    [SerializeField]
    private AudioSource hitSound;
    [SerializeField]
    private AudioSource fallSound;

    public void Play(BirdSound sound)
    {
        switch (sound)
        {
            case BirdSound.Flap:
                StartCoroutine(base.PlaySound(flapSound));
                break;
            case BirdSound.HitPipe:
                StartCoroutine(base.PlaySound(new List<AudioSource>() 
                {
                    hitSound,
                    fallSound
                }));
                break;
            case BirdSound.HitGround:
                StartCoroutine(base.PlaySound(hitSound));
                break;
        }
    }
}