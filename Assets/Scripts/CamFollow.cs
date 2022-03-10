using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [SerializeField] private float m_FollowSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * m_FollowSpeed);
    }
}
