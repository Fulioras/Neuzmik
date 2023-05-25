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
    private void Awake()
    {
        PiniguKiekis = PlayerPrefs.GetInt("LaimetiPinigai", 0) + 100;
        PradinisKiekis = PlayerPrefs.GetInt("ZaidejoPinigai", 0) - PiniguKiekis;
    }

    private void Start()
    {
        PastatytasKiekis = 0;
        // Disable the Hit and Stand buttons initially
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        dealButton.gameObject.SetActive(true);

        // Add click listeners to the buttons
        dealButton.onClick.AddListener(deal);
        hitButton.onClick.AddListener(hit);
        standButton.onClick.AddListener(stand);

        bet10.onClick.AddListener(b10);
        bet25.onClick.AddListener(b25);
        bet50.onClick.AddListener(b50);
        bet100.onClick.AddListener(b100);
        exit.onClick.AddListener(quit);
        resetBet.onClick.AddListener(betReset);

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
        // Logic for the "Deal" button
        Debug.Log("Player chose to Deal.");
        // Add your code here to start a new round or deal new cards

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
    }
    int kelintaDealerKorta = 2;
    private void stand()
    {
        DealerCard2.sprite = kortos[uzverstaKorta];
        dealerVerte += kortosVerte(uzverstaKorta);
        // Logic for the "Stand" button
        Debug.Log("stand: dHand " + dealerVerte);
        traukiaZaidejas = false;
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        while(dealerVerte < 17)
        {
            kelintaDealerKorta++;
            Debug.Log("labas" + kelintaDealerKorta);
            randomIndex = Random.Range(1, kortos.Length);
            dealerVerte += kortosVerte(randomIndex);
            if (kelintaKorta == 3)
            {
                DealerCard3.sprite = kortos[randomIndex];
                DealerCard3.gameObject.SetActive(true);
            }
            else if (kelintaKorta == 4)
            {
                DealerCard4.sprite = kortos[randomIndex];
                DealerCard4.gameObject.SetActive(true);
            }
            else if (kelintaKorta == 5)
            {
                DealerCard5.sprite = kortos[randomIndex];
                DealerCard5.gameObject.SetActive(true);
            }
            else if (kelintaKorta == 6)
            {
                DealerCard6.sprite = kortos[randomIndex];
                DealerCard6.gameObject.SetActive(true);
            }
            if(dealerVerte >= 17 && dealerVerte < 22)
            {
                ///dealer sustoja
            }else if(dealerVerte >= 17 && dealerTuzai > 0)
            {
                dealerTuzai--;
                dealerVerte -= 10;
            }
        }
        Debug.Log("stand2: dHand " + dealerVerte);
        
        end();
        
    }


    // Update is called once per frame
    int kelintaKorta = 2;
    public void hit()
    {
        
        kelintaKorta++;
        Debug.Log(kelintaKorta);
        randomIndex = Random.Range(1, kortos.Length);
        rankosVerte += kortosVerte(randomIndex);
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
    private void b10()
    {
        int naujas = PiniguKiekis / 10;
        PastatytasKiekis += naujas;
        PiniguKiekis -= naujas;
        resetBet.gameObject.SetActive(true);
        resetBet.interactable = true;
    }
    private void b25()
    {
        int naujas = PiniguKiekis / 4;
        PastatytasKiekis += naujas;
        PiniguKiekis -= naujas;
        resetBet.gameObject.SetActive(true);
        resetBet.interactable = true;
    }
    private void b50()
    {
        int naujas = PiniguKiekis / 2;
        PastatytasKiekis += naujas;
        PiniguKiekis -= naujas;
        resetBet.gameObject.SetActive(true);
        resetBet.interactable = true;
    }
    private void b100()
    {
        int naujas = PiniguKiekis;
        PastatytasKiekis += naujas;
        PiniguKiekis -= naujas;
        resetBet.gameObject.SetActive(true);
        resetBet.interactable = true;
    }

    private void end()
    {
        if(rankosVerte > 21)
        {
            
        } else if(dealerVerte > 21 && rankosVerte < 21)
        {
            PiniguKiekis += PastatytasKiekis * 2;
        } else if(dealerVerte != 21 && rankosVerte == 21)
        {
            PiniguKiekis += PastatytasKiekis * 2 + PastatytasKiekis / 2;
        } else if (dealerVerte == rankosVerte)
        {
            PiniguKiekis += PastatytasKiekis;
        } else if (dealerVerte < rankosVerte && rankosVerte < 22)
        {
            PiniguKiekis += PastatytasKiekis * 2;
        } else if (dealerVerte < 22 && dealerVerte > rankosVerte)
        { 

        }
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

        Start();
    }
    private void quit()
    {
        PlayerPrefs.SetInt("ZaidejoPinigai", PradinisKiekis + PiniguKiekis);
        SceneManager.LoadScene("Menu");
    }
}
