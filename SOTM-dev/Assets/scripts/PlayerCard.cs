using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    public int Cost;
    public int range;
    [SerializeField] private bool isAttack;
    public int Attack;
    public int Heal;
    public int Shield;
    public int BonusDamage;
    public int Coins;
    public string Ability;
    public bool Expire;
    public int index;

    //public bool 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message

        //Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        //Debug.Log("Mouse is no longer on GameObject.");
    }
}
