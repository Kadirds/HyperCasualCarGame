using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{        
    public float speed;
    private float horizontalMove;
    [SerializeField] float horizontalSpeed;
    private Rigidbody car;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //horizontalMove = Input.GetAxis("Horizontal");
        car.velocity = new Vector3 (horizontalSpeed * horizontalMove,0,speed); 
    }

    public void Left()
    {
        horizontalMove = - 1;
    }
    public void Right()
    {
        horizontalMove = 1;
    }
    public void Stop()
    {
        horizontalMove = 0;
    }
}
