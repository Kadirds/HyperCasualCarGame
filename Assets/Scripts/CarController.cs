using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarController : MonoBehaviour
{
    bool fail;
    public float speed;
    private float horizontalMove;
    [SerializeField]private float accelSpeed;
    [SerializeField] float horizontalSpeed;
    AudioSource arabasesi;
 


    private Rigidbody car;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Rigidbody>();
        arabasesi = gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        if (fail == true)
        {

            speed = 0;
            horizontalSpeed = 0;
        }

        //horizontalMove = Input.GetAxis("Horizontal");
        car.velocity = new Vector3 (horizontalSpeed * horizontalMove,0,speed);
        //arabasesi.Play();
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
