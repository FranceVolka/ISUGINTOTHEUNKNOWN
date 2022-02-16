using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MonsterCard", menuName = "MonsterCard")]
public class MonsterCard : ScriptableObject
{
    public new string name;
    public string description;
    public string weakness;
    public int attack;
    public int health;
    public Sprite monsterImage;
    public Sprite monsterAttack;
    public Sprite monsterDead;


}
