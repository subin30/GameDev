using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseButtonController : MonoBehaviour
{
    [SerializeField]
    private GameObject PausePanel;

    [SerializeField]
    private Button Resume;

    public void pauseGame()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        Resume.onClick.RemoveAllListeners();
        Resume.onClick.AddListener(() => ResumeGame());
    }
    public void ResumeGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    
    public void RestartGame()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        
     

    }
    public void GameLevel1()
    {
        SceneManager.LoadScene("level1");

    }

  
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main");
    }

  
    public void PlayerDied()
    {
        PausePanel.SetActive(true);
        Resume.onClick.RemoveAllListeners();
        Resume.onClick.AddListener(() => RestartGame());
    }

    public void GameLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void GameLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
}
