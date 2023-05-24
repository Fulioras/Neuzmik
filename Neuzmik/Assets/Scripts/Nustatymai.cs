using UnityEngine;

public class Nustatymai : MonoBehaviour
{
    public float attackRange = 1.5f; // ENEMY ATTACK RANGE
    public float BossAttackRange = 15f; // PLAYER HEALTH
    public float attackSpeed = 1.5f; // ENEMY ATTACK SPEED
    public float speed = 5f; // ENEMY WALKING SPEED
    public float detectionRange = 3f; // ENEMY DETECTION RANGE
    public int enemyDamage = 10; // ENEMY DAMAGE
    public int bulletDamage = 10; // PLAYER BULLET DAMAGE
    public int firingMode = 1; // PLAYER FIRE MODE
    public int rpm = 180; // PLAYER ROUNDS PER MINUTE
    public float accuracy = 0.1f; // PLAYER SHOOTING ACCURACY
    public float ballSpeed = 10f; // PLAYER BULLET SPEED
    public float dashSpeed = 10f; // PLAYER DASH SPEED
    public float dashTime = 0.5f; // PLAYER DASH TIME
    public float dashCooldown = 1f; // DASH COOLDOWN
    public int enemyHealth = 100; // ENEMY HEALTH
    public float greitis; // PLAYER MOVEMENT SPEED
    public int playerHealth = 100; // PLAYER HEALTH
    public int bossHealth = 200; // PLAYER HEALTH
    public static int Ginklas;


    void Start()
    {
        Ginklas = PlayerPrefs.GetInt("Equipped", 0);
        if(Ginklas == 0){
            rpm = 50;
            firingMode = 1;
            ballSpeed = 100;
            bulletDamage = 20;
            accuracy = 0.5f;
            greitis = 50;

        }
        else if(Ginklas == 1){
            rpm = 600;
            firingMode = 2;
            ballSpeed = 80;
            bulletDamage = 5;
            accuracy = 0.5f;
            greitis = 50;
        }
        else if(Ginklas == 2){
            rpm = 200;
            firingMode = 1;
            ballSpeed = 150;
            bulletDamage = 40;
            accuracy = 0.2f;
            greitis = 50;
        }
            else if(Ginklas == 3){
            rpm = 500;
            firingMode = 2;
            ballSpeed = 120;
            bulletDamage = 40;
            accuracy = 0.3f;
            greitis = 40;
        }
        else if(Ginklas == 4){
            rpm = 60;
            firingMode = 2;
            ballSpeed = 200;
            bulletDamage = 600;
            accuracy = 0f; 
            greitis = 40;
        }
        else if(Ginklas == 5){
            rpm = 600;
            firingMode = 2;
            ballSpeed = 150;
            bulletDamage = 600;
            accuracy = 0f;
            greitis = 40;
        }
    }
}