using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculation : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public static List<Card> deleteCard(List<Card> deck, Card cardToEliminate)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            if (cardToEliminate.Value == deck[i].Value && cardToEliminate.Suit == deck[i].Suit)
            {
                deck.RemoveAt(i);
                return deck;
            }
        }
        return deck;
    }
    public static bool CheckCard(List<Card> deck, Card cardToCheck)
    {
        for(int i =0; i< deck.Count; i++)
        {
            if (cardToCheck.value == deck[i].value && cardToCheck.suit == deck[i].suit) { return true; }
        }
        return false;
    }

}
