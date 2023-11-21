using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    private void Start()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
