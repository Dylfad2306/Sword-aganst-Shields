using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    public CardSelectionManager cardSelectionManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cardSelectionManager.StartCardSelection(OnCardSelectionComplete);
        }
    }

    void OnCardSelectionComplete()
    {
        Debug.Log("Card selection is complete!");
    }
}
