using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJack : MonoBehaviour
{
    public Sprite[] kortos;
    private int rankosVerte = 0;
    int randomIndex;


    // Update is called once per frame
    public void hit()
    {
        
        

        pasirenkamKorta();
        randamRankosVerte();


        if (rankosVerte == 21)
        {
            Debug.Log("laim4jai");
            rankosVerte = 0;
            
        }
        else if (rankosVerte > 21)
        {
            Debug.Log("busted");
            rankosVerte = 0;
        }

    }
    int pasirenkamKorta()
    {
        randomIndex = Random.Range(1, kortos.Length);
        Sprite randomSprite = kortos[randomIndex];

        // Create a new GameObject to display the card sprite
        GameObject card = new GameObject("Card");
        card.transform.position = transform.position;

        // Add a SpriteRenderer component to display the sprite
        SpriteRenderer renderer = card.AddComponent<SpriteRenderer>();
        renderer.sprite = randomSprite;
        Debug.Log(randomIndex % 13);
        return randomIndex;

    }
    private void randamRankosVerte()
    {
        randomIndex %= 13;
        if (randomIndex == 1)
        {
            if (rankosVerte + 11 > 21)
            {
                rankosVerte += 1;
            }else
            {
                rankosVerte += 11;
            }
        }
        else if(randomIndex == 11 || randomIndex == 12 || randomIndex == 0)
        {
            rankosVerte += 10;
        } else
        {
            rankosVerte += randomIndex;
        }
        
        Debug.Log("rankoje: " + rankosVerte);
    }
}
