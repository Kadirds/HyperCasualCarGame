using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMoveCar: MonoBehaviour
{   
    public DenemeCarController CarController;
    private float screenWidth;

    [SerializeField]private float moveSpeed = 200;
    public GameObject Car;
    private void Start()
    {
        screenWidth = Screen.width;
    }

    void FixedUpdate()
    {

        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > screenWidth / 2)
            {
                //move right
                RotateCar(1.0f);
            }
            if (Input.GetTouch(i).position.x < screenWidth / 2)
            {
                //move left
                RotateCar(-1.0f);
            }
            ++i;
        }
    }

    public void RotateCar(float horizontalInput)
    {
       CarController.transform.Rotate(Vector3.up * horizontalInput * CarController.steerAngle * Time.deltaTime * CarController._moveVec.magnitude);
    }
}
