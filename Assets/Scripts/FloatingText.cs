using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
	public GameObject FloatingTextPrefab;

    private void OnTriggerEnter(Collider other)
    {
        ShowFloatingText();
    }

    void ShowFloatingText()
    {
        if (CompareTag("LeftCollider"))
        {

        }


        Instantiate(FloatingTextPrefab, transform.position,Quaternion.identity);
    }
}
