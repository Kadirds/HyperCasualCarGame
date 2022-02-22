using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject coinText;
    public static int score;
    public static int coin;


    void Update() 
    {
        scoreText.GetComponent<Text>().text = "" + score;
        coinText.GetComponent<Text>().text = "" + coin;
        
    }
}
