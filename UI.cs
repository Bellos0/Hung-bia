using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject RewardScene;
    [SerializeField] TextMeshProUGUI PointValue;
    VideoPlayer vp;
    public int score = 0;
    public static UI service;

    private void Awake()
    {
        service = this;
        gameOverUI.SetActive(false);
        RewardScene.SetActive(false);
        vp = RewardScene.GetComponent<VideoPlayer>();
        if (vp == null)
            return;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        //Time.timeScale = 0f;
    }


    [ContextMenu("reward")]
    public void RewardUI()
    {
        if (vp == null || RewardScene == null)
        {
            Debug.Log("missing videoplayer or reward scene missing");
        }
        RewardScene.SetActive(true);
        vp.loopPointReached -= OnvideoDone;
        vp.loopPointReached += OnvideoDone;
        vp.Play(); // variable belong videoplay class.
    }

    void OnvideoDone(VideoPlayer vp)
    {
        RewardScene.SetActive(false);
        GameOver();
    }

    public void Exit()
    {
        Application.Quit();


        // cai nay de debug tren unity thi van on boi
        // application.quit chi hoat dong tren ung dung sau nay
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void addPoint()
    {
        //Debug.Log("add point");
        score++;
        PointValue.text = score.ToString();

    }
}
