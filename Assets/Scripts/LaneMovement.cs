using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneMovement : MonoBehaviour
{
    CharacterController characterController;
    bool canMove = true;
    Vector3 movec = Vector3.zero;
    int line = 1;
    int targetLine = 1;

    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        if (!line.Equals(targetLine))
        {
            if (targetLine == 0 && pos.x<-2)
            {
                gameObject.transform.position = new Vector3(-2f, pos.y, pos.z);
                line = targetLine;
                canMove = true;
                movec.x = 0;
            }
            else if (targetLine == 1 && (pos.x>0 || pos.x<0))
            {
                if (line == 0 && pos.x>0)
                {
                    gameObject.transform.position = new Vector3(0f, pos.y, pos.z);
                    line = targetLine;
                    canMove = true;
                    movec.x = 0;
                }
                else if(line == 2 && pos.x < 0)
                {
                    gameObject.transform.position = new Vector3(0f, pos.y, pos.z);
                    line = targetLine;
                    canMove = true;
                    movec.x = 0;
                }
                else if (targetLine == 2 && pos.x>2)
                {
                    gameObject.transform.position = new Vector3(2f, pos.y, pos.z);
                    line = targetLine;
                    canMove = true;
                    movec.x = 0;
                }
            }
            
        }
        checkInputs();
        if (!characterController.isGrounded)
        {
            movec.y = -4;
        }
        characterController.Move(movec * Time.deltaTime);
    }

    void checkInputs()
    {
        if (Input.GetKeyDown(KeyCode.A) && canMove && line > 0)
        {
            targetLine--;
            canMove = false;
            movec.x = -4;
        }
        if (Input.GetKeyDown(KeyCode.D) && canMove && line > 2)
        {
            targetLine++;
            canMove = false;
            movec.x = 4;
        }
    }
}
