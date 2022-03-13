using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMoveCar: MonoBehaviour
{
    public float moveSpeed;
    public DenemeCarController CarController;

    void FixedUpdate()
    {
        TouchMove();
    }


    void TouchMove() 
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);           
            if (mousePos.x < -1)
            {
                //Move Left
                transform.Rotate(Vector3.down * CarController.dragAmount * CarController.steerAngle * Time.deltaTime * CarController._moveVec.magnitude);
            }
            else if (mousePos.x > 1)
            {
                //Move Right
                transform.Rotate(Vector3.up * -CarController.dragAmount * CarController.steerAngle * Time.deltaTime * CarController._moveVec.magnitude);
            }
            
        }
    }
}
