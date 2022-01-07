using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(6.00f, 8.5f, 10.19f);
    //private Vector3 rotation = new Vector3(24.794f, -139.29f, 0.964f);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        //Offset the camera behind the player by adding  to the players position   TR=  Oyuncu pozisyonuna ekleyerek oyuncunun arkasýndaki kamerayý ofsetleyin
        transform.position = player.transform.position + offset;
        
    }
}
