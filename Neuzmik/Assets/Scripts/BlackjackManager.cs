using UnityEngine;
using UnityEngine.UI;

public class BlackjackManager : MonoBehaviour
{
    public Button hitButton;
    public Button standButton;
    public Button dealButton;

    private void Start()
    {
        // Disable the Hit and Stand buttons initially
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);

        // Add click listeners to the buttons
        dealButton.onClick.AddListener(Deal);
        hitButton.onClick.AddListener(Hit);
        standButton.onClick.AddListener(Stand);
    }

    private void Deal()
    {
        // Logic for the "Deal" button
        Debug.Log("Player chose to Deal.");
        // Add your code here to start a new round or deal new cards

        // Enable the Hit and Stand buttons after pressing Deal
        hitButton.gameObject.SetActive(true);
        standButton.gameObject.SetActive(true);
        dealButton.gameObject.SetActive(false);
    }

    private void Hit()
    {
        // Logic for the "Hit" button
        Debug.Log("Player chose to Hit.");
        // Add your code here to handle the player's action
    }

    private void Stand()
    {
        // Logic for the "Stand" button
        Debug.Log("Player chose to Stand.");
        // Add your code here to handle the player's action
    }
}