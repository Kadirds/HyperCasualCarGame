using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ScoringSystem.coin += 1;
        Destroy(gameObject);
    }
}
