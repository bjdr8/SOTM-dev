using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private List<Card> PlayerDeck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShuffleCards()
    {
        System.Random randIndexGenerator = new System.Random();
        for (int i = PlayerDeck.Count; i > 0; i--)
        {
            int randIndex = randIndexGenerator.Next(i + 1);
            Card tempCard = PlayerDeck[randIndex];
            PlayerDeck[randIndex] = PlayerDeck[i];
            PlayerDeck[i] = tempCard;
        }
    }


}
