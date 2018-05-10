using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour {
    
    public void PlayGame()
    {
        PlayerPrefs.SetInt("coins", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");

    }
}
