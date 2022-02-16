using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parchment : MonoBehaviour
{
    public static Parchment instance;
    public Text parchments;
    private int currentParchment;
    public GameObject MonsterBestiary;
    public GameObject Portal;
    public GameObject transition;


    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeParchment(int parchment)
    {
        currentParchment += parchment;
        parchments.text = "X" + currentParchment.ToString();

        if(currentParchment == 1)
        {
            MonsterBestiary.SetActive(true);
        }
        if(currentParchment == 5)
        {
            Portal.SetActive(true);
            transition.SetActive(true);
        }               
    }
}
