using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarController : MonoBehaviour
{
    bool fail;
    public float speed;
    private float horizontalMove;
    [SerializeField] private float accelSpeed;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float turningStrength;
    private bool isPressing;



    public Rigidbody car;

    void Start()
    {
        car.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = car.transform.position;


        car.AddForce(transform.forward * speed * 400);
        //new Vector3 (horizontalSpeed * horizontalMove,0,speed);
        if (fail == true)
        {
            speed = 0;
            horizontalSpeed = 0;

        }
    }

    public void Left()
    {

        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, turningStrength * Time.deltaTime,0f));
    }
    public void Right()
    {
        horizontalMove = 1;
    }
    public void Stop()
    {

        horizontalMove = 0;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Finish();
            speed = 0;

        }

        if (other.CompareTag("Obstacle"))
        {
            fail = true;
            Death();
        }


    }

    void Finish()
    {

        GameManager.Instance.gameState = GameManager.GameState.Next;

    }

    void Death()
    {

        GameManager.Instance.gameState = GameManager.GameState.Gameover;

    }
}
