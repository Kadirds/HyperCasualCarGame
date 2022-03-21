using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollect : MonoBehaviour
{
    public DenemeCarController CarController;
    [HideInInspector] public bool isScore60 = false;


    private void OnTriggerEnter(Collider collision)
    {
        this.gameObject.SetActive(false);
        CarController.carSpeed += 100;
        CarController.maxSpeed += 100;
        ScoringSystem.score += 20;

    }
}
