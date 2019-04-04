using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    private bool pauseOn = false;
    private GameObject normalPanel;
    private GameObject pausePanel;

    private void Awake()
    {
        normalPanel = GameObject.Find("Canvas").transform.Find("NormalUI").gameObject;
        pausePanel = GameObject.Find("Canvas").transform.Find("PauseUI").gameObject;

    }

    public void ActievePauseBt()
    {
        if (!pauseOn)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            normalPanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false);
            normalPanel.SetActive(true);
        }
        pauseOn = !pauseOn;
    }

    public void RetryBt()
    {
        Debug.Log("게임 재시작.");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameScene");
    }

    public void QuitBt()
    {
        Debug.Log("게임 종료.");
        Application.Quit();
    }

}
