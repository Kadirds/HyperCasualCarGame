using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(28.5f, 8.51f, 11.86f);
   
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
