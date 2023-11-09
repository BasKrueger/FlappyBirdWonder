using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    public void Show(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString();
    }

    public void Ok()
    {
        SceneManager.LoadScene(0);
    }
}
