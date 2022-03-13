using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenemeCarController : MonoBehaviour
{

    bool fail;
    private float horizontalMove;
    [SerializeField] float carSpeed;
    [SerializeField] float maxSpeed;
    float dragAmount = 0.3f;

    [SerializeField] float steerAngle;

    Vector3 _rotVec;
    Vector3 _moveVec;

    public Transform LeftWheel, RightWheel;

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        _moveVec += transform.forward * carSpeed * Time.deltaTime;
        transform.position += _moveVec * Time.deltaTime;
        
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * steerAngle * Time.deltaTime * _moveVec.magnitude);

        _moveVec *= dragAmount;
        _moveVec = Vector3.ClampMagnitude(_moveVec, maxSpeed);


        _rotVec += new Vector3(0, Input.GetAxis("Horizontal"), 0);
        _rotVec = Vector3.ClampMagnitude(_rotVec, steerAngle);

        LeftWheel.localRotation = Quaternion.Euler(_rotVec);
        RightWheel.localRotation = Quaternion.Euler(_rotVec);
    }
    public void Left()
    {
        horizontalMove = -1;

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
            carSpeed = 0;

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
