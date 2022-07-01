using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region vars
    public Card dragonCard;
    public Card tigerCard;
    public bool isStart = false;
    double cartasRest;
    internal double high = 128; //10 J Q K
    internal double low = 128; //A 2 3 4 

    internal List<string> wins; //new(208);
    internal List<Card> deck = new(416);
    int turn;
    public TextMeshProUGUI dragontProb;
    public TextMeshProUGUI tigerProb;
    public TextMeshProUGUI tieProb;
    public TextMeshProUGUI TMturno;
    public TextMeshProUGUI TMwins;
    public TextMeshProUGUI TMd;
    public TextMeshProUGUI TMt;
    public GameObject panelProb;
    public GameObject panelTie;
    public Image[] panelImage;
   // public Image[] panelTieImage;
    public TextMeshProUGUI txtbtn;
    int c = 0;
    internal bool wait;
    internal bool nextTurn;
    #endregion
    
    void Start()
    {
      //  dragonCard.image = null;
        //tigerCard.image = null;
        DeckGen.fillDeck(deck);
        dragonCard.suit = "joker";
        dragonCard.value = 0;
        tigerCard.suit = "joker";
        tigerCard.value = 0;
        wait = false;
        nextTurn = false;
        turn = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            txtbtn.text = "Finalizar";
            panelImage = panelProb.GetComponents<Image>();
            //panelTieImage = panelTie.GetComponents<Image>();
            cartasRest = deck.Count;
            double pAlta = Math.Round((high / cartasRest) * 100, 2);
            double pBaja = Math.Round((low / cartasRest) * 100, 2);
            double gap = pAlta - pBaja;
            if (gap > 0) { panelImage[0].color = Color.red; } else { panelImage[0].color = Color.yellow; }
            string probAlta = Convert.ToString(pAlta) + "%";
            string probBaja = Convert.ToString(pBaja) + "%";
            dragontProb.text = probAlta;
            tigerProb.text = probBaja;
            TMturno.text = "Turno: " + turn;
         
            if (nextTurn) 
            {
                winRate(); 
                turn++; 
                dragonCard.suit = "joker";
                dragonCard.value = 0;
                tigerCard.suit = "joker";
                tigerCard.value = 0;
              //  dragonCard.image = null;
                //tigerCard.image = null;
                wait = false;
                nextTurn = false;
            }
            if (turn >= 125) { activeTies(); panelTie.SetActive(true); }
        }
    }
    public void btnStart()
    {
        if (!isStart) isStart = true;
        else { SceneManager.LoadScene("DTA"); }
    }
    
    internal void winRate()
    {
        wins = new(turn);
        
        if (dragonCard.Value > tigerCard.Value)
        {
            wins.Add("D");
            Debug.Log("D");
            Debug.Log(wins.Count);
        }
        else
        {
            if (dragonCard.Value < tigerCard.Value)
            {
                wins.Add("T");
                Debug.Log("t");
                Debug.Log(wins.Count);
            }
            else
            {
                if (dragonCard.Value == tigerCard.Value)
                {
                    wins.Add("E");
                    Debug.Log("e");
                    Debug.Log(wins.Count);
                }
            }
        }
        foreach (var x in wins)
        {
            TMwins.text += x + ", ";
        }

    }
    private void activeTies()
    {
        List<int> ties = DeckDivider.Ties(deck); //Esta función se llama y devuelve una lista de las veces que se repite una carta
                                                 //estan ordenadas del 1 al 13 con sus respectivos valores
        int higher = 0;
        int indexCard = 0;
        double probFirstCard;
        double probSecondCard; ;
        double final;
        for (int i = 0; i < ties.Count; i++)  //Este es una simple ciclo for para calcular el mayor y su indice en la lista de cartas
        {
            if (higher <= ties[i])
            {
                higher = ties[i];
                indexCard = i;
            }
        }
        probFirstCard = Math.Round(Convert.ToDouble(higher) / Convert.ToDouble(deck.Count),2); //Formulas de probabilidad y estatistica 
        probSecondCard = Math.Round(Convert.ToDouble(((higher - 1)) / Convert.ToDouble((deck.Count - 1))),2); //La probabilidad de que la segunda carta que salga sea igual
        final = Math.Round((probFirstCard * probSecondCard) * 100,2); //La probabilidad de que las 2 cartas que salgan seguidas sean iguales (empate)
        string indexCardstring ="";
        switch (indexCard)
        {           
            case 10:                
                indexCardstring = "J";
                break;
            case 11:
                indexCardstring = "Q";
                break;
            case 12:
                indexCardstring = "K";
                break;
        }
        
        

        tieProb.text = $"Quedan {higher} de "+ indexCardstring+ $" la probabilidad de que salga el empate es: {final} %";

    }
}
