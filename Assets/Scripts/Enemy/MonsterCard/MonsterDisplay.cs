using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDisplay : MonoBehaviour
{    

    public Text monsterName;
    public Text descriptionText;
    public Text weaknessText;
    public Text damageText;
    public Text healthText;
    public Image monsterImage;
    public Image monsterAttack;
    public Image monsterDead;


    // void Start()
    // {
    //     // monsterName.text = monsterCard.name;
    //     // descriptionText.text = monsterCard.description;
    //     // weaknessText.text = monsterCard.weakness;
    //     // damageText.text = monsterCard.attack.ToString();
    //     // healthText.text = monsterCard.health.ToString();
    //     // monsterImage.sprite = monsterCard.monsterImage;
    //     // monsterAttack.sprite = monsterCard.monsterAttack;
    //     // monsterDead.sprite = monsterCard.monsterDead;

    // }

    public void DisplayMonster(MonsterCard monsterCard)
    {
        monsterName.text = monsterCard.name;
        descriptionText.text = monsterCard.description;
        weaknessText.text = monsterCard.weakness;
        damageText.text = monsterCard.attack.ToString();
        healthText.text = monsterCard.health.ToString();
        monsterImage.sprite = monsterCard.monsterImage;
        monsterAttack.sprite = monsterCard.monsterAttack;
        monsterDead.sprite = monsterCard.monsterDead;
    }



    
}
