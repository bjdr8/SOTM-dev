using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCard : MonoBehaviour
{
    public int HP;
    public int Attack;
    public int range;
    public int Xp;
    public string Ability;
    public int BordPosition;

    public TMP_Text HPNumber;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private bool selected;

    // Start is called before the first frame update

    void Awake()
    {
        gameManager = GameManager.Instance;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            gameManager.availableBordSlots[BordPosition - 1] = true;
            gameManager.enemyBord.Remove(this);
            Destroy(gameObject);
        }

        if (selected) 
        {

        }
    }
}
