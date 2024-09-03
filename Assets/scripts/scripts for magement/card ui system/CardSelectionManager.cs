using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// Define the Card class
[System.Serializable]
public class Card
{
    public string cardName;         // The name of the card
    public string description;      // The description of the card's effect
    public Sprite artwork;          // The artwork that will be displayed on the card
    [System.NonSerialized]
    public System.Action onSelect;  // The action that occurs when the card is selected

    // Optional constructor for programmatic creation
    public Card(string name, string desc, Sprite art, System.Action action)
    {
        cardName = name;
        description = desc;
        artwork = art;
        onSelect = action;
    }
}

public class CardSelectionManager : MonoBehaviour
{
    public playerstatsscipt playerstatsscipt;
    public bool dubleBulletsActive = false;
    public bool isCardsDun = true;
    public float healthMultiplyer = 1;

    private float multiplayerHealth;
    [Header("UI Components")]
    public GameObject cardUIPrefab; // Prefab used to display a card in the UI
    public Transform cardParent;     // The parent object in which card UI elements will be instantiated
    public Canvas cardCanvas;        // The canvas that contains the card selection UI

    [Header("Card Data")]
    public List<Card> availableCards = new List<Card>(); // The list of cards the player can select from

    private System.Action onComplete; // Callback for when the player has selected a card

    void Start()
    {
        // Ensure required references are assigned
        if (cardCanvas != null)
            cardCanvas.enabled = false; // Initially hide the card selection UI
        else
            Debug.LogError("CardCanvas is not assigned in the inspector!");

        if (cardParent == null)
            Debug.LogError("cardParent is not assigned in the inspector!");

        if (cardUIPrefab == null)
            Debug.LogError("cardUIPrefab is not assigned in the inspector!");

        // Programmatically add cards to availableCards
        // Replace these with your actual sprites and desired actions
          Sprite XBullets = Resources.Load<Sprite>("sprites/Cards/card more bullets");
          Sprite moreHealth = Resources.Load<Sprite>("sprites/Cards/card more health");


        availableCards.Add(new Card("2xBullets", "2xBullets", XBullets, dubleBullets));
        availableCards.Add(new Card("More health", "Gives more health", moreHealth, twoxHealth));
    }

    // Example card effects
    void dubleBullets()
    {
        dubleBulletsActive = true;
    }
    void twoxHealth()
    {
        healthMultiplyer += 0;
        multiplayerHealth = 1 + healthMultiplyer;
        playerstatsscipt.PlayerHP = playerstatsscipt.PlayerHP * multiplayerHealth;
    }

    // This method starts the card selection process
    public void StartCardSelection(System.Action callback)
    {
        if (cardCanvas == null || cardUIPrefab == null || cardParent == null)
        {
            Debug.LogError("CardSelectionManager is missing required references.");
            return;
        }

        Debug.Log("Card selection started");
        Time.timeScale = 0; // Pause the game
        cardCanvas.enabled = true; // Show the card selection UI
        onComplete = callback;

        // Call the method to generate and display cards
        GenerateRandomCards();
    }

    // This method generates random cards and displays them in the UI
    void GenerateRandomCards()
    {
        // Clear any previously displayed cards
        foreach (Transform child in cardParent)
        {
            Destroy(child.gameObject);
        }

        if (availableCards.Count == 0)
        {
            Debug.LogWarning("No available cards to display.");
            return;
        }

        // Select 3 random unique cards from availableCards
        List<Card> selectedCards = new List<Card>();
        int cardsToSelect = Mathf.Min(3, availableCards.Count);

        while (selectedCards.Count < cardsToSelect)
        {
            Card randomCard = availableCards[Random.Range(0, availableCards.Count)];
            if (!selectedCards.Contains(randomCard))
            {
                selectedCards.Add(randomCard);
            }
        }

        // Instantiate the card UI prefabs for each selected card
        foreach (Card card in selectedCards)
        {
            GameObject cardUI = Instantiate(cardUIPrefab, cardParent);
            if (cardUI == null)
            {
                Debug.LogError("Failed to instantiate cardUIPrefab.");
                continue;
            }

            // Assign card details to UI elements
            Text cardNameText = cardUI.transform.Find("CardName")?.GetComponent<Text>();
            Text cardDescriptionText = cardUI.transform.Find("Description")?.GetComponent<Text>();
            Image cardArtworkImage = cardUI.transform.Find("Artwork")?.GetComponent<Image>();
            Button cardButton = cardUI.GetComponent<Button>();
            isCardsDun = false;

            if (cardNameText != null)
                cardNameText.text = card.cardName;
            else
                Debug.LogError("CardName Text component not found in CardUIPrefab.");

            if (cardDescriptionText != null)
                cardDescriptionText.text = card.description;
            else
                Debug.LogError("Description Text component not found in CardUIPrefab.");

            if (cardArtworkImage != null)
                cardArtworkImage.sprite = card.artwork;
            else
                Debug.LogError("Artwork Image component not found in CardUIPrefab.");

            if (cardButton != null)
                cardButton.onClick.AddListener(() => OnCardSelected(card));
            else
                Debug.LogError("Button component not found in CardUIPrefab.");
        }
    }

    // This method is called when a card is selected
    void OnCardSelected(Card selectedCard)
    {
        Debug.Log($"{selectedCard.cardName} selected!");
        selectedCard.onSelect?.Invoke(); // Apply the selected card's effect
        Time.timeScale = 1; // Resume the game
        cardCanvas.enabled = false; // Hide the card selection UI
        isCardsDun = true;
        onComplete?.Invoke(); // Trigger the callback to signal that the selection is complete
    }
}
