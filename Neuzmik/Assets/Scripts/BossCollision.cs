using UnityEngine;

public class BossCollision : MonoBehaviour
{
    public GameObject BossHPBAR;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Change "Player" to the tag of the collider's target object
        {
            BossHPBAR.SetActive(true);
        }
    }
}
