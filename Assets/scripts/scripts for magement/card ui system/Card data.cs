using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public string cardName;
    public string description;
    public Sprite artwork; // For card image
    public System.Action onSelect; // Action to perform when this card is selected
}
