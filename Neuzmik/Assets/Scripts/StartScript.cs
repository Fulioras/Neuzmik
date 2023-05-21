using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScript : MonoBehaviour
{
    public void play()
    {
        if(ChooseMap.selectedMapIndex == 0){
            SceneManager.LoadScene("Game");
        }
        else if(ChooseMap.selectedMapIndex == 1){
            SceneManager.LoadScene("City_level");
        }
    }
}
