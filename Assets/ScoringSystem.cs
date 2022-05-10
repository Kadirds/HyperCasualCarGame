using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject coinText;
    public static float score;
    private static float currentScore;
    public static int coin;

    void Update() 
    {
        scoreText.GetComponent<TextMesh>().text = "" + score;
        coinText.GetComponent<TextMesh>().text = "" + coin;
        
    }
}
