using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject laimejimas;
    private Nustatymai config;
    public TextMeshProUGUI priesuLiko;
    public int PlayerXPGain = 0;

    [SerializeField] ParticleSystem splash = null;

    private void Start()
    {
        GameObject configObject = GameObject.FindGameObjectWithTag("Nustatymai");
        config = configObject.GetComponent<Nustatymai>();
        currentHealth = config.enemyHealth;

        if (gameObject.CompareTag("Bosas"))
        {
            currentHealth = 350;
            maxHealth = 350;
        }

        if(ChooseMap.SelectedMap == 0){ // Dungeon
            if(ChooseMap.SelectedDifficulty == 0){ // Easy
                PlayerXPGain = 150;
            }
            else if(ChooseMap.SelectedDifficulty == 1){ // Medium
                PlayerXPGain = 300;
            }
            else if(ChooseMap.SelectedDifficulty == 2){ // Hard
                PlayerXPGain = 500;     
            }
        }
        else if(ChooseMap.SelectedMap == 1){ // City
            if(ChooseMap.SelectedDifficulty == 0){ // Easy
                PlayerXPGain = 850;
            }
            else if(ChooseMap.SelectedDifficulty == 1){ // Medium
                PlayerXPGain = 1000;
            }
            else if(ChooseMap.SelectedDifficulty == 2){ // Hard
                PlayerXPGain = 1200; 
            }
        }
        else if(ChooseMap.SelectedMap == 2){ // Park
            if(ChooseMap.SelectedDifficulty == 0){ // Easy
                PlayerXPGain = 1400;
            }
            else if(ChooseMap.SelectedDifficulty == 1){ // Medium
                PlayerXPGain = 1800;
            }
            else if(ChooseMap.SelectedDifficulty == 2){ // Hard
                PlayerXPGain = 2000;
            }
        }

        if(ChooseMap.HardcoreRezimas){
            PlayerXPGain *= 2;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        splash.Play();
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        XP.DabartinisZaidejoXP += PlayerXPGain;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemies.Length);
        if(enemies.Length <= 11){
        priesuLiko.text = "Liko priešų: " + (enemies.Length-1);
        }
        if (enemies.Length == 1)
        {
            Boss.Bosas = true;
        }
        
        Destroy(gameObject);
    }

}
