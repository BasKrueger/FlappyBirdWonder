using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIntro : MonoBehaviour
{
    private IntroPipe pipe;
    private IntroUFO ufo;
    private IntroTutorial tutorial;

    private void Awake()
    {
        tutorial = GetComponentInChildren<IntroTutorial>(true);
        pipe = GetComponentInChildren<IntroPipe>(true);
        ufo = GetComponentInChildren<IntroUFO>(true);
    }

    public void Begin()
    {
        switch (LevelDTO.ExitMethod)
        {
            case ExitMethod.None:
                tutorial.gameObject.SetActive(true);
                break;
            case ExitMethod.Pipe:
                pipe.gameObject.SetActive(true);
                break;
            case ExitMethod.UFO:
                ufo.gameObject.SetActive(true);
                break;
        }
    }
}
