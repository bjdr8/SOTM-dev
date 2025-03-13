using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
//using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // making a static where other scripts can refer to
    public static GameManager Instance;

    // making lists for the player cards like all the cards the player has and the cards that are in the players deck. and wich one he has in his hand
    public List<PlayerCard> playerCards = new List<PlayerCard>();   // list for all the cards that are for the playera
    public List<PlayerCard> playerDeck = new List<PlayerCard>();    // list for all the cards that are in the players deck
    public List<PlayerCard> playerHand = new List<PlayerCard>();    // list for all the cards that are in the players hand
    public Transform playerHandParent;

    // making the lists to determend where cards are and where not.
    public Transform[] cardslots;       // list for the Transforms where the cards can be placed
    public bool[] availableCardSlots;   // list for the Transform slots that are available by using boolean

    public List<PlayerCard> discardPile = new List<PlayerCard>();   // list for a discard pile where cards come when they are used

    // making lists for the all the enemy cards and wich cards are on the bord.
    public List<EnemyCard> enemyCards = new List<EnemyCard>();  // list for all the enemy cards in the game
    public List<EnemyCard> enemyBord = new List<EnemyCard>();   // list for all the player cards that are in the game

    // making lists to determend where enemys are already and where not.
    public Transform[] bordslots;       // list for where the enemies can spawn
    public bool[] availableBordSlots;   // list for the availible places where enemies can spawn

    public List<Wave> waveOrder;
    public int currentWave = 0; 

    //public Text deckSizeTekst;

    private void Awake()
    {
        if (Instance == null) // If there is no instance already
        {
            Instance = this;
        }
        else if (Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        waveOrder = new List<Wave>(FindObjectsOfType<Wave>());
    }

    public void EndOfBattle()
    {
        for (int i = 0; i < waveOrder.Count; i++)
        {
            Wave wave = waveOrder[i];
            if (wave.waveIndex == currentWave)
            {
                foreach (EnemyCard card in wave.wave)
                {
                    Debug.Log("Enemy card: " + card.name);
                    PlaceEnemy(card);
                }
                currentWave++;
                waveOrder.RemoveAt(i);
                return;
            }
        }
    }

    public void DrawCard()
    {
        if (playerDeck.Count >= 1)
        {
            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if (availableCardSlots[i] == true)  // checking if there are available slots in the hand
                {
                    PlayerCard randCard = PlayerCard.Instantiate(playerDeck[0], playerHandParent);    // coppying the card that is on top of the deck
                    randCard.gameObject.SetActive(true);                            // setting the new card as active so it is visible
                    randCard.index = i;                                             // index in the hand
                    playerHand.Add(randCard);                                       // adding the card to the playerhand
                    //placeCard(randCard);                                            // setting the position of the new card to one of the cardslots
                    availableCardSlots[i] = false;                                  // saying to the slots that the slot is full
                    playerDeck.Remove(playerDeck[0]);                               // removing the card from the player deck
                    return;
                }
            }
        }
    }

    public void SortHand(PlayerCard playerCard1, PlayerCard playerCard2)
    {
        int index1 = playerHand.IndexOf(playerCard1);
        int index2 = playerHand.IndexOf(playerCard2);
        PlayerCard temp;
        PlayerCard temp2;

        if (index1 < index2)
        {
            for (int i = 0; i < index2 - index1; i++)
            {
                int change = i + 1;
                temp = playerHand[index1 + i];
                temp2 = playerHand[index1 + change];
                playerHand[index1 + i] = temp2;
                playerHand[index1 + change] = temp;
            }
        }

        else if (index1 > index2)
        {
            for (int i = 0; i < index2 - index1; i++)
            {
                int change = i + 1;
                temp = playerHand[index2 - i];
                temp2 = playerHand[index2 - change];
                playerHand[index2 - i] = temp2;
                playerHand[index2 - change] = temp;
            }
        }
    }

    public void PlaceEnemy(EnemyCard chosenEnemy)
    {
        for (int i = 0; i < availableBordSlots.Length; i++)
        {
            System.Random rndEnemyPos = new System.Random();
            int randBordPosition = 8;
            while (availableBordSlots[randBordPosition] == false)   // checking if the random position that has been givven is free otherwise try again
            {
                int intAvailableBordSlots = availableBordSlots.Count(t => t);
                if (intAvailableBordSlots <= 0)
                {
                    return;
                }
                randBordPosition = rndEnemyPos.Next(9);
                if (availableBordSlots[randBordPosition] == true)
                {
                    EnemyCard enemy = EnemyCard.Instantiate(chosenEnemy);             // making a copy of the chosen card
                    enemy.gameObject.SetActive(true);                                   // making the card visible
                    enemy.transform.position = bordslots[randBordPosition].position;    // setting the position of the enemy to the bord
                    enemy.BordPosition = randBordPosition + 1;
                    availableBordSlots[randBordPosition] = false;                       // saying the position is taken
                    enemyBord.Add(enemy);                                               // adding the enemy to the bord
                    //enemyCards.Remove(enemyCards[0]);                                   // removing the enemy from the card list
                    return;
                }
            }
        }
    }

    public void ReShuffleDiscardPileIntoDeck()  // adding the discar pile to the deck again
    {
        for (int i = 0; i < discardPile.Count; i++) 
        {
            playerDeck.Add(discardPile[i]);
        }
        ShufflePlayerDeck();
    }

    public void ShufflePlayerDeck() // shuffeling the cards in the deck of the player by calculations
    {
        System.Random rndDeckIndex = new System.Random();       // making random number var
        for (int i = playerDeck.Count - 1; i > 0; i--)
        {
            int newIndex = rndDeckIndex.Next(i+ 1);             // chosing number between the deck.Count and 0 and assigning it to an int
            PlayerCard oldValue = playerDeck[newIndex];         // assining the chosen card to a var called oldvalue
            playerDeck[newIndex] = playerDeck[i];               // assining the original card to the chosen card position in the list
            playerDeck[i] = oldValue;                           // assining the chosen card to the original card position in the list
        }
    }

    // Update is called once per frame
    private void Update()
    {

    }
}
