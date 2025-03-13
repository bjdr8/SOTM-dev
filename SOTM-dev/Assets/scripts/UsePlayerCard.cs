using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePlayerCard : MonoBehaviour
{
    public Player player;
    public PlayerCard playerCard;       // to check what this playercard is
    public PlayerCard collidedCardObject; // if it collides with a player card then it is stored here
    public GameManager gameManager;     // so we can comunicate with the game manager
    public EnemyCard enemyCard;         // to check the enemy we are attacking
    private Vector3 oldPosition;        // to save the old position of the card.

    public int collidedCardIndex;
    private bool dragging = false;

    // Start is called before the first frame update
    void Awake()
    {
        playerCard = GetComponent<PlayerCard>();
        player = Player.Instance;
        gameManager = GameManager.Instance;
        DragAndDrop.OnDroppingCard += UseCard;
        DragAndDrop.OnDraggingCard += DragCard;
    }

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has an EnemyCard component
        EnemyCard collidedEnemyCard = collision.gameObject.GetComponent<EnemyCard>();

        if (dragging == true)
        {
            collidedCardObject = collision.gameObject.GetComponent<PlayerCard>();
            if (collidedCardObject != null)
            {
                gameManager.SortHand(playerCard, collidedCardObject);
                collidedCardObject = null;
            }
        }

        if (collidedEnemyCard  != null)
        {
            enemyCard = collidedEnemyCard;   
        }

        if (enemyCard != null) // Ensure the collided object is indeed an EnemyCard
        {
            Debug.Log("PlayerCard has collided with EnemyCard: " + enemyCard.name);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyCard>())
        {
            if (enemyCard != null)
            {
                enemyCard = null;
            }
        }

    }

    private void DragCard()
    {
        oldPosition = transform.position;
        dragging = true;
    }

    private void UseCard()
    {
        dragging = false;
        if (enemyCard != null) // Ensure the collided object is indeed an EnemyCard
        {
            enemyCard.HP -= playerCard.Attack;
            player.HP += playerCard.Heal;
            if (playerCard.Ability != null)
            {
                
            }
            gameManager.discardPile.Add(playerCard);
            gameManager.playerHand.Remove(playerCard);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
