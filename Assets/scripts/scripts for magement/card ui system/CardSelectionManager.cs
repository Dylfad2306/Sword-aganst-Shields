using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardSelectionManager : MonoBehaviour
{
    public GameObject cardUIPrefab; // Assign your card prefab here
    public Transform cardParent; // The parent object where the cards will be instantiated
    public List<Card> availableCards; // List of all available cards
    public Canvas cardCanvas; // Canvas to show/hide the card selection

    private System.Action onComplete;

    void Start()
    {
        cardCanvas.enabled = false; // Hide the canvas by default
    }

    public void StartCardSelection(System.Action callback)
    {
        Time.timeScale = 0; // Pause the game
        cardCanvas.enabled = true; // Show the card selection UI
        onComplete = callback; // Store the callback to be called later

        GenerateRandomCards();
    }

    void GenerateRandomCards()
    {
        // Clear previous cards
        foreach (Transform child in cardParent)
        {
            Destroy(child.gameObject);
        }

        // Select 3 random cards from availableCards
        List<Card> selectedCards = new List<Card>();
        while (selectedCards.Count < 3)
        {
            Card randomCard = availableCards[Random.Range(0, availableCards.Count)];
            if (!selectedCards.Contains(randomCard))
            {
                selectedCards.Add(randomCard);
            }
        }

        // Instantiate the card UI prefabs
        foreach (Card card in selectedCards)
        {
            GameObject cardUI = Instantiate(cardUIPrefab, cardParent);
            cardUI.transform.Find("CardName").GetComponent<Text>().text = card.cardName;
            cardUI.transform.Find("Description").GetComponent<Text>().text = card.description;
            cardUI.transform.Find("Artwork").GetComponent<Image>().sprite = card.artwork;

            Button button = cardUI.GetComponent<Button>();
            button.onClick.AddListener(() => OnCardSelected(card));
        }
    }

    void OnCardSelected(Card selectedCard)
    {
        selectedCard.onSelect?.Invoke(); // Perform the card's action
        Time.timeScale = 1; // Resume the game
        cardCanvas.enabled = false; // Hide the card selection UI

        onComplete?.Invoke(); // Call the callback to notify that selection is complete
    }
}
