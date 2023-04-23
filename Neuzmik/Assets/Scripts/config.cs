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
    public float dashSpeed = 10f; // the speed at which the object will dash
    public float dashTime = 0.5f; // the duration of the dash
    public float dashCooldown = 1f; // the cooldown time before the object can dash again
    public int enemyHealth = 100;
    public float greitis;
    public int playerHealth = 100;
}
