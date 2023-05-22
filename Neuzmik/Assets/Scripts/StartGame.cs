using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGame : MonoBehaviour
{

    public static int Lygis = 1;
    public TextMeshProUGUI pirmasMygtukas;
    public TextMeshProUGUI antrasMygtukas;
    public TextMeshProUGUI treciasMygtukas;
    public GameObject KetvirtasMygtukas;
    public static int etapas = 1;

    void Start()
    {
        if(etapas == 2){
        KetvirtasMygtukas.SetActive(false);
        pirmasMygtukas.text = "CHOOSING";
        antrasMygtukas.text = "UPGRADES";
        treciasMygtukas.text = "BACK";
        }
    }
        public void PlayButton()
    {
        if(etapas == 1){
        etapas = 2;
        KetvirtasMygtukas.SetActive(false);
        pirmasMygtukas.text = "CHOOSING";
        antrasMygtukas.text = "UPGRADES";
        treciasMygtukas.text = "BACK";
        }
        else if(etapas == 2){
            SceneManager.LoadScene("Choosing");
        }
    }
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
        etapas = 1;
        Time.timeScale = 1f;
        if(EscapeMenu.inEscape){
        EscapeMenu.inEscape = false;
        }
        SceneManager.LoadScene("Menu");
    }
    public void toCredits()
    {
        if(etapas == 1){
            SceneManager.LoadScene("Credits");
        }
        else{
            etapas = 1;
        KetvirtasMygtukas.SetActive(true);
        pirmasMygtukas.text = "PLAY";
        antrasMygtukas.text = "OPTIONS";
        treciasMygtukas.text = "CREDITS";
        }
    }
    public void toOptions()
    {
        SceneManager.LoadScene("Options");
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

    public void toMenuEtapas2()
    {
        SceneManager.LoadScene("Menu");
        etapas = 2;
    }
}
