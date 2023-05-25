using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escapeMenuUI;
    public static bool inEscape = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inEscape == false)
        {
            Time.timeScale = 0f; // freeze the game
            escapeMenuUI.SetActive(true); // display the escape menu UI
            inEscape = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && inEscape == true){
            if(!OptionsMeniu.openedOptions){
        Time.timeScale = 1f; // unfreeze the game
        escapeMenuUI.SetActive(false); // hide the escape menu UI
        inEscape = false;
        }
        }
    }

    
    public void Quit()
    {
        Application.Quit(); // quit the game
    }
    public void Atgal()
    {
        Time.timeScale = 1f; // unfreeze the game
        escapeMenuUI.SetActive(false); // hide the escape menu UI
        inEscape = false;
        
    }
}
