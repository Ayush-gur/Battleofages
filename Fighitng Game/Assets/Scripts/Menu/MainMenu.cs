using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource gameStart;

    private void Start()
    {
        if(gameStart == null)
        {
            gameStart = GameObject.Find("MatchStart").GetComponent<AudioSource>();
        }
    }
    public void PlayGame()
    {
        gameStart.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
