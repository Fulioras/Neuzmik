using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillPoints : MonoBehaviour
{
    public int playerPoints;
    public TextMeshProUGUI Tekstas;
    public GameObject[] PiniguNuotraukos;
    public GameObject[] healthNuotraukos;
    public GameObject[] movementNuotraukos;
    public GameObject[] damageNuotraukos;
    public int pinigai;
    public int health;
    public int movement;
    public int damage;

    void Start()
    {
        
        playerPoints = PlayerPrefs.GetInt("PlayerPoints", 0);
        pinigai = PlayerPrefs.GetInt("PiniguUpgrade", 0);
        health = PlayerPrefs.GetInt("HealthUpgrade", 0);
        movement = PlayerPrefs.GetInt("MovementUpgrade", 0);
        damage = PlayerPrefs.GetInt("DamageUpgrade", 0);

        Debug.Log(pinigai);
        Debug.Log(health);
        Debug.Log(movement);
        Debug.Log(damage);
        for(int i = 0; i < pinigai; i++){
            PiniguNuotraukos[i].GetComponent<Image>().color = Color.gray;
        }
        for(int i = 0; i < health; i++){
            healthNuotraukos[i].GetComponent<Image>().color = Color.gray;
        }
        for(int i = 0; i < movement; i++){
            movementNuotraukos[i].GetComponent<Image>().color = Color.gray;
        }
        for(int i = 0; i < damage; i++){
            damageNuotraukos[i].GetComponent<Image>().color = Color.gray;
        }
    }

    void Update()
    {
        Tekstas.text = "Points Available: " + playerPoints;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("PlayerPoints", playerPoints);
        PlayerPrefs.SetInt("PiniguUpgrade", pinigai);
        PlayerPrefs.SetInt("HealthUpgrade", health);
        PlayerPrefs.SetInt("MovementUpgrade", movement);
        PlayerPrefs.SetInt("DamageUpgrade", damage);
    }

   public void MoneyUpgrade()
   {
    if(playerPoints > 0 && pinigai < 4){
        playerPoints--;
        PiniguNuotraukos[pinigai].GetComponent<Image>().color = Color.gray;
        pinigai++;
    }
    else{
        return;
    }
   }
    public void HealthUpgrade()
   {
    if(playerPoints > 0 && health < 4){
        playerPoints--;
        healthNuotraukos[health].GetComponent<Image>().color = Color.gray;
        health++;
    }
    else{
        return;
    }
   }
   public void MovementUpgrade()
   {
    if(playerPoints > 0 && movement < 4){
        playerPoints--;
        movementNuotraukos[movement].GetComponent<Image>().color = Color.gray;
        movement++;
    }
    else{
        return;
    }
   }
   public void DamageUpgrade()
   {
    if(playerPoints > 0 && damage < 4){
        playerPoints--;
        damageNuotraukos[damage].GetComponent<Image>().color = Color.gray;
        damage++;
    }
    else{
        return;
    }
   }
}
