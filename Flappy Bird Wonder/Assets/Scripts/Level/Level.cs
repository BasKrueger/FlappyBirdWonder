using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField]
    private float speed;
    [SerializeField]
    protected float pipeSpawnDelay = 2f;

    [NonSerialized]
    public float speedModifier = 1;

    private PipeFactory pipes;
    private LevelSounds sound;
    private LevelCanvas ui;
    private LevelIntro intro;

    private int score = 0;

    private void Awake()
    {
        pipes = GetComponentInChildren<PipeFactory>();
        sound = GetComponentInChildren<LevelSounds>();
        ui = GetComponentInChildren<LevelCanvas>();
        intro = GetComponentInChildren<LevelIntro>();

        FindObjectOfType<Bird>().Died.AddListener(EndLevel);

        pipes?.BirdCollided.AddListener(IncreaseScore);
        pipes?.WonderEntered.AddListener(LaodWonderLevel);

        score = LevelDTO.Score;
        ui.UpdateScore(score);

        OnAwake();
    }

    protected virtual void OnAwake()
    {

    }

    private void Start()
    {
        StartCoroutine(PipeSpawnLoop());
        StartCoroutine(MoveLoop());
        intro.Begin();
    }

    public void LaodWonderLevel()
    {
        ui.PlayLevelTransition();
        sound.Play(LevelSound.Transition);
        speed /= 2;
        LevelDTO.Score = score;

        StartCoroutine(LoadWonderLevelDelayed());
    }

    private void EndLevel()
    {
        StopAllCoroutines();
        ui.FlashScreen();
        ui.ShowDeathScreen(score);

        LevelDTO.Reset();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;

        sound.Play(LevelSound.ScoreIncrease);
        ui.UpdateScore(score);
    }

    protected virtual IEnumerator LoadWonderLevelDelayed()
    {
        yield return new WaitForSeconds(1);
        StopAllCoroutines();
        SceneManager.LoadScene(UnityEngine.Random.Range(1, SceneManager.sceneCountInBuildSettings));
    }

    protected virtual IEnumerator PipeSpawnLoop()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            float timer = 0;
            while(timer <= pipeSpawnDelay * (1/speedModifier))
            {
                yield return new WaitForEndOfFrame();
                timer += Time.deltaTime;
            }
            pipes?.SpawnPipePair();
        }
    }

    private IEnumerator MoveLoop()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            transform.position += new Vector3(-speed * speedModifier, 0) * Time.deltaTime;
        }
    }
}
