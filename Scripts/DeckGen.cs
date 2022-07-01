using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckGen : MonoBehaviour
{
    internal Card tCard;
    List<Card> deck;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public static void fillDeck(List<Card> deck) //Esta función llena la lista principal de las cartas necesarias para los calculos
    {
        for (int i = 0; i < 8; i++) //Hearts
        {
            for(int j = 1; j < 14; j++)
            {
                Card tcard = new("Hearts", j);
                deck.Add(tcard);
            }
        }

        for (int i = 0; i < 8; i++) //Diamonds
        {
            for (int j = 1; j < 14; j++)
            {
                Card tcard = new("Diamonds", j);
                deck.Add(tcard);
            }
        }

        for (int i = 0; i < 8; i++) //Clovers
        {
            for (int j = 1; j < 14; j++)
            {
                Card tcard = new("Clovers", j);
                deck.Add(tcard);
            }
        }

        for (int i = 0; i < 8; i++) //Spades
        {
            for (int j = 1; j < 14; j++)
            {
                Card tcard = new("Spades", j);
                deck.Add(tcard);
            }
        }
    }
}
