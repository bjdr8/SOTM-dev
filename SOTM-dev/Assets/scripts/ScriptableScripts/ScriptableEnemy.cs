using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "EnemyCard")]
public class ScriptableEnemy : ScriptableObject
{
    public string enemyName;
    public Sprite cardArt;

    public string Ability;

    public int maxHp;
    public int hp;
    public int attack;
    public int defense;
    public int shield;

}
