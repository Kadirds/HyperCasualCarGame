using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject coinText;
    public static float score;
    public static int coin;

    public bool isScore60 = false;


    void Update() 
    {
        scoreText.GetComponent<Text>().text = "" + score;
        coinText.GetComponent<Text>().text = "" + coin;
        
    }
}
