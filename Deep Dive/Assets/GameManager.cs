using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject gameUI;
    public GameObject gameEndUI;
    public TMP_Text score;
    public TMP_Text depth;

    private int uiScore = 0;
    private int uiDepth = 0;

    public void GameOver()
    {
        gameUI.SetActive(false);
        gameOverUI.SetActive(true);
        
        Time.timeScale = 0;
    }

    public void GameEnd()
    {
        gameUI.SetActive(false);
        gameEndUI.SetActive(true);
        score.text = " " + uiScore;
        depth.text = " " + uiDepth;
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetDepth(float depth)
    {
        uiDepth= (int)depth;
    }

    public void SetScore(float score)
    {
        uiScore= (int)score;
    }

}
