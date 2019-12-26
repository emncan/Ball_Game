using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    private bool isPlaying;
    public int numberOfLives = 3;

    void Start()
    {
        isPlaying = true;
    }
    private void Awake()
    {
        if (GameController.gameController == null)
        {
            GameController.gameController = this;
        }
        else
        {
            if (this != GameController.gameController)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(GameController.gameController.gameObject);
    }
    public bool GetGameState()
    {
        return isPlaying;
    }
    public void SetGameState(bool aGameState)
    {
        isPlaying = aGameState;
    }
    public void ReLoadCurrentScene()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneInex = currentSceneIndex + 1;

        SceneManager.LoadScene(nextSceneInex);
    }
    public int GetNumberOfLives()
    {
        return numberOfLives;
    }
    public void SetNumberOfLives(int live)
    {
         numberOfLives = live;
    }
    private void SetLifeVisuals()
    {
        GameObject myInterface = GameObject.FindGameObjectWithTag("UserInterface");
        myInterface.GetComponent<UIController>().SetLifeVisuals(numberOfLives);
    }
    public void ReduceLives(int aReductionNumber)
    {
        numberOfLives -= aReductionNumber;
        SetLifeVisuals();
        if (numberOfLives <= 0)
        {
            numberOfLives = 0;
            GameObject myInterface = GameObject.FindGameObjectWithTag("UserInterface");
            myInterface.GetComponent<UIController>().GameOver();
        }
    }
}