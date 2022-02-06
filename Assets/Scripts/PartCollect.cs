using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollect : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        ScoringSystem.score += 20;
        Destroy(gameObject);
    }
}
