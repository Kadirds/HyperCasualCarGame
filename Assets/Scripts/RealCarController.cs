using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealCarController : MonoBehaviour
{
    public WheelCollider RearLeft, RearRight;
    public float SpeedCar;

    // Update is called once per frame
    void Update()
    {
        RearLeft.motorTorque = SpeedCar;
        RearRight.motorTorque = SpeedCar;
    }
}
