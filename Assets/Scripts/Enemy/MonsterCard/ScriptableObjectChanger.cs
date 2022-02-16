using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectChanger : MonoBehaviour
{
    [SerializeField] private ScriptableObject scriptableObject;
    [SerializeField] private MonsterDisplay monsterDisplay;



    private void Awake()
    {
        monsterDisplay.DisplayMonster((MonsterCard)scriptableObject);
    }
    
}
