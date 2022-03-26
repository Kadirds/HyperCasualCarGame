using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class DenemeCarController : MonoBehaviour
{
    public float carSpeed;
    public float maxSpeed;
    [HideInInspector]public float dragAmount = 0.3f;

    public float steerAngle;

    Vector3 _rotVec;
    [HideInInspector] public Vector3 _moveVec;
    public Transform LeftWheel, RightWheel;

    public AudioManager AudioManager;

    void FixedUpdate()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.Ingame)
        {
            _moveVec += transform.forward * carSpeed * Time.deltaTime;
            transform.position += _moveVec * Time.deltaTime;

            //transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * steerAngle * Time.deltaTime * _moveVec.magnitude);

            _moveVec *= dragAmount;
            _moveVec = Vector3.ClampMagnitude(_moveVec, maxSpeed);


            _rotVec += new Vector3(0, Input.GetAxis("Horizontal"), 0);
            _rotVec = Vector3.ClampMagnitude(_rotVec, steerAngle);

            LeftWheel.localRotation = Quaternion.Euler(_rotVec);
            RightWheel.localRotation = Quaternion.Euler(_rotVec);
        }
        
        
    }
    void Finish()
    {

        GameManager.Instance.gameState = GameManager.GameState.Next;

    }

    void Death()
    {

        GameManager.Instance.gameState = GameManager.GameState.Gameover;

        if (carSpeed==0)

        {
            FindObjectOfType<AudioManager>().Play("fail");

            FindObjectOfType<AudioManager>().Stop("acc");
        }
              
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Finish();
            carSpeed = 0;
            steerAngle = 0;

        }

        if (other.CompareTag("Obstacle"))
        {
            steerAngle = 0;
            carSpeed = 0;
            Death();
        }
    }

       
}
