using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public static int Lygis = 1;
    public void play()
    {
        if(Lygis==1){
        SceneManager.LoadScene("Game");
        }
        else if(Lygis==2){
            SceneManager.LoadScene("City_level");
        }
    }
    public void secondCutScene()
    {
        SceneManager.LoadScene("Genesis2");
        Lygis = 2;
    }
    public void toMenu()
    {
        if(EscapeMenu.inEscape){
        Time.timeScale = 1f; // unfreeze the game
        EscapeMenu.inEscape = false;
        }
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
    public void chooseLevel()
    {
        SceneManager.LoadScene("Choosing");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Dungeon()
    {
        Lygis = 1;
    }
    public void City()
    {
        Lygis = 2;
    }
}
