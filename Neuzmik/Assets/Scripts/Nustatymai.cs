using UnityEngine;

public class Nustatymai : MonoBehaviour
{
    public float attackRange = 1.5f; // ENEMY ATTACK RANGE
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
}