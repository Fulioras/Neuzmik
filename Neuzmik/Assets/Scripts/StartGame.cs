using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Game");
    }
    public void secondCutScene()
    {
        SceneManager.LoadScene("Genesis2");
    }
    public void toMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void toCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void toOptions()
    {
        SceneManager.LoadScene("Options");
    }
    public void Quit()
    {
        Application.Quit();
    }


}
