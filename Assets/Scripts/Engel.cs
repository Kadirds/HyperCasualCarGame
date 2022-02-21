using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engel : MonoBehaviour
{
    bool fail;
    public CarController Carspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fail == true)
        {
            Carspeed.speed = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            fail = true;
        }
    }
}
