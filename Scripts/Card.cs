using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using System;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public string suit;
    public int value;
    public GameManager Main;
    bool existance;
   // public Button btn;
    //public Image image;

    public string Suit { get => suit; set => suit = value; }
    public int Value { get => value; set => this.value = value; }

    public Card(string suit, int value)
    {
        this.Suit = suit;
        this.Value = value;
    }
    public Card() { }

    void Start()
    {
       // image = btn.GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CardCreation()
    {
        if (Main.isStart)
        {
            existance = Calculation.CheckCard(Main.deck, this);
            if (existance)
            {
                if (!Main.wait)
                {
                    Main.dragonCard.value = this.value;
                    Main.dragonCard.suit = this.suit;
                   // Main.dragonCard.image.sprite = this.image.sprite;

                    Main.TMd.text = $"{this.value} de {this.suit}"; 
                    Main.deck = Calculation.deleteCard(Main.deck, Main.dragonCard);
                    
                    if (Main.dragonCard.Value <= 4) { Main.low--; }
                    else if (Main.dragonCard.Value >= 10) { Main.high--; }

                    Main.wait = true;
                }
                else
                {
                    Main.tigerCard.value = this.value;
                    Main.tigerCard.suit = this.suit;
                   // Main.tigerCard.image.sprite = this.image.sprite;

                    Main.TMt.text = $"{this.value} de {this.suit}";
                    Main.deck = Calculation.deleteCard(Main.deck, Main.tigerCard);
                    
                    if (Main.tigerCard.Value <= 4) { Main.low--; }
                    else if (Main.tigerCard.Value >= 10) { Main.high--; }

                    Main.nextTurn = true;
                }
            }
        }       
                       
    }
}
