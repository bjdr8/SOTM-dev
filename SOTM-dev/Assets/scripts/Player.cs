using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public int HP;
    public int Shield;
    public int BonusAttack;
    public int Mana;
    public int XP;
    public string CharacterAbility;
    // Start is called before the first frame update

    void Awake()
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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
