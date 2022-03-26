using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
	public GameObject FloatingTextPrefab;

        
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.gameState == GameManager.GameState.Ingame)
        {
            ScoringSystem.score += 50;
            ShowFloatingText();
        }
       
    }

    void ShowFloatingText()
    {
        Instantiate(FloatingTextPrefab, transform.position,Quaternion.identity);
    }
}
