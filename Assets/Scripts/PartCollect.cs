using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollect : MonoBehaviour
{
    public CarController carSpeed;

    private void OnTriggerEnter(Collider collision)
    {
        this.gameObject.SetActive(false);
        carSpeed.speed += 5; 
        ScoringSystem.score += 20;
        
    }

    
        
}
