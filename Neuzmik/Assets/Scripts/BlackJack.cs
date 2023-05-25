using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BlackJack : MonoBehaviour
{
    public Sprite[] kortos;
    private int rankosVerte = 0;
    private int rankosTuzai = 0;
    private int dealerVerte = 0;
    private int dealerTuzai = 0;
    private int uzverstaKorta;
    int randomIndex;

    public TextMeshProUGUI playersHand;
    public TextMeshProUGUI dealersHand;

    bool traukiaZaidejas;

    public Button hitButton;
    public Button standButton;
    public Button dealButton;

    public Button bet10;
    public Button bet25;
    public Button bet50;
    public Button bet100;
    public Button resetBet;
    public Button exit;
    public Button boardReset;

    public Image PlayerCard1;
    public Image PlayerCard2;
    public Image PlayerCard3;
    public Image PlayerCard4;
    public Image PlayerCard5;
    public Image PlayerCard6;
    
    public Image DealerCard1;
    public Image DealerCard2;
    public Image DealerCard3;
    public Image DealerCard4;
    public Image DealerCard5;
    public Image DealerCard6;


    public TextMeshProUGUI Pinigai;
    int PiniguKiekis;
    int PradinisKiekis;
    public TextMeshProUGUI PastatytiPinigai;
    int PastatytasKiekis;
    public TextMeshProUGUI WinLossStatus;
    private void Awake()
    {
        PiniguKiekis = PlayerPrefs.GetInt("LaimetiPinigai", 0);
        PradinisKiekis = PlayerPrefs.GetInt("ZaidejoPinigai", 0) - PiniguKiekis;
        
        dealButton.onClick.AddListener(deal);
        hitButton.onClick.AddListener(hit);
        standButton.onClick.AddListener(stand);
        boardReset.onClick.AddListener(Start);

        bet10.onClick.AddListener(b10);
        bet25.onClick.AddListener(b25);
        bet50.onClick.AddListener(b50);
        bet100.onClick.AddListener(b100);
        exit.onClick.AddListener(quit);
        resetBet.onClick.AddListener(betReset);
    }

    private void Start()
    {
        WinLossStatus.gameObject.SetActive(false);
        PastatytasKiekis = 0;
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        dealButton.gameObject.SetActive(true);
        boardReset.gameObject.SetActive(false);

        bet10.gameObject.SetActive(true);
        bet25.gameObject.SetActive(true);
        bet50.gameObject.SetActive(true);
        bet100.gameObject.SetActive(true);
        resetBet.gameObject.SetActive(false);

        PlayerCard3.gameObject.SetActive(false);
        PlayerCard3.sprite = kortos[0];
        PlayerCard4.gameObject.SetActive(false);
        PlayerCard4.sprite = kortos[0];
        PlayerCard5.gameObject.SetActive(false);
        PlayerCard5.sprite = kortos[0];
        PlayerCard6.gameObject.SetActive(false);
        PlayerCard6.sprite = kortos[0];

        DealerCard3.gameObject.SetActive(false);
        DealerCard3.sprite = kortos[0];
        DealerCard4.gameObject.SetActive(false);
        DealerCard4.sprite = kortos[0];
        DealerCard5.gameObject.SetActive(false);
        DealerCard5.sprite = kortos[0];
        DealerCard6.gameObject.SetActive(false);
        DealerCard6.sprite = kortos[0];

        dealerTuzai = 0;
        rankosTuzai = 0;
        rankosVerte = 0;
        dealerVerte = 0;
    }
    private void Update()
    {
        Pinigai.text = "$" + PiniguKiekis;
        PastatytiPinigai.text = "$" + PastatytasKiekis;
        if(PastatytasKiekis == 0)
        {
            dealButton.interactable = false;
            resetBet.gameObject.SetActive(false);
        }
        else
        {
            dealButton.interactable = true;
            resetBet.gameObject.SetActive(true);
        }

        if(rankosVerte == 21)
        {
            end();
        } else if (rankosVerte >= 21)
        {
            if(rankosTuzai > 0)
            {
                rankosVerte -= 10;
                rankosTuzai--;
            }
            else
            {
                end();
            }
        }
        playersHand.text = "" + rankosVerte;
        dealersHand.text = "" + dealerVerte;
    }
    private void betReset()
    {
        PiniguKiekis += PastatytasKiekis;
        PastatytasKiekis = 0;
    }

    private void deal()
    {
        dealerTuzai = 0;
        rankosTuzai = 0;
        rankosVerte = 0;
        dealerVerte = 0;
        // Logic for the "Deal" button
        Debug.Log("Player chose to Deal.");
        // Add your code here to start a new round or deal new cards

        PlayerCard3.gameObject.SetActive(false);
        PlayerCard3.sprite = kortos[0];
        PlayerCard4.gameObject.SetActive(false);
        PlayerCard4.sprite = kortos[0];
        PlayerCard5.gameObject.SetActive(false);
        PlayerCard5.sprite = kortos[0];
        PlayerCard6.gameObject.SetActive(false);
        PlayerCard6.sprite = kortos[0];


        DealerCard3.gameObject.SetActive(false);
        DealerCard3.sprite = kortos[0];
        DealerCard4.gameObject.SetActive(false);
        DealerCard4.sprite = kortos[0];
        DealerCard5.gameObject.SetActive(false);
        DealerCard5.sprite = kortos[0];
        DealerCard6.gameObject.SetActive(false);
        DealerCard6.sprite = kortos[0];

        // Enable the Hit and Stand buttons after pressing Deal
        hitButton.gameObject.SetActive(true);
        standButton.gameObject.SetActive(true);
        dealButton.gameObject.SetActive(false);
        resetBet.interactable = false;

        bet10.gameObject.SetActive(false);
        bet25.gameObject.SetActive(false);
        bet50.gameObject.SetActive(false);
        bet100.gameObject.SetActive(false);

        randomIndex = Random.Range(1, kortos.Length); //pirma dealer korta
        DealerCard1.sprite = kortos[randomIndex];
        traukiaZaidejas = false;
        dealerVerte += kortosVerte(randomIndex);

        uzverstaKorta = Random.Range(1, kortos.Length); //antra korta
        dealersHand.text = "" + dealerVerte;
        DealerCard2.sprite = kortos[0];

        randomIndex = Random.Range(1, kortos.Length); //pirma zaidejo korta
        PlayerCard1.sprite = kortos[randomIndex];
        traukiaZaidejas = true;
        rankosVerte += kortosVerte(randomIndex);
        

        randomIndex = Random.Range(1, kortos.Length); //antra zaidejo korta
        PlayerCard2.sprite = kortos[randomIndex];
        rankosVerte += kortosVerte(randomIndex);
        if(rankosVerte == 22) // jei abu tuzai
        {
            rankosVerte = 12;
            rankosTuzai = 1;
        }
        playersHand.text = "" + rankosVerte;
        kelintaDealerKorta = 2;
        kelintaKorta = 2;
    }
    int kelintaDealerKorta = 2;
    private void stand()
    {
        DealerCard2.sprite = kortos[uzverstaKorta];
        dealerVerte += kortosVerte(uzverstaKorta);
        // Logic for the "Stand" button
        Debug.Log("stand: dHand " + dealerVerte + "Phand: " + rankosVerte);
        traukiaZaidejas = false;
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        while(dealerVerte < 17)
        {
            kelintaDealerKorta++;
            Debug.Log("labas" + kelintaDealerKorta);
            randomIndex = Random.Range(1, kortos.Length);
            dealerVerte += kortosVerte(randomIndex);
            if (kelintaDealerKorta == 3)
            {
                
                DealerCard3.gameObject.SetActive(true);
                DealerCard3.sprite = kortos[randomIndex];
                Debug.Log("3 aktyvuota");
            }
            else if (kelintaDealerKorta == 4)
            {
                DealerCard4.sprite = kortos[randomIndex];
                DealerCard4.gameObject.SetActive(true);
                Debug.Log("4 aktyvuota");
            }
            else if (kelintaDealerKorta == 5)
            {
                DealerCard5.sprite = kortos[randomIndex];
                DealerCard5.gameObject.SetActive(true);
                Debug.Log("5 aktyvuota");
            }
            else if (kelintaDealerKorta == 6)
            {
                DealerCard6.sprite = kortos[randomIndex];
                DealerCard6.gameObject.SetActive(true);
                Debug.Log("6 aktyvuota");
            }
            if(dealerVerte >= 17 && dealerVerte < 22)
            {
                ///dealer sustoja
            }else if(dealerVerte >= 17 && dealerTuzai > 0)
            {
                dealerTuzai--;
                dealerVerte -= 10;
            }
            Debug.Log("after taking dhand: " + dealerVerte);
        }
        Debug.Log("stand2: dHand " + dealerVerte + "pHand: " + rankosVerte);
        
        end();
        
    }


    // Update is called once per frame
    int kelintaKorta = 2;
    public void hit()
    {
        
        kelintaKorta++;
        Debug.Log(kelintaKorta);
        randomIndex = Random.Range(1, kortos.Length);
        
        if (kelintaKorta == 3)
        {
            PlayerCard3.sprite = kortos[randomIndex];
            PlayerCard3.gameObject.SetActive(true);
        }
        else if (kelintaKorta == 4)
        {
            PlayerCard4.sprite = kortos[randomIndex];
            PlayerCard4.gameObject.SetActive(true);
        }
        else if (kelintaKorta == 5)
        {
            PlayerCard5.sprite = kortos[randomIndex];
            PlayerCard5.gameObject.SetActive(true);
        }
        else if (kelintaKorta == 6)
        {
            PlayerCard6.sprite = kortos[randomIndex];
            PlayerCard6.gameObject.SetActive(true);
        }
        rankosVerte += kortosVerte(randomIndex);

    }

    private int kortosVerte(int index)
    {
        index %= 13;
        int verte;
        if (index == 1)
        {
            verte = 11;
            if (traukiaZaidejas)
            {
                rankosTuzai++;
            }
            else
            {
                dealerTuzai++;
            }
        }
        else if (index == 11 || index == 12 || index == 0)
        {
            verte = 10;
        }
        else
        {
            verte = index;
        }
        return verte;
    }
    int naujas;
    private void b10()
    {
        naujas = PiniguKiekis / 10;
        Debug.Log(PiniguKiekis + ",: " + naujas);
        calculateBet();
    }
    private void b25()
    {
        
        naujas = PiniguKiekis / 4;
        calculateBet();
    }
    private void b50()
    {
        naujas = PiniguKiekis / 2;
        calculateBet();
    }
    private void b100()
    {
        naujas = PiniguKiekis;
        calculateBet();
    }
    private void calculateBet()
    {
        PastatytasKiekis += naujas;
        PiniguKiekis -= naujas;
        resetBet.gameObject.SetActive(true);
        resetBet.interactable = true;
        naujas = 0;
    }

    private void end()
    {
        WinLossStatus.gameObject.SetActive(true);
        if (rankosVerte > 21)
        {
            PastatytasKiekis = 0;
            Debug.Log("you Busted");
            WinLossStatus.text = "God turned away from you.. You lost";
            Debug.Log("Dhand: " + dealerVerte + " Phand: " + rankosVerte);
        }
        else if (dealerVerte > 21 && rankosVerte < 21)
        {
            PiniguKiekis += PastatytasKiekis * 2;
            Debug.Log("dealer busted");
            WinLossStatus.text = "You won! It's your lucky day!";
            Debug.Log("Dhand: " + dealerVerte + " Phand: " + rankosVerte);
        }
        else if (dealerVerte != 21 && rankosVerte == 21)
        {
            Debug.Log("Blackjack Win");
            WinLossStatus.text = "BlackJack! You must be cheating! +50% winings";
            Debug.Log("Dhand: " + dealerVerte + " Phand: " + rankosVerte);
            PiniguKiekis += PastatytasKiekis * 2 + PastatytasKiekis / 2;
        }
        else if (dealerVerte == rankosVerte)
        {
            Debug.Log("Equal");
            WinLossStatus.text = "Draw! Atleast you didn't lose anything";
            Debug.Log("Dhand: " + dealerVerte + " Phand: " + rankosVerte);
            PiniguKiekis += PastatytasKiekis;
        }
        else if (dealerVerte < rankosVerte && rankosVerte < 22)
        {
            Debug.Log("player win");
            WinLossStatus.text = "You won! You beat the system";
            Debug.Log("Dhand: " + dealerVerte + " Phand: " + rankosVerte);
            PiniguKiekis += PastatytasKiekis * 2;
        }
        else if (dealerVerte < 22 && dealerVerte > rankosVerte)
        {
            Debug.Log("Dealer win");
            WinLossStatus.text = "You lost. The dealer got the upper hand";
            Debug.Log("Dhand: " + dealerVerte + " Phand: " + rankosVerte);
            PastatytasKiekis = 0;
        }
        PastatytasKiekis = 0; 
        boardReset.gameObject.SetActive(true);
        //Start();
    }
    private void quit()
    {
        PlayerPrefs.SetInt("ZaidejoPinigai", PradinisKiekis + PiniguKiekis);
        PlayerPrefs.SetInt("LaimetiPinigai", 0);
        SceneManager.LoadScene("Menu");
    }
}
