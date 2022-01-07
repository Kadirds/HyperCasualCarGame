using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tire : MonoBehaviour
{
    public float speed = 120.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * speed);
    }
}
