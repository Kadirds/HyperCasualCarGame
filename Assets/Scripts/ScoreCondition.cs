using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCondition : MonoBehaviour
{
    [HideInInspector]public static bool ScorePassed;

    [SerializeField] private int LevelPassScore;

    private void Start()
    {
        ScorePassed = false;
    }
    private void Update()
    {
        LevelPassed();
    }

    void LevelPassed()
    {
        if (ScoringSystem.score >= LevelPassScore)
        {
            ScorePassed = true;
        }
    }
     


}
