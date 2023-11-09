using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelCanvas : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private Animator flashAnim;
    [SerializeField]
    private Animator wonderIntro;
    [SerializeField]
    private DeathScreen deathScreen;

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void FlashScreen()
    {
        flashAnim.Play("Flash");
    }

    public void ShowDeathScreen(int score)
    {
        deathScreen.Show(score);
    }

    public void PlayLevelTransition()
    {
        wonderIntro.Play("WonderIntro");
    }
}
