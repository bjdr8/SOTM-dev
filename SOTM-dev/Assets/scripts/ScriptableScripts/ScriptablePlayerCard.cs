using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Card", menuName = "PlayerCard")]
public class ScriptablePlayerCard : ScriptableObject
{
    public string cardName;
    public Sprite cardArt;

    public string ability;

    public bool ranged;
    public int damage;
    public int bonusDamage;

    public bool needTarget;
    public int healing;
    public int shielding;

    public bool expire;

    public int cost;
}
