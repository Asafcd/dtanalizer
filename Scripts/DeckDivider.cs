using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckDivider : MonoBehaviour
{
    public static List<int> Ties(List<Card> deck)
    {
        List<int> tie = new(13);
        for (int i = 0; i < 13; i++)
        {
            tie.Add(0);
        }

        for (int i = 0; i < deck.Count; i++)
        {
            switch (deck[i].Value)
            {
                case 1:
                    tie[0]++;
                    break;
                case 2:
                    tie[1]++;
                    break;
                case 3:
                    tie[2]++;
                    break;
                case 4:
                    tie[3]++;
                    break;
                case 5:
                    tie[4]++;
                    break;
                case 6:
                    tie[5]++;
                    break;
                case 7:
                    tie[6]++;
                    break;
                case 8:
                    tie[7]++;
                    break;
                case 9:
                    tie[8]++;
                    break;
                case 10:
                    tie[9]++;
                    break;
                case 11:
                    tie[10]++;
                    break;
                case 12:
                    tie[11]++;
                    break;
                case 13:
                    tie[12]++;
                    break;
            }
        }

        return tie;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
