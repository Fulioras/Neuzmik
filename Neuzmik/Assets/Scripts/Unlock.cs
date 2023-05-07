using UnityEngine;
using System.Collections;

public class Unlock : MonoBehaviour
{
    // The amount of transparency to decrease per second
    public float fadeSpeed = 0.5f;

    // The minimum transparency that the sprite can have
    public float minAlpha = 0.0f;

    // The current transparency of the sprite
    private float currentAlpha = 1.0f;

    // A reference to the sprite renderer component
    private SpriteRenderer spriteRenderer;

    // Set up the sprite renderer component and initial transparency
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Decrease the transparency of the sprite when the player touches it
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(FadeOut());
        }
    }

    // Coroutine that gradually decreases the transparency of the sprite
    private IEnumerator FadeOut()
    {
        while (currentAlpha > minAlpha)
        {
            currentAlpha -= fadeSpeed * Time.deltaTime;
            spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, currentAlpha);
            yield return null;
        }
    }
}
