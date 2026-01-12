using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject RewoardScene;
   [SerializeField] TextMeshProUGUI PointValue;
   int score;
    public static UI service;

    private void Awake()
    {
        service = this;
        score = 0;
    }
  public  void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   public void GameOver()
    {
        gameOverUI.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void RewardUI()
    {
       //RewoardScene.SetActive(true);
    }
   public void addPoint()
    {
        Debug.Log("add point");
        score++;
        PointValue.text = score.ToString();

    }
}
