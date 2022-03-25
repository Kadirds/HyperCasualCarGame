using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextDestroy : MonoBehaviour
{
    [SerializeField] private float DestroyTime = 0.30f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

}
