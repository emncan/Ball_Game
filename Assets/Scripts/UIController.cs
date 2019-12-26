using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    public Button replayBtn;
    public Button nextBtn;
    public Transform gameOverPanel;
    public Transform endLevelPanel;
    public Image[] lifeImages;
    void Start()
    {
        replayBtn.onClick.AddListener(Replay);
        nextBtn.onClick.AddListener(NextLevel);
        SetLifeVisuals(GameController.gameController.GetNumberOfLives());
    }

    
    void Update()
    {
        
    }
    private void Replay()
    {
        Time.timeScale = 1;    
        if(GameController.gameController.GetNumberOfLives() <= 0)
        {
            GameController.gameController.SetNumberOfLives(3);
        }
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
    }

    public void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ShowEndLevelPanel()
    {
        endLevelPanel.gameObject.SetActive(true);
        Time.timeScale = 0;

    }
    private void NextLevel()
    {
        GameController.gameController.LoadNextScene();
        Time.timeScale = 1;
    }
    public void SetLifeVisuals(int aLifeValue)
    {
        int lastIndexNoOfMyLives = aLifeValue - 1;
        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (i > lastIndexNoOfMyLives)
            {
                Color noAlphaColor = new Color(1, 1, 1, 70f / 255);
                lifeImages[i].color = noAlphaColor;
            }
            else
            {
                Color yesAlphaColor = new Color(1, 1, 1, 1);
                lifeImages[i].color = yesAlphaColor;
            }
        }
    }

}
