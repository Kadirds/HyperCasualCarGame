using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DenemeCarController : MonoBehaviour
{
    bool ToggleChange;
    bool fail;
    private float horizontalMove;
    [SerializeField] float carSpeed;
    [SerializeField] float maxSpeed;
    float dragAmount = 0.3f;

    [SerializeField] float steerAngle;

    Vector3 _rotVec;
    Vector3 _moveVec;

    public Transform LeftWheel, RightWheel;

    public AudioManager AudioManager;

<<<<<<< HEAD

=======
>>>>>>> parent of 8e88e40 (Emulator eklendi ve kontroller düzenlendi.)
    
    void FixedUpdate()
    {
        _moveVec += transform.forward * carSpeed * Time.deltaTime;
        transform.position += _moveVec * Time.deltaTime;
        
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * steerAngle * Time.deltaTime * _moveVec.magnitude);

        _moveVec *= dragAmount;
        _moveVec = Vector3.ClampMagnitude(_moveVec, maxSpeed);


        _rotVec += new Vector3(0, Input.GetAxis("Horizontal"), 0);
        _rotVec = Vector3.ClampMagnitude(_rotVec, steerAngle);

<<<<<<< HEAD
<<<<<<< HEAD
            LeftWheel.localRotation = Quaternion.Euler(_rotVec);
            RightWheel.localRotation = Quaternion.Euler(_rotVec);
        }
        
        
=======
        LeftWheel.localRotation = Quaternion.Euler(_rotVec);
        RightWheel.localRotation = Quaternion.Euler(_rotVec);
>>>>>>> parent of 8e88e40 (Emulator eklendi ve kontroller düzenlendi.)
=======
        LeftWheel.localRotation = Quaternion.Euler(_rotVec);
        RightWheel.localRotation = Quaternion.Euler(_rotVec);
>>>>>>> parent of 8e88e40 (Emulator eklendi ve kontroller düzenlendi.)
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
<<<<<<< HEAD
<<<<<<< HEAD
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
=======
>>>>>>> parent of 8e88e40 (Emulator eklendi ve kontroller düzenlendi.)
=======
>>>>>>> parent of 8e88e40 (Emulator eklendi ve kontroller düzenlendi.)

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
            carSpeed = 0;
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
